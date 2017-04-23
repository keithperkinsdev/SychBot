using System;
using System.Runtime.InteropServices;

namespace TwitchBot.IRCBot
{
    public class Bot
    {
        public static void Start()
        {
            try
            {
                SetConsoleCtrlHandler(new HandlerRoutine(ConsoleCtrlCheck), true);
                Connection.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled Exception. {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Bot has finished. Press enter to continue.");
                Console.Read(); 
            }
        }

        // An enumerated type for the control messages
        // sent to the handler routine.
        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        // A delegate type to be used as the handler routine
        // for SetConsoleCtrlHandler.
        public delegate bool HandlerRoutine(CtrlTypes CtrlType);

        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);

        private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            switch (ctrlType)
            {

                case CtrlTypes.CTRL_C_EVENT:
                case CtrlTypes.CTRL_BREAK_EVENT:
                case CtrlTypes.CTRL_CLOSE_EVENT:
                case CtrlTypes.CTRL_LOGOFF_EVENT:
                case CtrlTypes.CTRL_SHUTDOWN_EVENT:
                    UserManager.SaveInfo();
                break;
            }
            return true;
        }
    }
}

