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
            Sunrise.WriteLine($"{"Utilities":Cyan}");
            Sunrise.WriteLine($"{"Enter the index number of your desired option \n":DarkGray}");
            Sunrise.WriteLine($"{"(1)":Blue} Add latest cycle details");
            Sunrise.WriteLine($"{"(2)":Blue} Calculate next cycle");
            Sunrise.WriteLine($"{"(3)":Blue} Display history of tracked cycles");
            Sunrise.WriteLine($"{"(4)":Blue} Exit");
            Sunrise.Write($"{"\nfl> ":Green}");
        }

        static void DisplayStartupLogo() {
            Sunrise.WriteLine($"{"Flo Cycle Tracker (0.1.0)":Blue}");
            Sunrise.WriteLine($"{"---\n":Blue}");
        }
    }
}
