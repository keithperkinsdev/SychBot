using Meebey.SmartIrc4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TPlayer;

namespace TwitchBot.IRCBot
{
    class ChatCommands
    {
        private static List<ChatCommand> CommandList = new List<ChatCommand>(); 
        private static Random _random = new Random(Environment.TickCount);
        private static Thread _formThread;
        private static TPlayerForm _mainForm;
        public class ChatCommand
        {
            public ChatCommand(string command, Func<IrcMessageData, bool> func, string usage, bool opOnly)
            {
                Command = command;
                Func = func;
                Usage = usage;
                OpOnly = opOnly;
            }
            public string Command { get; set; }
            public Func<IrcMessageData, bool> Func { get; set; }
            public string Usage { get; set; }
            public bool OpOnly { get; set; }
        }

        private static void ShowMusicBoxForm(object state)
        {
            try
            {

                _mainForm = new TPlayerForm();
                Application.Run(_mainForm);
            }
            catch (Exception)
            {
                Console.WriteLine("Music Box Form ended.");
            }
            finally
            {
                _mainForm = null;
            }
        }

        static ChatCommands()
        {
            CommandList.Add(new ChatCommand("!buyrun", ParseBuyRun, "[game] [category]", false));
            CommandList.Add(new ChatCommand("!stats", ParseStats, string.Empty, false));
            CommandList.Add(new ChatCommand("!opcommands", ParseListOpCommands, string.Empty, false));
            CommandList.Add(new ChatCommand("!commands", ParseListCommands, string.Empty, false));
            CommandList.Add(new ChatCommand("!listGames", ParseListGames, string.Empty, false));
            CommandList.Add(new ChatCommand("!listCategories", ParseListCategories, "[game]", false));
            CommandList.Add(new ChatCommand("!startPoll", ParseStartPoll, "[option],[option],...", true));
            CommandList.Add(new ChatCommand("!stopPoll", ParseStopPoll, string.Empty, true));
            CommandList.Add(new ChatCommand("!vote", ParsePollVote, "[option#]", false));
            CommandList.Add(new ChatCommand("!playSong", ParsePlaySong, "[videoId/link]", false));
            CommandList.Add(new ChatCommand("!musicBox", ParseMusicBox, "[off/on]", true));
            CommandList.Add(new ChatCommand("!currentSong", ParseCurrentSong, string.Empty, false));
            CommandList.Add(new ChatCommand("!startraffle", ParseStartSuggestionRaffle, string.Empty, true));
            CommandList.Add(new ChatCommand("!stopraffle", ParseStopSuggestionRaffle, string.Empty, true));
            CommandList.Add(new ChatCommand("!raffle", ParseSuggestionRaffleEntry, "[entry]", false));
            

            // Raffle Choice
            // - Pay to suggest
            // - Randomly select
            // - Take all points
        }

        private static bool ParseBuyRun(IrcMessageData data)
        {
            decimal pointCost = 100;

            var split = data.Message.Split(new[] {' '}, 3);
            if (split.Length != 3)
            {
                Console.WriteLine("Invalid !buyrun command");
                return false;
            }
            string gameName = split.ElementAtOrDefault(1) ?? string.Empty;
            Games.Game game = Games.GameList.FirstOrDefault(x => x.GameNames.Any(y => y.ToLower() == gameName.ToLower()));
            if (game == null)
            {
                Connection.SendToChat("Game not found");
                return false;
            }
            if (game.Categories.Any(x => x.ToLower() == split.ElementAtOrDefault(2).ToLower()))
            {
                decimal points = 0;
                int exp = 0;
                UserManager.GetUserInfo(data.Nick, out exp, out points);
                if (points >= pointCost)
                {
                    Connection.SendToChat(string.Format("User {0} has bought a run! Game: {1} Category: {2}", data.Nick,
                        split.ElementAtOrDefault(1), split.ElementAtOrDefault(2)));
                    UserManager.UpdateUser(data.Nick, 0, -pointCost);
                    return true;
                }
                else
                {
                    Connection.SendToChat("Not enough fasts!");
                    return false;
                }
            }
            else
            {
                Connection.SendToChat("Category not found");
            }
            return false;
        }
        private static bool ParseStats(IrcMessageData data)
        {
            int experience = 0;
            decimal points = 0;
            UserManager.GetUserInfo(data.Nick, out experience, out points);
            int level = Levels.GetLevel(experience);
            int nextLevelExp = Levels.GetNextLevelExperience(level + 1);
            string title = Levels.GetTitle(level);
            Connection.SendToChat(string.Format("User {0} has {5} fasts and is level {1} ({3}/{4} exp) and is going {2} fast!", data.Nick, level, title, experience, nextLevelExp, points));
            return true;
        }

        private static bool ParseListCommands(IrcMessageData data)
        {

            Connection.SendToChat(string.Join(" , ",(from i in CommandList where !i.OpOnly orderby i.Command select string.Format("{0} {1}",i.Command,i.Usage).Trim()).ToList()));
            return true;
        }

        private static bool ParseListOpCommands(IrcMessageData data)
        {

            Connection.SendToChat(string.Join(" , ", (from i in CommandList orderby i.Command select string.Format("{0} {1}", i.Command, i.Usage).Trim()).ToList()));
            return true;
        }

        private static bool ParseListGames(IrcMessageData data)
        {
            Connection.SendToChat(string.Join(" , ", (from i in Games.GameList select i.GameNames.FirstOrDefault()).OrderBy(x => x).ToList()));
            return true;
        }

        private static bool ParseListCategories(IrcMessageData data)
        {
            var split = data.Message.Split(new []{' '}, 2);
            if (split.Length != 2)
            {
                Console.WriteLine("Invalid arguments for command");
                return false;
            }
            Games.Game game = Games.GameList.FirstOrDefault(x => x.GameNames.Any(y => y.ToLower() == (split.ElementAtOrDefault(1) ?? string.Empty).ToLower()));
            if (game == null)
            {
                Connection.SendToChat("Game not found");
                return false;
            }
            Connection.SendToChat(string.Join(" , ", (from i in game.Categories orderby i select i).ToList()));
            return true;
        }

        #region Poll Functions
        private static bool _pollStarted = false;
        private static List<string> _pollOptions = new List<string>();
        private static Dictionary<string, int> _pollVotes = new Dictionary<string, int>();  
        private static bool ParseStartPoll(IrcMessageData data)
        {
            if (data.Nick.ToLower() != Settings.AdminName.ToLower() || _pollStarted)
                return false;

            _pollOptions.Clear();
            _pollVotes.Clear();
            var firstSplit = data.Message.Split(new char[] {' '}, 2);
            if (firstSplit.Length != 2)
            {
                Console.WriteLine("Invalid startpoll arguments");
                return false;
            }
            var secondSplit = firstSplit.ElementAtOrDefault(1).Split(new char[] {','});
            _pollOptions.AddRange(secondSplit);
            _pollStarted = true;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _pollOptions.Count; i++)
            {
                sb.AppendFormat(" {0}) {1} ", i + 1, _pollOptions.ElementAtOrDefault(i));
            }
            Connection.SendToChat(string.Format("Poll started! Options are {0} Type !vote [option] to vote!", sb.ToString()));
            return true;
        }

        private static bool ParsePollVote(IrcMessageData data)
        {
            if (!_pollStarted)
                return false;

            var split = data.Message.Split(new char[] {' '});
            int choice = 0;
            if (int.TryParse(split.ElementAtOrDefault(1), out choice) && choice >= 1 && choice <= _pollOptions.Count)
            {
                _pollVotes[data.Nick] = choice;
                return true;
            }
            return false;
        }

        private static bool ParseStopPoll(IrcMessageData data)
        {
            if (data.Nick.ToLower() != Settings.AdminName.ToLower())
                return false;

            _pollStarted = false;
            var option = _pollVotes.Select(x => x.Value).GroupBy(x => x).Select(x => new { x.Key, Count = x.Count()}).OrderByDescending(x => x.Count).FirstOrDefault();
            if (option != null)
            {
                Connection.SendToChat(string.Format("Poll option '{0}' has won!", _pollOptions.ElementAtOrDefault(option.Key - 1)));
                return true;
            }
            else Connection.SendToChat("No option was selected from poll!");
            return false;
        }

        #endregion // End Poll Functions Region

        #region Music Bot Functions

        private static bool _musicBoxEnabled = false;
        private static bool ParseMusicBox(IrcMessageData data)
        {
            var split = data.Message.Split(new[] {' '});
            if (split.Length == 2)
            {
                if (_musicBoxEnabled && split.ElementAtOrDefault(1).ToLower() == "off")
                {
                    _formThread.Abort();
                    _formThread = null;
                    _musicBoxEnabled = false;
                    Connection.SendToChat("Musicbox is now disabled.");
                    return true;
                }
                else if (!_musicBoxEnabled && split.ElementAtOrDefault(1).ToLower() == "on")
                {
                    _formThread = new System.Threading.Thread(ShowMusicBoxForm);
                    _formThread.SetApartmentState(ApartmentState.STA);
                    _formThread.Start();
                    _musicBoxEnabled = true;
                    Connection.SendToChat("Musicbox is now enabled! Type !playSong {link/id} to play a youtube song. Note: Video MUST allow embedding, or it will not play!");
                    return true;
                }
            }
            return false;
        }
        private static bool ParsePlaySong(IrcMessageData data)
        {
            if (!_musicBoxEnabled) return false;
            var split = data.Message.Split(new[] {' '});
            if (split.Length == 2)
            {
                TPlayerForm.TVideo video;
                int ret = _mainForm.QueueOrPlaySong(split.ElementAtOrDefault(1), out video);
                if(ret != 0)
                {
                    if (ret == 1)
                        Connection.SendToChat("Invalid song link or id.");
                    else if (ret == 2)
                        Connection.SendToChat("Video length is too long. Must be below 8 minutes long.");
                    return false;
                }
                else if (video != null)
                {
                    Connection.SendToChat(string.Format("The song {0} (https://www.youtube.com/watch?v={1})  Duration: {2} was added to the list.", video.name, video.videoID, TimeSpan.FromSeconds(video.duration).ToString("m':'ss")));
                    Connection.SendToChat("Song added to list.");
                    return true;
                }
                else
                {
                    Connection.SendToChat("Something weird happened while processing that song. Video returned null.");
                    return false;
                }
                
            }
            return false;
        }

        public static bool ParseCurrentSong(IrcMessageData data)
        {
            if (!_musicBoxEnabled) return false;
            TPlayerForm.TVideo video = _mainForm.GetCurrentVideo();
            Connection.SendToChat(string.Format("The currently playing song is {0} (https://www.youtube.com/watch?v={1})  Duration: {2}", video.name, video.videoID, TimeSpan.FromSeconds(video.duration).ToString("m':'ss")));
            return true;
        }

        #endregion

        #region Suggestion Raffle Functions

        private static bool _suggestionRaffleEnabled = false;
        private static Dictionary<string,string> _suggestionRaffleEntries = new Dictionary<string,string>();

        private static bool ParseStartSuggestionRaffle(IrcMessageData data)
        {
            if (_suggestionRaffleEnabled)
                return false;

            _suggestionRaffleEnabled = true;
            _suggestionRaffleEntries.Clear();
            Connection.SendToChat("Raffle started! Type !raffle {entry} to submit your entry!");
            return true;

        }
        private static bool ParseSuggestionRaffleEntry(IrcMessageData data)
        {
            if (!_suggestionRaffleEnabled)
                return false;
            var split = data.Message.Split(new[] {' '});
            _suggestionRaffleEntries[data.Nick] = split.ElementAtOrDefault(1);
            return true;
        }

        private static bool ParseStopSuggestionRaffle(IrcMessageData data)
        {
            if (!_suggestionRaffleEnabled)
                return false;

            _suggestionRaffleEnabled = false;
            if (_suggestionRaffleEntries.Count == 0)
            {
                Connection.SendToChat("No entries were entered into the raffle.");
                return true;
            }
            var winningEntry = _suggestionRaffleEntries.ElementAtOrDefault(_random.Next(0, _suggestionRaffleEntries.Count));
            Connection.SendToChat(string.Format("User {0} won the raffle! The result was {1}", winningEntry.Key, winningEntry.Value));
            return true;
        }
        #endregion


        public static bool IsOp(string s)
        {
            return s.ToLower() == Settings.AdminName.ToLower();
        }

        public static bool ParseCommand(IrcMessageData data)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(data.Message) && data.Message.ElementAtOrDefault(0) == '!')
                {
                    var split = data.Message.Split(new char[] {' '}, 2);
                    string parsedCommand = split.ElementAtOrDefault(0) ?? string.Empty;
                    ChatCommand command = CommandList.FirstOrDefault(x => x.Command.ToLower() == parsedCommand.ToLower());
                    if (command == null || command.Func == null)
                    {
                        Console.WriteLine("Command: {0} not found.", parsedCommand);
                        return false;
                    }

                    if (command.OpOnly && !IsOp(data.Nick))
                        return false;

                    command.Func(data);

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled exception: {0}", e.Message);
            }
            return false;
        }
    }
}
