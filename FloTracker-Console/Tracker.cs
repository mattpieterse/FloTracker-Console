using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloTracker_Console {

    /// <summary>
    /// Class to handle cycle class objects and save systems.
    /// </summary>
    internal class Tracker {

        public List<Cycle> cycles = new List<Cycle>();

        // -- Save & Load

        // TODO: Use asynchronous function to multi-thread and free
        //       memory whilst writing and reading from large files
        // TODO: Use dependency injection to improve testability of
        //       the code-base and flexibility/maintainability

        public void SaveData() {
            try {
                using (var fileStream = File.OpenWrite("History.txt")) {
                    // StreamWriter improves performance
                    using (var writer = new StreamWriter(fileStream)) {
                        writer.Write(JsonConvert.SerializeObject(cycles));
                    }
                }
            }
            catch (IOException) {
                // TODO: Handle uncaught IOException
            }
        }

        public void LoadData() {
            try {
                if (File.Exists("History.txt")) {
                    using (var fileStream = File.OpenRead("History.txt")) {
                        // StreamReader improves performance
                        using (var reader = new StreamReader(fileStream)) {
                            cycles = JsonConvert.DeserializeObject<List<Cycle>>(reader.ReadToEnd());
                        }
                    }
                }
            }
            catch (IOException) {
                // TODO: Handle uncaught IOException
            }
            catch (JsonReaderException) {
                // TODO: Handle uncaught JSON Parsing Exception
            }
        }
    }
}
