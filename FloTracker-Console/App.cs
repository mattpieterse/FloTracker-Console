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
            Console.WriteLine('\n' + "Utilities" + '\n');
            Console.WriteLine("(1) Track and add latest cycles");
            Console.WriteLine("(2) Calculate next cycle");
            Console.WriteLine("(3) Display full cycle history");
            Console.WriteLine("(4) Exit" + '\n');
        }

        static void DisplayStartupLogo() {
            ColorizeText("Flo Cycle Tracker (0.1.0)", 0);
            ColorizeText("---", 0);
        }

        // --

        static void ColorizeText(string message, int color, bool escape = true) {
            
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
