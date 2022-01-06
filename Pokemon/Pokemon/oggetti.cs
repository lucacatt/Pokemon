using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pokemon
{
    public class oggetti
    {
        private List<oggetto> objects { get; set; }
        public oggetti() => objects = new List<oggetto>();

        public void leggi(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    oggetto temp = new oggetto();
                    temp.fromCSV(s);
                    objects.Add(temp);
                }
            }
        }

        public int getSize()
        {
            return objects.Count;
        }
        public oggetto getobj(int pos)
        {
            return objects[pos];
        }

        public void addObj(oggetto obj)
        {
            objects.Add(obj);
        }

        public void remove_obj(int pos)
        {
            objects.RemoveAt(pos);
        }

        public List<oggetto> getObj()
        {
            return objects;
        }
        public void setObj(List<oggetto> objects)
        {
            this.objects = objects;
        }
    }
}
