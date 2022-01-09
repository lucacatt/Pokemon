using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pokemon
{
    public class IndirizziIP
    {
        private List<IndirizzoIP> indirizziIP { get; set; }
        private string path;

        public IndirizziIP()
        {
            indirizziIP = new List<IndirizzoIP>();
            path = AppDomain.CurrentDomain.BaseDirectory + "ip.txt";
        }

        public void leggi()
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    IndirizzoIP temp = new IndirizzoIP();
                    temp.fromCSV(s);
                    indirizziIP.Add(temp);
                }
            }
        }

        public void scrivi()
        {
            string str = "";
            for (int i = 0; i < indirizziIP.Count; i++)
            {
                str += indirizziIP[i].toCSV();
            }
            File.WriteAllText(path, str);
        }

        public void aggiungiIndirizzo(IndirizzoIP indirizzo)
        {
            indirizziIP.Add(indirizzo);
        }

        public int getSize()
        {
            return indirizziIP.Count;
        }

        public IndirizzoIP getPos(int pos)
        {
            return indirizziIP[pos];
        }

        public string getNome(int pos)
        {
            return indirizziIP[pos].Nome;
        }

        public string getIndirizzo(int pos)
        {
            return indirizziIP[pos].Ip;
        }

        public bool contains(IndirizzoIP ip)
        {
            if (indirizziIP.Contains(ip))
                return true;
            else
                return false;
        }
    }
}
