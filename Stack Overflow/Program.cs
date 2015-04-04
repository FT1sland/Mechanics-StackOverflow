#region

using System;
using LeagueSharp;
using LeagueSharp.Common;

#endregion

namespace Stack_Overflow
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            var champname = ObjectManager.Player.BaseSkinName;
            if (champname == "Galio")
                new Stack_Overflow.Champions.Galio();
            else if (champname == "Lulu")
                new Stack_Overflow.Champions.Lulu();
            else if (champname == "Mordekaiser")
                new Stack_Overflow.Champions.Mordekaiser();
            else if (champname == "Talon")
                new Stack_Overflow.Champions.Mordekaiser();
            else
            {
                Game.PrintChat("Champion not found. Loading OrbWalker...");
            }
        }

        private static void CurrentDomainOnUnhandledException(object sender,
            UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            Console.WriteLine(((Exception)unhandledExceptionEventArgs.ExceptionObject).Message);
            Console.WriteLine(((Exception)unhandledExceptionEventArgs.ExceptionObject).Source);
            Console.WriteLine((string)unhandledExceptionEventArgs.ExceptionObject);
            Game.PrintChat("Fatal error occured! Report on forum!");
        }
    }
}