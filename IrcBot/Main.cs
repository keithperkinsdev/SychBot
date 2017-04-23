using System;
using TwitchBot.IRCBot;

namespace TwitchBot
{
    class MainClass
    {
        //[STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Log.StartLogging("sychbot.log", 1000);
                Bot.Start();
            }
        	catch (Exception e)
        	{
            	IRCBot.Log.AddErrorMessage(e.Message);  
            }
        }
    }
}
