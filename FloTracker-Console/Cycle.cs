using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloTracker_Console {
    
    /// <summary>
    /// Class to store cycle/period attribute data.
    /// </summary>
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