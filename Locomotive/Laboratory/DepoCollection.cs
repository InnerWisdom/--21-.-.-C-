using System.Collections.Generic;
using System.Linq;

namespace lab4
{
	class DepoCollection
	{
		readonly Dictionary<string, Depo<Vehicle>> depoStages;

		public List<string> Keys => depoStages.Keys.ToList();
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
			get {
				if (depoStages.ContainsKey(ind))
				{
					return depoStages[ind];
				}
				return null;
			}
		}
	}
}
