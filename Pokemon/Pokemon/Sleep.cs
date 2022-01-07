using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class Sleep
    {
        public bool isSleep { get; set; }
        public int sleepCount { get; set; }
        public Sleep()
        {
            isSleep = false;
            sleepCount = 5;
        }
    }
}
