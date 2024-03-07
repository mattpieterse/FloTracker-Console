using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloTracker_Console {

    internal class App {

        static IDataStore dataStore = new FileDataStore();
        static Tracker tracker = new Tracker(dataStore);

        static void Main(string[] args) {

            DisplayStartupLogo();
            DisplayConsoleMenu();
            Console.ReadLine();
        }

        // --

        static void DisplayConsoleMenu() {
            ToConsole("\nUtilities", 1);
            ToConsole("Enter the index number of your desired option\n");
            ToConsole("(1) ", 0, false);
            ToConsole("Track and add latest cycles");
            ToConsole("(2) Calculate next cycle");
            ToConsole("(3) Display full cycle history");
            ToConsole("(4) Exit");
        }

        static void DisplayStartupLogo() {
            ToConsole("Flo Cycle Tracker (0.1.0)", 0);
            ToConsole("---", 0);
        }

        // --

        static void ToConsole(string message, int color = 4, bool escape = true) {
            
            Console.ForegroundColor = color switch {
                0 => ConsoleColor.Blue,
                1 => ConsoleColor.Cyan,
                2 => ConsoleColor.Magenta,
                3 => ConsoleColor.Gray,
                _ => ConsoleColor.White
            };

            if (escape) {
                Console.WriteLine(message);
            } else {
                Console.Write(message);
            }

            Console.ResetColor();
        }
    }
}
