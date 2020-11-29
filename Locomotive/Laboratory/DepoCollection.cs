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
		readonly Dictionary<string, Depo<Vehicle>> depoStages;

		public List<string> Keys => depoStages.Keys.ToList();

		private readonly int pictureWidth;

		private readonly char separator = ':';

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
			get {
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
		}

		public void LoadData(string filename)
		{
			if (!File.Exists(filename))
			{
				throw new FileNotFoundException();
			}
			string bufferTextFromFile = "";
			using (FileStream fs = new FileStream(filename, FileMode.Open))
			{
				byte[] b = new byte[fs.Length];
				UTF8Encoding temp = new UTF8Encoding(true);
				while (fs.Read(b, 0, b.Length) > 0)
				{
					bufferTextFromFile += temp.GetString(b);
				}
			}
			bufferTextFromFile = bufferTextFromFile.Replace("\r", "");
			var strs = bufferTextFromFile.Split('\n');
			if (strs[0].Contains("DepoCollection"))
			{
				//очищаем записи
				depoStages.Clear();
			}
			else
			{
				//если нет такой записи, то это не те данные
				throw new FormatException("Неверный формат файла");
			}
			Vehicle locomotive = null;
			string key = string.Empty;
			for (int i = 1; i < strs.Length; ++i)
			{
				//идем по считанным записям
				if (strs[i].Contains("Depo"))
				{
					//начинаем новую парковку
					key = strs[i].Split(separator)[1];
					depoStages.Add(key, new Depo<Vehicle>(pictureWidth,
					pictureHeight));
					continue;
				}
				if (string.IsNullOrEmpty(strs[i]))
				{
					continue;
				}
				if (strs[i].Split(separator)[0] == "Locomotive")
				{
					locomotive = new Locomotive(strs[i].Split(separator)[1]);
				}
				else if (strs[i].Split(separator)[0] == "ElLocomotive")
				{
					locomotive = new ElLocomotive(strs[i].Split(separator)[1]);
				}
				if (!(depoStages[key] + locomotive))
				{
					throw new TypeLoadException("Не удалось загрузить локомотив на парковку");
				}
			}

		}

	}
}
