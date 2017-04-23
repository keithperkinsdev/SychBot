using System.Text.RegularExpressions;

namespace TwitchBot.IRCBot
{
    public class Settings
    {
        private static readonly Regex SectionRegex = new Regex(@"^\[(.+)\]$", RegexOptions.Compiled);

        public static string AdminName = "Sychotixx";

        public static string UserName = "SychBot";
        public static string Password = "oauth:976c8isj4d1ugxokuwai7nald2k3uj1";

        public static string Server = "irc.twitch.tv";//{ get; private set; }
        public static int Port = 6667;//{ get; private set; }
        public static string Channel = "#sychotixx";//{ get; private set; }

        // Grant settings
        public static int MinutesBetweenGranting = 7;
        public static int ExpPerGrant = 1;
        public static int PointsPerGrant = 1;
        
        // Chat Bonus Settings
        public static int MinutesBetweenChatBonus = 5;
        public static decimal PointsPerChatBonus = 0.5m;

        // Backup Settings
        public static int MinutesBetweenBackup = 5;

        // Announcements
        public static int MinutesBetweenAnnouncements = 15;

        static Settings()
        {
        }

    }
}

