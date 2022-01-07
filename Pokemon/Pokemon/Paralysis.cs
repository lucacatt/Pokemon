using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class Paralysis
    {
        public bool isPar { get; set; }
        public int parCount { get; set; }
        public Paralysis()
        {
            isPar = false;
            parCount = 5;
        }
    }
}
