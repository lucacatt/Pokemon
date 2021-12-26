using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pokemon
{
    class Pokemons
    {
        private List<Pokem> pokemon { get; set; }
        private string path;
        public Pokemons()
        {
            pokemon = new List<Pokem>();
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
                    Pokem temp = new Pokem();
                    temp.fromCSV(s);
                    pokemon.Add(temp);
                }
            }
        }
    }
}
