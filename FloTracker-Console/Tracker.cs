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

        public void AddCycle(Cycle cycle) {
            cycles.Add(cycle);
            SaveData();
        }

        public Cycle CalculateNext() {

            if (cycles.Count < 2) return null;

            int daysTotal = 0;
            for (int i = 0; i < cycles.Count; i++) {
                daysTotal += (cycles[i].startDate - cycles[i - 1].startDate).Days;
            }
            double avgLength = ((double) daysTotal / cycles.Count - 1);

            DateTime predStart = cycles.Last().endDate.AddDays(avgLength);

            return new Cycle {
                startDate = predStart.AddDays(-2),
                endDate = predStart.AddDays(avgLength + 2),
            };
        }

        // -- Save & Load

        private void SaveData() {
            _dataStore.SaveData<List<Cycle>>(cycles, "History.txt");
        }
    }
}
