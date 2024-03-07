namespace FloTracker_Console {

    internal interface IDataStore {

        void SaveData<T>(T data, string fileName); // T is a generic data-type
        T LoadData<T>(string fileName); // T is a generic data-type
    }
}
