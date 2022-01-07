using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class Burn
    {
        public bool isBurned { get; set; }
        public int burnCount { get; set; }
        public int dmg { get; set; }
        public Burn()
        {
            isBurned = false;
            burnCount = 5;
            dmg = 5;
        }
    }
}
