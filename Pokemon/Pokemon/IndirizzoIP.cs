using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class IndirizzoIP
    {
        public string Nome { get; set; }
        public string Ip { get; set; }

        public IndirizzoIP()
        {
            Nome = "";
            Ip = "";
        }

        public IndirizzoIP(string nome, string ip)
        {
            Nome = nome;
            Ip = ip;
        }

        public void fromCSV(string csv)
        {
            string[] campi = csv.Split(";");
            Nome = campi[0];
            Ip = campi[1];
        }

        public string toCSV()
        {
            return Nome + ";" + Ip + ";\n";
        }
    }
}
