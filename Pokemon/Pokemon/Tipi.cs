using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pokemon
{
    public class Tipi
    {
        private List<Tipo> tipi { get; set; }
        private string path;
        private static Tipi _instance;
        public static Tipi Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Tipi();
                }
                return _instance;
            }
        }
        private Tipi()
        {
            tipi = new List<Tipo>();
            path = "";
        }

        public void leggi(string path)
        {
            this.path = path;
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
        public Tipo getTipo(string t)
        {
            for (int i = 0; i < tipi.Count; i++)
            {
                if (tipi[i].nome == t)
                {
                    return tipi[i];
                }
            }
            return null;
        }
    }
}
