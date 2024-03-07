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
            Console.ReadLine();
        }

        // --

        static void DisplayStartupLogo() {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Flo Cycle Tracker (0.1.0)" + "\n---\n");
            Console.ResetColor();
        }
    }
}
