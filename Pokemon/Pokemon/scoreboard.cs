using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class scoreboard
    {
        public string Avversario { get; set; }
        public string Risultato { get; set; }

        public scoreboard()
        {
            Avversario = "";
            Risultato = "";
        }

        public scoreboard(string nome_avversario, string risultato)
        {
            this.Avversario = nome_avversario;
            this.Risultato = risultato;
        }

        public void fromCSV(string csv)
        {
            string[] campi = csv.Split(";");
            Avversario = campi[0];
            Risultato = campi[1];
        }

        public string toCSV()
        {
            return Avversario + ";" + Risultato + ";\n";
        }
    }
}
