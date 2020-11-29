using System;
using System.Collections.Generic;
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
	}
}
