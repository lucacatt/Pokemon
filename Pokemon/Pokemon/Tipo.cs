using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class Tipo
    {
        public int id { get; set; }
        public string nome { get; set; }
        public List<String> super;
        public List<String> less;
        public List<String> no;
        public Tipo()
        {

        }
        public void fromCSV(string csv)
        {
            string[] temp = csv.Split(';');
            id = Convert.ToInt32(temp[0]);
            nome = temp[1];
            for (int i = 0; i < temp[2].Split('-').Length; i++)
            {
                super.Add(temp[2].Split('-')[i]);
            }
            for (int i = 0; i < temp[3].Split('-').Length; i++)
            {
                less.Add(temp[2].Split('-')[i]);
            }
            for (int i = 0; i < temp[4].Split('-').Length; i++)
            {
                no.Add(temp[2].Split('-')[i]);
            }
        }
    }
}
