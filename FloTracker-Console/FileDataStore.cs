using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloTracker_Console {

    internal class FileDataStore : IDataStore {

        // Save & Load Functions

        public void SaveData<T>(T data, string fileName) {
            string jsonData = JsonConvert.SerializeObject(data);
            try {
                using (FileStream fileStream = File.OpenWrite(fileName))
                using (StreamWriter writer = new StreamWriter(fileStream)) {
                    writer.Write(jsonData);
                }
            }
            catch (IOException) {
                // TODO: Handle uncaught IOException
            }
        }
        

        public T LoadData<T>(string fileName) {
            try {
                if (File.Exists(fileName)) {
                    using (FileStream fileStream = File.OpenRead(fileName))
                    using (StreamReader reader = new StreamReader(fileStream)) {
                        string jsonData = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<T>(jsonData);
                    }
                } else {
                    return default;
                }
            }
            catch (IOException) {
                // TODO: Handle uncaught IOException
            }
            catch (JsonReaderException) {
                // TODO: Handle uncaught JSON Parsing Exception
            }
            return default;
        }
    }
}
