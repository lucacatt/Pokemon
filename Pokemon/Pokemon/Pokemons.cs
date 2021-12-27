using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pokemon
{
    class Pokemons
    {
        private List<Pokem> pokemon { get; set; }
        public Pokemons() => pokemon = new List<Pokem>();

        public void leggi(string path)
        {
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
        public string getImg(int pos)
        {
            return pokemon[pos].imgFront;
        }
        public int getSize()
        {
            return pokemon.Count;
        }
        public Pokem getPkm(int pos)
        {
            return pokemon[pos];
        }
    }
}
