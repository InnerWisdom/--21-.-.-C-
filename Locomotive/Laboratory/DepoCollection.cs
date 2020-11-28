using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
	class DepoCollection
	{
		readonly Dictionary<string, Depo<Vehicle>> parkingStages;

		public List<string> Keys => parkingStages.Keys.ToList();

		private readonly int pictureWidth;

		private readonly char separator = ':';

		private readonly int pictureHeight;

		public DepoCollection(int pictureWidth, int pictureHeight)
		{
			parkingStages = new Dictionary<string, Depo<Vehicle>>();
			this.pictureWidth = pictureWidth;
			this.pictureHeight = pictureHeight;
		}

		public void AddDepo(string name)
		{
			if (parkingStages.ContainsKey(name))
			{
				return;
			}
			parkingStages.Add(name, new Depo<Vehicle>(pictureWidth, pictureHeight));
		}

		public void DelParking(string ind)
		{
			if (parkingStages.ContainsKey(ind))
			{
				parkingStages.Remove(ind);
			}
		}

		public Depo<Vehicle> this[string ind]
		{
			get {
				if (parkingStages.ContainsKey(ind))
				{
					return parkingStages[ind];
				}
				return null;
			}
		}

		public bool SaveData(string filename)
		{
			if (File.Exists(filename))
			{
				File.Delete(filename);
			}
			using (StreamWriter sw = new StreamWriter(filename))
			{
				sw.WriteLine($"DepoCollection");
				foreach (var level in parkingStages)
				{
					sw.WriteLine($"Depo{separator}{level.Key}");
					ITransport locomotive = null;
					for (int i = 0; (locomotive = level.Value.GetNext(i)) != null; i++)
					{
						if (locomotive != null)
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
			return true;
		}

		public bool LoadData(string filename)
		{
			if (!File.Exists(filename))
			{
				return false;
			}
			using (StreamReader sr = new StreamReader(filename))
			{
				string line = sr.ReadLine();
				string key = string.Empty;
				Locomotive locomotive = null;
				if (line.Contains("DepoCollection"))
				{
					parkingStages.Clear();
					line = sr.ReadLine();
					while (line != null)
					{
						if (line.Contains("Depo"))
						{
							key = line.Split(separator)[1];
							parkingStages.Add(key, new Depo<Vehicle>(pictureWidth, pictureHeight));
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
						var result = parkingStages[key] + locomotive;
						if (!result)
						{
							return false;
						}
						line = sr.ReadLine();
					}
					return true;
				}
				return false;
			}

		}

	}
}
