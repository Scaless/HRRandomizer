
using Newtonsoft.Json;
using System.Text;

namespace HRRandomizer.Data
{
    public class RandomizerConfig
    {
        public string Seed { get; set; } = RandomizerWords.RandomWord();
        public GameDifficulty Difficulty { get; set; }
        public bool IncludeCutscenes { get; set; } = false;
        public bool IsShuffleEnabled { get; set; } = true;
        public bool AllowDuplicates { get; set; } = false;
        public bool HidePlaylist { get; set; } = false;
        public int? CountLimit { get; set; } = 20;
        public int? TimeLimitMinutes { get; set; } = null;
        public float? FudgeFactor { get; set; } = 1.25f;
        
        public List<SelectedMission> SelectedMissions = new List<SelectedMission>();

        [JsonIgnore]
        public List<GeneratedMission> Missions { get; set; } = new List<GeneratedMission>();
        [JsonIgnore]
        public string ShareCode { get; set; } = "";

        public void Reshuffle()
        {
            ShareCode = Utility.ToBase64(this);

            Missions.Clear();
            int realSeed = Seed.GetHashCode();
            Random rng = new Random(realSeed);

            TimeSpan runningTime = new TimeSpan();
            List<Mission> MissionCopy = SelectedMissions.Where(x => x.Enabled).Select(x => x.Mission).ToList();

        DuplicateRestart:
            if (IsShuffleEnabled)
            {
                Shuffle(MissionCopy, rng);
            }

            foreach (var mission in MissionCopy)
            {
                if (!IncludeCutscenes && mission.IsCutscene)
                {
                    continue;
                }
                // Enforce Time Limit
                if (TimeLimitMinutes.HasValue
                    && ((runningTime + (mission.WRTime * (FudgeFactor ?? 1.25))) >= TimeSpan.FromMinutes(TimeLimitMinutes.Value)))
                {
                    continue;
                }

                // Hard Limit in case something goes wrong with generation
                if (Missions.Count >= 99)
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
                if ((PreviousMission?.Mission.MapName == m.Mission.MapName) && (PreviousMission?.Mission.InsertionPoint == m.Mission.InsertionPoint))
                {
                    Mission DefaultCutscene = Halo.GetGameDefaultCutscene(m.Mission.Game);
                    GeneratedMission cutsceneMission = new GeneratedMission();
                    cutsceneMission.Mission = DefaultCutscene;
                    cutsceneMission.Difficulty = GameDifficulty.Easy;
                    Missions.Add(cutsceneMission);
                    runningTime += cutsceneMission.Mission.WRTime;
                }

                Missions.Add(m);
                runningTime += (mission.WRTime * (FudgeFactor ?? 1.25));

                if (AllowDuplicates)
                {
                    goto DuplicateRestart;
                }
            }

            if (CountLimit != null)
            {
                Missions = Missions.Take(CountLimit.Value).ToList();
            }

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
