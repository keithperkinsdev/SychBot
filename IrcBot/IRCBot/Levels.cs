using System;
using System.Collections.Generic;
using System.Linq;

namespace TwitchBot
{
    public class Levels
    {
        private static readonly List<string> LevelNames = new List<string>();
        static Levels()
        {
            LevelNames.AddRange(new String[] { "negative", "frozen", "somewhat", "reasonably", "really", "supa", "holy shit", "sanic", "super sanic", "lightspeed", "literally godspeed", "how'd you get this fast?" });
        }

        public static string GetTitle(int level)
        {
            return LevelNames.ElementAtOrDefault(Math.Min(level, LevelNames.Count - 1));
        }

        public static int GetNextLevelExperience(int level)
        {
            try
            {
                return Math.Max(0, Convert.ToInt32(Math.Floor(1.3 * Math.Pow(level, 3))));
            }
            catch (Exception)
            {
                Console.WriteLine("Get next level. Returning 0 exp.");
                return 0;
            }
        }

        public static int GetLevel(int experience)
        {
            return Math.Max(0, Convert.ToInt32(Math.Floor(Math.Pow(((double)experience) / 1.3, 1.0 / 3))));
        }
    }
}
