using Newtonsoft.Json;

namespace HRRandomizer.Data
{
    public enum GameDifficulty
    {
        Easy,
        Normal,
        Heroic,
        Legendary,
        Random
    }

    public enum Game
    {
        Halo1,
        Halo2,
        Halo3,
        Halo3ODST,
        HaloReach,
        Halo4
    }

    public class GeneratedMission
    {
        public GameDifficulty Difficulty { get; set; }
        public Mission Mission { get; set; }
    }

    public class SelectedMission
    {
        public bool Enabled { get; set; } = true;
        public string MapName { get; set; } = "";
        [JsonIgnore]
        public Mission Mission { get; set; }
    }

    public struct Mission
    {
        public Mission() { }

        public Game Game { get; set; } = Game.Halo1;
        public string FriendlyName { get; set; } = "";
        public string MapName { get; set; } = "";
        public int InsertionPoint { get; set; } = 0;
        public bool IsCutscene { get; set; } = false;
        public TimeSpan WRTime { get; set; } = TimeSpan.FromMinutes(5);
    }

    public class Halo
    {
        public static readonly Mission[] AllMissions = new[]
        {
            new Mission() { Game = Game.Halo1, WRTime = TimeSpan.FromMinutes(5), FriendlyName="Pillar of Autumn", MapName="_map_id_halo1_pillar_of_autumn" },
            new Mission() { Game = Game.Halo1, WRTime = TimeSpan.FromMinutes(10), FriendlyName="Halo", MapName="_map_id_halo1_halo" },
            new Mission() { Game = Game.Halo1, WRTime = TimeSpan.FromMinutes(7), FriendlyName="Truth and Reconciliation", MapName="_map_id_halo1_truth_and_reconciliation" },
            new Mission() { Game = Game.Halo1, WRTime = TimeSpan.FromMinutes(4), FriendlyName="Silent Cartographer", MapName="_map_id_halo1_silent_cartographer" },
            new Mission() { Game = Game.Halo1, WRTime = TimeSpan.FromMinutes(5), FriendlyName="Assault on the Control Room", MapName="_map_id_halo1_assault_on_the_control_room" },
            new Mission() { Game = Game.Halo1, WRTime = TimeSpan.FromMinutes(4), FriendlyName="343 Guilty Spark", MapName="_map_id_halo1_343_guilty_spark" },
            new Mission() { Game = Game.Halo1, WRTime = TimeSpan.FromMinutes(11), FriendlyName="The Library", MapName="_map_id_halo1_the_library" },
            new Mission() { Game = Game.Halo1, WRTime = TimeSpan.FromMinutes(7), FriendlyName="Two Betrayals", MapName="_map_id_halo1_two_betrayals" },
            new Mission() { Game = Game.Halo1, WRTime = TimeSpan.FromMinutes(3), FriendlyName="Keyes", MapName="_map_id_halo1_keyes" },
            new Mission() { Game = Game.Halo1, WRTime = TimeSpan.FromMinutes(7), FriendlyName="The Maw", MapName="_map_id_halo1_the_maw" },

            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(0), FriendlyName="Heretic", MapName="_map_id_halo2_the_heretic", IsCutscene=true },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(3), FriendlyName="The Armory", MapName="_map_id_halo2_the_armory" },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(5), FriendlyName="Cairo Station", MapName="_map_id_halo2_cairo_station" },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(4), FriendlyName="Outskirts", MapName="_map_id_halo2_outskirts" },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(4), FriendlyName="Metropolis", MapName="_map_id_halo2_metropolis" },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(3), FriendlyName="The Arbiter", MapName="_map_id_halo2_the_arbiter" },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(11), FriendlyName="The Oracle", MapName="_map_id_halo2_the_oracle" },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(3), FriendlyName="Delta Halo", MapName="_map_id_halo2_delta_halo" },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(10), FriendlyName="Regret", MapName="_map_id_halo2_regret" },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(8), FriendlyName="Sacred Icon", MapName="_map_id_halo2_sacred_icon" },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(7), FriendlyName="Quarantine Zone", MapName="_map_id_halo2_quarantine_zone" },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(7), FriendlyName="Gravemind", MapName="_map_id_halo2_gravemind" },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(2), FriendlyName="Uprising", MapName="_map_id_halo2_uprising" },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(2), FriendlyName="High Charity", MapName="_map_id_halo2_high_charity" },
            new Mission() { Game = Game.Halo2, WRTime = TimeSpan.FromMinutes(7), FriendlyName="The Great Journey", MapName="_map_id_halo2_the_great_journey" },

            new Mission() { Game = Game.Halo3, WRTime = TimeSpan.FromMinutes(0), FriendlyName="Arrival", MapName="_map_id_halo3_arrival", IsCutscene=true },
            new Mission() { Game = Game.Halo3, WRTime = TimeSpan.FromMinutes(6), FriendlyName="Sierra 117", MapName="_map_id_halo3_sierra_117" },
            new Mission() { Game = Game.Halo3, WRTime = TimeSpan.FromMinutes(8), FriendlyName="Crows Nest", MapName="_map_id_halo3_crows_nest" },
            new Mission() { Game = Game.Halo3, WRTime = TimeSpan.FromMinutes(4), FriendlyName="Tsavo Highway", MapName="_map_id_halo3_tsavo_highway" },
            new Mission() { Game = Game.Halo3, WRTime = TimeSpan.FromMinutes(5), FriendlyName="The Storm", MapName="_map_id_halo3_the_storm" },
            new Mission() { Game = Game.Halo3, WRTime = TimeSpan.FromMinutes(3), FriendlyName="Floodgate", MapName="_map_id_halo3_floodgate" },
            new Mission() { Game = Game.Halo3, WRTime = TimeSpan.FromMinutes(10), FriendlyName="The Ark", MapName="_map_id_halo3_the_ark" },
            new Mission() { Game = Game.Halo3, WRTime = TimeSpan.FromMinutes(10), FriendlyName="The Covenant", MapName="_map_id_halo3_the_covenant" },
            new Mission() { Game = Game.Halo3, WRTime = TimeSpan.FromMinutes(6), FriendlyName="Cortana", MapName="_map_id_halo3_cortana" },
            new Mission() { Game = Game.Halo3, WRTime = TimeSpan.FromMinutes(10), FriendlyName="Halo", MapName="_map_id_halo3_halo" },
            new Mission() { Game = Game.Halo3, WRTime = TimeSpan.FromMinutes(0), FriendlyName="Epilogue", MapName="_map_id_halo3_epilogue", IsCutscene=true },

            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(0), FriendlyName="Prepare to Drop (Cutscene)", MapName="_map_id_halo3odst_prepare_to_drop", IsCutscene=true },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(2), FriendlyName="Mombasa Streets (Prepare to Drop)", MapName="_map_id_halo3odst_mombasa_streets" },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(2), FriendlyName="Tayari Plaza", MapName="_map_id_halo3odst_tayari_plaza" },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(3), FriendlyName="Mombasa Streets (Drone Optic)", MapName="_map_id_halo3odst_mombasa_streets", InsertionPoint=1 },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(2), FriendlyName="Uplift Reserve", MapName="_map_id_halo3odst_uplift_reserve"},
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(3), FriendlyName="Mombasa Streets (Gauss Turret)", MapName="_map_id_halo3odst_mombasa_streets", InsertionPoint=2 },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(3), FriendlyName="Kizingo Boulevard", MapName="_map_id_halo3odst_kizingo_boulevard" },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(1), FriendlyName="Mombasa Streets (Remote Detonator)", MapName="_map_id_halo3odst_mombasa_streets", InsertionPoint=3 },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(8), FriendlyName="ONI Alpha Site", MapName="_map_id_halo3odst_oni_alpha_site" },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(2), FriendlyName="Mombasa Streets (Sniper Rifle)", MapName="_map_id_halo3odst_mombasa_streets", InsertionPoint=4 },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(5), FriendlyName="NMPD HQ", MapName="_map_id_halo3odst_nmpd_hq" },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(1), FriendlyName="Mombasa Streets (Biofoam Canister)", MapName="_map_id_halo3odst_mombasa_streets", InsertionPoint=5 },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(3), FriendlyName="Kikowani Station", MapName="_map_id_halo3odst_kikowani_station" },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(1), FriendlyName="Mombasa Streets (Data Hive)", MapName="_map_id_halo3odst_mombasa_streets", InsertionPoint=6 },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(10), FriendlyName="Data Hive", MapName="_map_id_halo3odst_data_hive" },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(16), FriendlyName="Coastal Highway", MapName="_map_id_halo3odst_coastal_highway" },
            new Mission() { Game = Game.Halo3ODST, WRTime = TimeSpan.FromMinutes(0), FriendlyName="Epilogue", MapName="_map_id_halo3odst_epilogue", IsCutscene=true },

            new Mission() { Game = Game.HaloReach, WRTime = TimeSpan.FromMinutes(0), FriendlyName="Noble Actual", MapName="_map_id_haloreach_noble_actual", IsCutscene=true },
            new Mission() { Game = Game.HaloReach, WRTime = TimeSpan.FromMinutes(5), FriendlyName="Winter Contingency", MapName="_map_id_haloreach_winter_contingency" },
            new Mission() { Game = Game.HaloReach, WRTime = TimeSpan.FromMinutes(5), FriendlyName="ONI Sword Base", MapName="_map_id_haloreach_oni_sword_base" },
            new Mission() { Game = Game.HaloReach, WRTime = TimeSpan.FromMinutes(3), FriendlyName="Nightfall", MapName="_map_id_haloreach_nightfall" },
            new Mission() { Game = Game.HaloReach, WRTime = TimeSpan.FromMinutes(5), FriendlyName="Tip of the Spear", MapName="_map_id_haloreach_tip_of_the_spear" },
            new Mission() { Game = Game.HaloReach, WRTime = TimeSpan.FromMinutes(11), FriendlyName="Long Night of Solace", MapName="_map_id_haloreach_long_night_of_solace" },
            new Mission() { Game = Game.HaloReach, WRTime = TimeSpan.FromMinutes(9), FriendlyName="Exodus", MapName="_map_id_haloreach_exodus" },
            new Mission() { Game = Game.HaloReach, WRTime = TimeSpan.FromMinutes(7), FriendlyName="New Alexandria", MapName="_map_id_haloreach_new_alexandria" },
            new Mission() { Game = Game.HaloReach, WRTime = TimeSpan.FromMinutes(8), FriendlyName="The Package", MapName="_map_id_haloreach_the_package" },
            new Mission() { Game = Game.HaloReach, WRTime = TimeSpan.FromMinutes(9), FriendlyName="The Pillar of Autumn", MapName="_map_id_haloreach_the_pillar_of_autumn" },
            new Mission() { Game = Game.HaloReach, WRTime = TimeSpan.FromMinutes(0), FriendlyName="The Pillar of Autumn (Credits)", MapName="_map_id_haloreach_the_pillar_of_autumn_credits", IsCutscene=true },
            new Mission() { Game = Game.HaloReach, WRTime = TimeSpan.FromMinutes(0), FriendlyName="Lone Wolf", MapName="_map_id_haloreach_lone_wolf", IsCutscene=true },

            new Mission() { Game = Game.Halo4, WRTime = TimeSpan.FromMinutes(0), FriendlyName="Prologue", MapName="_map_id_halo4_prologue", IsCutscene=true },
            new Mission() { Game = Game.Halo4, WRTime = TimeSpan.FromMinutes(4), FriendlyName="Dawn", MapName="_map_id_halo4_dawn" },
            new Mission() { Game = Game.Halo4, WRTime = TimeSpan.FromMinutes(8), FriendlyName="Requiem", MapName="_map_id_halo4_requiem" },
            new Mission() { Game = Game.Halo4, WRTime = TimeSpan.FromMinutes(10), FriendlyName="Forerunner", MapName="_map_id_halo4_forerunner" },
            new Mission() { Game = Game.Halo4, WRTime = TimeSpan.FromMinutes(13), FriendlyName="Infinity", MapName="_map_id_halo4_infinity" },
            new Mission() { Game = Game.Halo4, WRTime = TimeSpan.FromMinutes(11), FriendlyName="Reclaimer", MapName="_map_id_halo4_reclaimer" },
            new Mission() { Game = Game.Halo4, WRTime = TimeSpan.FromMinutes(4), FriendlyName="Shutdown", MapName="_map_id_halo4_shutdown" },
            new Mission() { Game = Game.Halo4, WRTime = TimeSpan.FromMinutes(9), FriendlyName="Composer", MapName="_map_id_halo4_composer" },
            new Mission() { Game = Game.Halo4, WRTime = TimeSpan.FromMinutes(13), FriendlyName="Midnight", MapName="_map_id_halo4_midnight" },
            new Mission() { Game = Game.Halo4, WRTime = TimeSpan.FromSeconds(15), FriendlyName="Epilogue", MapName="_map_id_halo4_epilogue", IsCutscene=true },
        };

        public static string DifficultyToXML(GameDifficulty difficulty)
        {
            switch (difficulty)
            {
                case GameDifficulty.Easy: return "_campaign_difficulty_level_easy";
                case GameDifficulty.Normal: return "_campaign_difficulty_level_normal";
                case GameDifficulty.Heroic: return "_campaign_difficulty_level_hard";
                case GameDifficulty.Legendary: return "_campaign_difficulty_level_impossible";
                default: return "";
            }
        }

        // Return the cutscene to use for the given game
        public static Mission GetGameDefaultCutscene(Game game)
        {
            if (game == Game.Halo1)
            {
                game = Game.Halo2;
            }

            switch (game)
            {
                case Game.Halo2: return AllMissions.First(x => x.Game == Game.Halo2 && x.FriendlyName == "Heretic");
                case Game.Halo3: return AllMissions.First(x => x.Game == Game.Halo3 && x.FriendlyName == "Epilogue");
                case Game.Halo3ODST: return AllMissions.First(x => x.Game == Game.Halo3ODST && x.FriendlyName == "Epilogue");
                case Game.HaloReach: return AllMissions.First(x => x.Game == Game.HaloReach && x.FriendlyName == "The Pillar of Autumn (Credits)");
                case Game.Halo4: return AllMissions.First(x => x.Game == Game.Halo4 && x.FriendlyName == "Epilogue");
                default: return AllMissions.First(x => x.Game == Game.Halo2 && x.FriendlyName == "Heretic");
            }
        }

    } // Halo


}
