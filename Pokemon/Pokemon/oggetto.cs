using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pokemon
{
    public class oggetto
    {
        public string Nome { get; set; }
        public string Effetto { get; set; }
        public int Quantita { get; set; }
        public oggetto()
        {
            Nome = "";
            Effetto = "";
            Quantita = 0;
        }

        //public oggetto(string nome, int hp)
        //{

        //    string path = AppDomain.CurrentDomain.BaseDirectory + "pokemon.txt";
        //    Nome = nome;
        //    remHp = hp;
        //    using (StreamReader sr = File.OpenText(path))
        //    {
        //        string s = "";
        //        while ((s = sr.ReadLine()) != null)
        //        {
        //            Pokem temp = new Pokem();
        //            temp.fromCSV(s);
        //            if (temp.Nome == nome)
        //            {
        //                imgFront = temp.imgFront;
        //                Hp = temp.Hp;
        //                Atk = temp.Atk;
        //                Def = temp.Def;
        //            }
        //        }
        //    }
        //    Tipo = new List<Tipo>();
        //    Mosse = new List<Mossa>();
        //    imgBack = "";
        //}

        public void fromCSV(string csv)
        {
            string[] temp = csv.Split(';');
            Nome = temp[0];
            Effetto = temp[1];
            Quantita = Convert.ToInt32(temp[2]);
        }

        internal string toCSV()
        {
            return Nome + ";" + Effetto + ";" + Quantita + ";";
        }
    }
}
