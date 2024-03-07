using System;
using System.Collections.Generic;
using System.Linq;

namespace FloTracker_Console {

    internal class Tracker {

        private readonly IDataStore _dataStore;
        public List<Cycle> cycles;

        public Tracker(IDataStore dataStore) {
            _dataStore = dataStore;
            cycles = _dataStore.LoadData<List<Cycle>>("History.txt");
        }

        // -- Class Methods

        // -- Save & Load

        private void SaveData() {
            _dataStore.SaveData<List<Cycle>>(cycles, "History.txt");
        }
    }
}
