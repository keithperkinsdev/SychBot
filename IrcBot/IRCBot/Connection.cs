using Meebey.SmartIrc4net;
using System;
using System.Threading;

namespace TwitchBot.IRCBot
{
    public class Connection
    {
        private static readonly IrcClient _irc = new IrcClient();

        
        private static bool _shouldDisconnect = false;
        private static System.Threading.Timer _timer;

        public static void Start()
        {
            Console.WriteLine("Starting Bot...");
            _irc.Encoding = System.Text.Encoding.UTF8;
            _irc.SendDelay = 1000;
            _irc.ActiveChannelSyncing = true;
            _irc.AutoReconnect = true;
            _irc.AutoRejoinOnKick = true;
            _irc.AutoRetry = true;
            _irc.AutoRetryDelay = 30000;
            _irc.AutoRelogin = true;

            _irc.OnError += new ErrorEventHandler(OnError);
            _irc.OnRawMessage += new IrcEventHandler(OnRawMessage);

            try
            {
                Console.WriteLine("Trying to connect to irc...");

                _irc.Connect(Settings.Server, Settings.Port);

            }
            catch (Exception e)
            {
                Log.AddErrorMessage(e.Message);
                System.Environment.Exit(1);
            }

            try
            {
                Console.WriteLine("Logging into irc...");

                _irc.Login(Settings.UserName, Settings.UserName, 0, Settings.UserName, Settings.Password);
                Console.WriteLine("Joining channel...");

                _irc.RfcJoin(Settings.Channel);

                Console.WriteLine("Starting backup timer...");
                _timer = new Timer(UserTick, null, TimeSpan.FromMinutes(Settings.MinutesBetweenGranting), TimeSpan.FromMilliseconds(-1));

                Console.WriteLine("Starting Announcements...");
                Announcements.Start();

                Console.WriteLine("Waiting for commands...");
                // Listen for ChatCommands
                while (!_shouldDisconnect)
                {
                    Thread.Sleep(200);
                    _irc.ListenOnce();
                }
            }
            catch (Exception e)
            {
                Log.AddErrorMessage(e.Message);
            }
            finally
            {
                _irc.Disconnect();
            }

        }

        private static void OnRawMessage(object sender, IrcEventArgs e)
        {
            if (!_irc.IsMe(e.Data.Nick) && e.Data.Nick != null && e.Data.Message != null && e.Data.Nick.ToLower() != "ping")
            {
                if (!ChatCommands.ParseCommand(e.Data))
                {
                    UserManager.UserSentChat(e.Data.Nick);
                }
            }
            Log.AddMessage(e.Data.Message);    
        }

        private static void OnError(object sender, ErrorEventArgs e)
        {
            Log.AddErrorMessage(e.ErrorMessage);
            _shouldDisconnect = true;
        }

        private static void UserTick(object state)
        {
            Meebey.SmartIrc4net.Channel chan = _irc.GetChannel(Settings.Channel);
            foreach (Meebey.SmartIrc4net.ChannelUser user in chan.Users.Values)
            {
                UserManager.UpdateUser(user.Nick, Settings.ExpPerGrant, Settings.PointsPerGrant);
            }
            _timer.Change(TimeSpan.FromMinutes(Settings.MinutesBetweenGranting), TimeSpan.FromMilliseconds(-1));
        }

        public static void SendToChat(string msg)
        {
            Console.WriteLine(msg);
            _irc.SendMessage(SendType.Message, Settings.Channel, msg);
        }
    }
}

