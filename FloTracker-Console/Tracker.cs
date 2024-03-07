using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloTracker_Console {

    internal class Tracker {

        private readonly IDataStore _dataStore;
        public List<Cycle> cycles;

        public Tracker(IDataStore dataStore) {
            _dataStore = dataStore;
            cycles = _dataStore.LoadData<List<Cycle>>("History.txt");
        }
    }
}
