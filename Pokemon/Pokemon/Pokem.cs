using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pokemon
{
    public class Pokem
    {
        public string Nome { get; set; }
        public List<Tipo> Tipo { get; set; }
        public int Hp { get; set; }
        public int remHp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public List<Mossa> Mosse { get; set; }
        public string imgFront { get; set; }
        public string imgBack { get; set; }
        public int Index { get; set; }
        public Paralysis p { get; set; }
        public Burn b { get; set; }
        public Sleep s { get; set; }
        public Pokem()
        {
            Nome = "";
            Hp = 0;
            Atk = 0;
            Def = 0;
            Tipo = new List<Tipo>();
            Mosse = new List<Mossa>();
            imgFront = "";
            imgBack = "";
            Index = -1;
            p = new Paralysis();
            b = new Burn();
            s = new Sleep();
        }

        public Pokem(string nome, int hp)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "pokemon.txt";
            Nome = nome;
            remHp = hp;
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Pokem temp = new Pokem();
                    temp.fromCSV(s);
                    if (temp.Nome == nome)
                    {
                        imgFront = temp.imgFront;
                        Hp = temp.Hp;
                        Atk = temp.Atk;
                        Def = temp.Def;
                    }
                }
            }
            Tipo = new List<Tipo>();
            Mosse = new List<Mossa>();
            imgBack = "";
            Index = -1;
        }

        public Mossa getMossa(int pos)
        {
            return Mosse[pos];
        }

        public void fromCSV(string csv)
        {
            string[] temp = csv.Split(';');
            Nome = temp[0];
            for (int i = 0; i < temp[1].Split('/').Length; i++)
            {
                Tipo.Add(Tipi.Instance.getTipo(temp[1].Split('/')[i]));
            }
            Hp = Convert.ToInt32(temp[2]);
            remHp = Hp;
            Atk = Convert.ToInt32(temp[3]);
            Def = Convert.ToInt32(temp[4]);
            for (int i = 0; i < temp[5].Split('/').Length - 1; i++)
            {
                Mossa m = new Mossa();
                string t = temp[5].Split('/')[i];
                Mosse.Add(m.fromCSV(t));
            }
            imgFront = temp[6];
            imgBack = temp[7];
        }

        internal string toCSV()
        {
            return Nome + ";" + Hp + ";" + imgBack + ";";
        }
    }
}
