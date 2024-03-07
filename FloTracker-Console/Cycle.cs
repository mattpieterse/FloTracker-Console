using System;

namespace FloTracker_Console {
    
    internal class Cycle {
        public string ID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public FlowLevel flow { get; set; }
    }

    internal enum FlowLevel {
        Light,
        Moderate,
        Heavy,
    };
}