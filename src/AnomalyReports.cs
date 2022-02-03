using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightGearApp.src
{
    class AnomalyReports
    {
        public string description;
        public int timeStep;
        public AnomalyReports(string des, int ts)
        {
            description = des;
            timeStep = ts;
        }
    }
}
