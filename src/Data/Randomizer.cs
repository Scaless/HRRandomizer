
using Newtonsoft.Json;
using System.Collections;
using System.Text;

namespace HRRandomizer.Data
{
    public class RandomizerConfig
    {
        public string Seed { get; set; } = RandomizerWords.RandomWord();
        public GameDifficulty Difficulty { get; set; }
        public bool IsShuffleEnabled { get; set; } = true;
        public bool AllowDuplicates { get; set; } = false;
        public bool HidePlaylist { get; set; } = false;
        public int? CountLimit { get; set; } = 10;
        public int? TimeLimitMinutes { get; set; } = null;
        public float? FudgeFactor { get; set; } = 1.25f;
        public TimeSpan RunningTime { get; set; } = TimeSpan.Zero;

        [JsonIgnore]
        public List<SelectedMission> SelectedMissions = new List<SelectedMission>();

        [JsonIgnore]
        public List<GeneratedMission> Missions { get; set; } = new List<GeneratedMission>();
        [JsonIgnore]
        public string ShareCode { get; set; } = "";

        public List<Game> GamesRequired = new List<Game>();

        public string ToShareCode()
        {
            int ShareCodeVersion = 1;

            List<string> codes = new List<string>();
            codes.Add(ShareCodeVersion.ToString());
            codes.Add(Seed);
            codes.Add(((int)Difficulty).ToString());
            codes.Add(IsShuffleEnabled ? "1" : "0");
            codes.Add(AllowDuplicates ? "1" : "0");
            codes.Add(HidePlaylist ? "1" : "0");
            codes.Add(CountLimit?.ToString() ?? "N");
            codes.Add(TimeLimitMinutes?.ToString() ?? "N");
            codes.Add(FudgeFactor?.ToString() ?? "N");

            string SelectedMissionBits = "";
            for(int i = 0; i < SelectedMissions.Count; i++)
            {
                SelectedMissionBits += SelectedMissions[i].Enabled ? "1" : "0";
            }
            codes.Add(SelectedMissionBits);

            string final = string.Join('|', codes);
            final = Utility.Compress(final);
            return final;
        }

        public bool FromShareCode(string code)
        {
            string decompressed = Utility.Decompress(code);
            string[] codes = decompressed.Split('|');

            if (codes.Length != 10) return false;
            if (codes[0] != "1") return false;

            Seed = codes[1];
            
            GameDifficulty CodeDifficulty;
            if (!Enum.TryParse(codes[2], out CodeDifficulty)) return false;
            Difficulty = CodeDifficulty;
            
            IsShuffleEnabled = codes[3] == "1";
            AllowDuplicates = codes[4] == "1";
            HidePlaylist = codes[5] == "1";

            CountLimit = codes[6] == "N" ? null : int.Parse(codes[6]);
            TimeLimitMinutes = codes[7] == "N" ? null : int.Parse(codes[7]);
            FudgeFactor = codes[8] == "N" ? null : float.Parse(codes[8]);

            int i = 0;
            foreach(char c in codes[9])
            {
                SelectedMissions[i].Enabled = c == '1';
                i++;
            }

            return true;
        }

        public void Reshuffle()
        {
            ShareCode = ToShareCode();// Utility.ToBase64(this);

            Missions.Clear();
            int realSeed = Seed.GetHashCode();
            Random rng = new Random(realSeed);

            RunningTime = new TimeSpan();
            List<Mission> MissionCopy = SelectedMissions.Where(x => x.Enabled).Select(x => x.Mission).ToList();
            List<Game> GamesSelected = SelectedMissions.Where(x=> x.Enabled).Select(x => x.Mission.Game).Distinct().ToList();

        DuplicateRestart:
            if (IsShuffleEnabled)
            {
                Shuffle(MissionCopy, rng);
            }

            foreach (var mission in MissionCopy)
            {
                if (mission.IsCutscene)
                {
                    continue;
                }
                // Enforce Time Limit
                if (TimeLimitMinutes.HasValue
                    && ((RunningTime + (mission.WRTime * (FudgeFactor ?? 1.25))) >= TimeSpan.FromMinutes(TimeLimitMinutes.Value)))
                {
                    continue;
                }

                // Hard Limit in case something goes wrong with generation
                if (Missions.Where(x => !x.Mission.IsCutscene).Count() >= 99)
                {
                    break;
                }

                GeneratedMission m = new GeneratedMission();
                m.Mission = mission;
                m.Difficulty = (Difficulty == GameDifficulty.Random) ? NextDifficulty(rng) : Difficulty;

                //if(config.HidePlaylist && config.Missions.Count() == 0)
                //{
                //    // Insert cutscenes to pad out the start of the playlist.
                //    Mission DefaultCutscene = GetGameDefaultCutscene(m.Mission.Game);
                //    GeneratedMission cutsceneMission = new GeneratedMission();
                //    cutsceneMission.Mission = DefaultCutscene;
                //    cutsceneMission.Difficulty = GameDifficulty.Easy;
                //    for(int i = 0; i < 7; i++)
                //    {
                //        config.Missions.Add(cutsceneMission);
                //    }
                //}

                // Insert a cutscene if the previous mission was the same as the current one
                // This is to prevent a bug in MCC where playing the same mission twice in a row will
                // cause the game to hang.
                GeneratedMission? PreviousMission = Missions.LastOrDefault();
                bool isSameMission = (PreviousMission?.Mission.MapName == m.Mission.MapName) && (PreviousMission?.Mission.InsertionPoint == m.Mission.InsertionPoint);
                bool isSameGameDifferentDifficulty = (PreviousMission?.Mission.Game == m.Mission.Game) && (PreviousMission?.Difficulty != m.Difficulty);
                if (isSameMission || isSameGameDifferentDifficulty)
                {
                    Mission DefaultCutscene = Halo.GetGameDefaultCutscene(m.Mission.Game, GamesSelected);
                    GeneratedMission cutsceneMission = new GeneratedMission();
                    cutsceneMission.Mission = DefaultCutscene;
                    cutsceneMission.Difficulty = GameDifficulty.Easy;
                    Missions.Add(cutsceneMission);
                    RunningTime += cutsceneMission.Mission.WRTime;
                }

                Missions.Add(m);
                RunningTime += mission.WRTime * (FudgeFactor ?? 1.25);

                if (AllowDuplicates)
                {
                    goto DuplicateRestart;
                }
            }

            if (CountLimit != null)
            {
                RunningTime = new TimeSpan();
                List<GeneratedMission> newMissions = new List<GeneratedMission>();
                foreach (GeneratedMission mission in Missions)
                {
                    if(newMissions.Where(x => !x.Mission.IsCutscene).Count() >= CountLimit)
                    {
                        break;
                    }
                    newMissions.Add(mission);
                    RunningTime += mission.Mission.WRTime * (FudgeFactor ?? 1.25);
                }
                Missions = newMissions;
            }

            RunningTime = RunningTime.Subtract(new TimeSpan(0, 0, 0, 0, RunningTime.Milliseconds));

            GamesRequired = Missions.Select(x => x.Mission.Game).Distinct().ToList();
        }

        // Private
        GameDifficulty NextDifficulty(Random rng)
        {
            int value = rng.Next(0, 4);
            switch (value)
            {
                case 0: return GameDifficulty.Easy;
                case 1: return GameDifficulty.Normal;
                case 2: return GameDifficulty.Heroic;
                case 3: return GameDifficulty.Legendary;
            }
            return GameDifficulty.Easy;
        }

        static void Shuffle<T>(IList<T> list, Random rng)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public class Randomizer
    {
    }
}
