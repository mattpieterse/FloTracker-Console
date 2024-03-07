using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace FloTracker_Console {

    internal class App {

        static IDataStore dataStore = new FileDataStore();
        static Tracker tracker = new Tracker(dataStore);

        static void Main(string[] args) {

            DisplayStartupLogo();
            DisplayConsoleMenu();
        }

        // --

        static void DisplayConsoleMenu() {
            int userDestination = 0;
            do {
                Sunrise.WriteLine($"{"Utilities":Cyan}");
                Sunrise.WriteLine($"{"Enter the index number of your desired option \n":DarkGray}");
                Sunrise.WriteLine($"{"(1)":Blue} Add latest cycle details");
                Sunrise.WriteLine($"{"(2)":Blue} Calculate next cycle");
                Sunrise.WriteLine($"{"(3)":Blue} Display history of tracked cycles");
                Sunrise.WriteLine($"{"(4)":Blue} Exit");
                Console.WriteLine();

                int choice = -1;
                while (choice < 0 || choice > 4) {
                    try {
                        Sunrise.Write($"{"fl> ":Green}");
                        choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice) {
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                        }
                    }
                    catch (Exception) {
                        // TODO: Handle caught Exception
                    }
                }
            } while (userDestination != 4);
        }

        static void DisplayStartupLogo() {
            Sunrise.WriteLine($"{"Flo Cycle Tracker (0.1.0)":Blue}");
            Sunrise.WriteLine($"{"---\n":Blue}");
        }
    }
}
