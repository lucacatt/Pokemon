using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pokemon
{
    public class Tipi
    {
        public List<Tipo> tipi { get; set; }
        public string path;
        public Tipi(string path)
        {
            tipi = new List<Tipo>();
            this.path = path;
        }

        public void leggi()
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Tipo temp = new Tipo();
                    temp.fromCSV(s);
                    tipi.Add(temp);
                }
            }
        }
    }
}
