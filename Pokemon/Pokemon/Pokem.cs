using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class Pokem
    {
        public string Nome { get; set; }
        public string url { get; set; }
        public Mossa[] mosse { get; set; }
        public Tipo tipo { get; set; }
        private int pointTipo;
    }
}
