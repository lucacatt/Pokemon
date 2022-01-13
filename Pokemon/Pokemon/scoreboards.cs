using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pokemon
{
    class scoreboards
    {
        private List<scoreboard> scores;
        private string path;

        public scoreboards()
        {
            scores = new List<scoreboard>();
            path = AppDomain.CurrentDomain.BaseDirectory + "scores.txt";
            scores = leggi();
        }

        public List<scoreboard> getList()
        {
            return scores;
        }

        public List<scoreboard> leggi()
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    scoreboard temp = new scoreboard();
                    temp.fromCSV(s);
                    scores.Add(temp);
                }
            }
            return scores;
        }

        public void scrivi()
        {
            string str = "";
            for (int i = 0; i < scores.Count; i++)
            {
                str += scores[i].toCSV();
            }
            File.WriteAllText(path, str);
        }

        public void aggiungiScore(scoreboard score)
        {
            scores.Add(score);
        }

        public int getSize()
        {
            return scores.Count;
        }

        public scoreboard getPos(int pos)
        {
            return scores[pos];
        }

        public string getNome_Avversario(int pos)
        {
            return scores[pos].Avversario;
        }

        public string getRisultato(int pos)
        {
            return scores[pos].Risultato;
        }
    }
}
