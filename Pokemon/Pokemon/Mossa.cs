using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class Mossa
    {
        public string nome { get; set; }
        public Tipo tipo { get; set; }
        public int danno { get; set; }
        public string effetto { get; set; }
        public Mossa fromCSV(string csv)
        {
            Mossa m = new Mossa();
            string[] temp = csv.Split('|');
            m.nome = temp[0];
            m.tipo = Tipi.Instance.getTipo(temp[1]);
            m.danno = Convert.ToInt32(temp[2]);
            m.effetto = temp[3];
            return m;
        }
    }
}
