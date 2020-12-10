using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab4
{
    class DepoCollection
    {
        readonly Dictionary<string, Depo<Vehicle>> depoStages;

        public List<string> Keys => depoStages.Keys.ToList();
        private readonly char separator = ':';
        private readonly int pictureWidth;
        private readonly int pictureHeight;

        public DepoCollection(int pictureWidth, int pictureHeight)
        {
            depoStages = new Dictionary<string, Depo<Vehicle>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }

        public void AddDepo(string name)
        {
            if (depoStages.ContainsKey(name))
            {
                return;
            }
            depoStages.Add(name, new Depo<Vehicle>(pictureWidth, pictureHeight));
        }

        public void DelDepo(string ind)
        {
            if (depoStages.ContainsKey(ind))
            {
                depoStages.Remove(ind);
            }
        }

        public Depo<Vehicle> this[string ind]
        {
            get
            {
                if (depoStages.ContainsKey(ind))
                {
                    return depoStages[ind];
                }
                return null;
            }
        }

        public void SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine($"DepoCollection");
                foreach (var level in depoStages)
                {
                    sw.WriteLine($"Depo{separator}{level.Key}");

                    foreach (ITransport locomotive in level.Value)
                    {
                        if (locomotive.GetType().Name == "Locomotive")
                        {
                            sw.Write($"Locomotive{separator}");
                        }
                        if (locomotive.GetType().Name == "ElLocomotive")
                        {
                            sw.Write($"ElLocomotive{separator}");
                        }
                        sw.WriteLine(locomotive);
                    }

                }
            }
        }

        public void LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();
                string key = string.Empty;
                Vehicle locomotive = null;
                if (line.Contains("DepoCollection"))
                {
                    depoStages.Clear();
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        if (line.Contains("Depo"))
                        {
                            key = line.Split(separator)[1];
                            depoStages.Add(key, new Depo<Vehicle>(pictureWidth, pictureHeight));
                            line = sr.ReadLine();
                            continue;
                        }
                        if (string.IsNullOrEmpty(line))
                        {
                            line = sr.ReadLine();
                            continue;
                        }
                        if (line.Split(separator)[0] == "Locomotive")
                        {
                            locomotive = new Locomotive(line.Split(separator)[1]);
                        }
                        else if (line.Split(separator)[0] == "ElLocomotive")
                        {
                            locomotive = new ElLocomotive(line.Split(separator)[1]);
                        }
                        var result = depoStages[key] + locomotive;
                        if (!result)
                        {
                            throw new NullReferenceException();
                        }
                        line = sr.ReadLine();
                    }
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
        }

    }
}
