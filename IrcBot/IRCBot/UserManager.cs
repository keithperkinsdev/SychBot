using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TwitchBot.IRCBot
{
    class User
    {
        public User()
        {
            Username = string.Empty;
            Experience = 0;
            Points = 0;
            LastAwardedForChat = DateTime.MinValue;
        }
        public string Username { get; set; }
        public int Experience { get; set; }
        public decimal Points { get; set; }
        public DateTime LastAwardedForChat { get; set; }
    }

    class UserManager
    {
        public static List<User> UserList = new List<User>();
        private static System.Threading.Timer _timer;
        static UserManager()
        {
            if (File.Exists("userdb.txt"))
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(@"userdb.txt"))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        var split = line.Split(new char[] {','});
                        User u = new User
                        {
                            Username = split.ElementAtOrDefault(0) ?? string.Empty,
                            Experience = int.Parse(split.ElementAtOrDefault(1) ?? "0"),
                            Points = decimal.Parse(split.ElementAtOrDefault(2) ?? "0")
                        };
                        UserList.Add(u);
                    }
                }
            }
            

            _timer = new Timer(SaveInfo, "userdb-BACKUP.txt", TimeSpan.FromMinutes(Settings.MinutesBetweenBackup), TimeSpan.FromMilliseconds(-1));
        }

        public static void UpdateUser(string username, int expChange, decimal pointChange)
        {
            User user = UserList.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
            if (user == null)
            {
                user = new User {Username = username};
                UserList.Add(user);
            }
            user.Experience += expChange;
            user.Points += pointChange;
        }

        public static void GetUserInfo(string username, out int experience, out decimal points)
        {
            experience = 0;
            points = 0;
            User user = UserList.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
            if (user == null)
            {
                user = new User();
                user.Username = username;
                UserList.Add(user);
                return;
            }
            else
            {
                experience = user.Experience;
                points = user.Points;
            }
        }

        public static void UserSentChat(string username)
        {
            User user = UserList.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
            if (user == null)
            {
                user = new User {Username = username};
                UserList.Add(user);
            }
            if (DateTime.Compare(DateTime.Now, user.LastAwardedForChat.AddMinutes(Settings.MinutesBetweenChatBonus)) >= 0)
            {
                UserManager.UpdateUser(username, 0, Settings.PointsPerChatBonus);
                user.LastAwardedForChat = DateTime.Now;
            }
        }

        public static void SaveInfo(object paramFileName = null)
        {
            string fileName = @"userdb.txt";
            if (paramFileName != null)
                fileName = (string) paramFileName;
            string[] fileInfo = (from i in UserList
                select string.Format("{0},{1},{2}", i.Username, i.Experience, i.Points)).ToArray();
            System.IO.File.WriteAllLines(fileName, fileInfo);

            // Restart the timer if this was a timer call
            if (paramFileName != null)
                _timer.Change(TimeSpan.FromMinutes(Settings.MinutesBetweenBackup), TimeSpan.FromMilliseconds(-1));
        }
    }
}
