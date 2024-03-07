using Newtonsoft.Json;
using System.IO;

namespace FloTracker_Console {

    internal class FileDataStore : IDataStore {

        // Save & Load

        public void SaveData<T>(T data, string fileName) {
            string jsonData = JsonConvert.SerializeObject(data);
            try {
                using (FileStream fileStream = File.OpenWrite(fileName))
                using (StreamWriter writer = new StreamWriter(fileStream)) {
                    writer.Write(jsonData);
                }
            }
            catch (IOException) {
                // TODO: Handle caught IOException
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
                // TODO: Handle caught IOException
            }
            catch (JsonReaderException) {
                // TODO: Handle caught JSON Parsing Exception
            }
            return default;
        }
    }
}
