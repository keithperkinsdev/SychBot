using System;
using System.Collections.Generic;

namespace TwitchBot.IRCBot
{
    internal class Games
    {
        public static List<Game> GameList = new List<Game>();

        public class Game
        {
            public List<string> GameNames = new List<string>();
            public List<string> Categories = new List<string>();
        }

        static Games()
        {
            // OOT
            Game game = new Game();
            game.GameNames.AddRange(new[] {"OOT"});
            game.Categories.AddRange(new[] {"Any%", "CDs", "NoWW/RBA"});
            GameList.Add(game);

            // Super Metroid
            game = new Game();
            game.GameNames.AddRange(new[] {"SuperMetroid"});
            game.Categories.AddRange(new String[] {"Any%"});
            GameList.Add(game);

            // Super Mario 64
            game = new Game();
            game.GameNames.AddRange(new[] { "SuperMario64", "SM64" });
            game.Categories.AddRange(new String[] { "16star", "70star" });
            GameList.Add(game);

            // Amnesia: AMFP
            game = new Game();
            game.GameNames.AddRange(new[] { "Amnesia:AMFP", "AMFP" });
            game.Categories.AddRange(new String[] { "Any%", "Any%NoOOB" });
            GameList.Add(game);

            // Adventure Time: Hey Ice King Why'd You Steal Our Garbage
            game = new Game();
            game.GameNames.AddRange(new[] { "AdventureTime:HIKWYSOG", "AdventureTime", "AT" });
            game.Categories.AddRange(new String[] { "Any%" });
            GameList.Add(game);

            // Contrast
            game = new Game();
            game.GameNames.AddRange(new[] { "Contrast" });
            game.Categories.AddRange(new String[] { "Any%" });
            GameList.Add(game);

            // Contrast
            game = new Game();
            game.GameNames.AddRange(new[] { "SouthPark:SOT", "SOT" });
            game.Categories.AddRange(new String[] { "Any%" });
            GameList.Add(game);

            // Portal
            game = new Game();
            game.GameNames.AddRange(new[] { "Portal", "Porto" });
            game.Categories.AddRange(new String[] { "NoOOB" });
            GameList.Add(game);

        }
    }
}
