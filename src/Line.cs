using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightGearApp
{
    class Line
    {
        public float a;
        public float b;

        public Line(float a, float b)
        {
            this.a = a;
            this.b = b;
        }

        public float f(float x)
        {
            return a * x + b;
        }
    }
}
