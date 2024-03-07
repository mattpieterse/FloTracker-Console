using System;

namespace FloTracker_Console {
    
    internal class Cycle {
        
        // public int UniqueID { get; set; }

        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        // public FlowLevel flow { get; set; }
    }

    internal enum FlowLevel {
        Light,
        Medium,
        Heavy,
    };
}