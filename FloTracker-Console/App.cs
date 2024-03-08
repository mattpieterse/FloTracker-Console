using System;

namespace FloTracker_Console {

    internal class App {

        static IDataStore dataStore = new FileDataStore();
        static Tracker tracker = new Tracker(dataStore);

        static void Main(string[] args) {
            DisplayStartupLogo();
            DisplayConsoleMenu();
        }

        // -- Display user interface

        static void DisplayConsoleMenu() {
            int choice = 0;
            do {
                Sunrise.WriteLine($"{"\nUtilities":Cyan}");
                Sunrise.WriteLine($"{"Enter the index number of your desired option \n":DarkGray}");
                Sunrise.WriteLine($"{"(1)":Blue} Add latest cycle details");
                Sunrise.WriteLine($"{"(2)":Blue} Calculate next cycle");
                Sunrise.WriteLine($"{"(3)":Blue} Display history of tracked cycles");
                Sunrise.WriteLine($"{"(4)":Blue} Exit");
                Console.WriteLine();

                while (choice < 1 || choice > 4) {
                    try {
                        Sunrise.Write($"{"fl> ":Green}");
                        choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice) {
                            case 1:
                                Cycle newCycle = LogCycleData();
                                tracker.AddCycle(newCycle);
                                choice = 0;
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
            } while (choice != 4);
        }

        static void DisplayStartupLogo() {
            Sunrise.WriteLine($"{"Flo Cycle Tracker (0.1.0)":Blue}");
            Sunrise.WriteLine($"{"---":Blue}");
        }

        // -- Create new entry into database

        static Cycle LogCycleData() {
            Sunrise.WriteLine($"{"\nCreate Entry":Cyan}");
            Sunrise.WriteLine($"{"Use regular language format (e.g. 25 January 2024) \n":DarkGray}");
            
            DateTime[] timeline = GetCycleDateRange();
            FlowLevel flowLevel = GetCycleFlowLevel();

            Sunrise.WriteLine($"\n{"Cycle captured successfully":Green}\n");

            return new Cycle {
                flow = flowLevel,
                startDate = timeline[0],
                endDate = timeline[1]
            };
        }

        static DateTime[] GetCycleDateRange() {
            DateTime start, end;
            while (true) {
                try {
                    Sunrise.Write($"Start Date {"-> ":Green}");
                    start = DateTime.Parse(Console.ReadLine());

                    Sunrise.Write($"  End Date {"-> ":Green}");
                    end = DateTime.Parse(Console.ReadLine());

                    if (start > end) {
                        Sunrise.WriteLine($"\n{"Start date cannot be after the end date":Blue}\n");
                        continue;
                    }
                } 
                catch (Exception) {
                    Sunrise.WriteLine($"\n{"Use the correct date format as shown":Blue}\n");
                    continue;
                }

                return new DateTime[2] { start, end };
            }
        }

        static FlowLevel GetCycleFlowLevel() {
            FlowLevel flow = FlowLevel.Light;
            while (true) {
                try {
                    Sunrise.Write($"\n{"Enter flow level (Light / Moderate / Heavy)":DarkGray}\n");
                    Sunrise.Write($"Flow Level {"-> ":Green}");

                    string input = Console.ReadLine();
                    foreach (FlowLevel option in Enum.GetValues(typeof(FlowLevel))) {
                        if (string.Equals(input, option.ToString(), StringComparison.OrdinalIgnoreCase)) {
                            flow = option;
                        }
                    }
                } 
                catch (Exception) {
                    Sunrise.WriteLine($"\n{"Use one of the options provided":Green}\n");
                    continue;
                }

                return flow;
            }
        }
    }
}
