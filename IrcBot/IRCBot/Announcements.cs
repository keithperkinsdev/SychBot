using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TwitchBot.IRCBot
{
    class Announcements
    {

        private static List<string> _announcementList  = new List<string>();
        private static System.Threading.Timer _timer;
        private static int announcementIndex = 0;
        static Announcements()
        {
            _announcementList.Add("Hi everyone! I have an ever growing list of features. Type !commands for a list of them all.");
            _announcementList.Add("Welcome to the stream! This stream is all about variety. I will generally be playing/running new games. After a casual playthrough, the game will be briefly routed and then optimized.");
            _announcementList.Add("You can buy a run of any game I have previously played for 200 fasts by typing !buyrun {game} {category}. Type !gamelist for a list of games, and !categorylist {game} for a list of categories.");
            _announcementList.Add("You are earning experience and fasts (points) by just being here! Participate in chat for bonus fasts. Type !stats to find out your info!");
        }

        public static void Start()
        {
            _timer = new Timer(MakeAnnouncement, null, TimeSpan.FromMinutes(Settings.MinutesBetweenAnnouncements), TimeSpan.FromMilliseconds(-1));

        }

        public static void Stop()
        {
            _timer.Change(Timeout.Infinite, -1);
        }

        private static void MakeAnnouncement(object state)
        {
            string announcement = _announcementList.ElementAtOrDefault(announcementIndex);
            announcementIndex = (announcementIndex + 1) % _announcementList.Count;
            Connection.SendToChat(announcement);
            _timer.Change(TimeSpan.FromMinutes(Settings.MinutesBetweenAnnouncements), TimeSpan.FromMilliseconds(-1));
        }
    }
}
