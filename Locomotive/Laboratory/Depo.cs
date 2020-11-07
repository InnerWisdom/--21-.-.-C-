using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
	/// <summary>     /// Параметризованный класс для хранения набора объектов от интерфейса ITransport     /// </summary>     /// <typeparam name="T"></typeparam> 
	public class Depo<T> where T : class, ITransport
	{    
		private readonly T[] _places;        
		private readonly int pictureWidth;     
		private readonly int pictureHeight;  
		private readonly int _placeSizeWidth = 310;     
		private readonly int _placeSizeHeight = 100;

		public Depo(int picWidth, int picHeight)
		{
			this.pictureWidth = picWidth;
			this.pictureHeight = picHeight;
			int width = picWidth / _placeSizeWidth;
			int height = picHeight / _placeSizeHeight;
			_places = new T[width * height];
			
		}

		public static bool operator +(Depo<T> p, T ElLocomotive)
		{
			int margin = 45;
			int rowsCount = p.pictureHeight / p._placeSizeHeight;
			for (int i = 0; i < p._places.Length; i++)
			{
				if (p._places[i] == null)
				{
					ElLocomotive.SetPosition(margin-25 + p._placeSizeWidth * (i / rowsCount), margin + p._placeSizeHeight * (i % rowsCount),
						p.pictureWidth, p.pictureHeight);
					p._places[i] = ElLocomotive;
					return true;
				}
			}
			return false;
		}

		public static T operator -(Depo<T> p, int index)
		{
			if (index >= 0 && index < p._places.Length && p._places[index] != null)
			{
				T temp = p._places[index];
				p._places[index] = null;
				return temp;
			}
			return null;
		}

		public void Draw(Graphics g)
		{
			DrawMarking(g);
			for (int i = 0; i < _places.Length; i++)
			{
				_places[i]?.Draw(g);
			}
		}

		private void DrawMarking(Graphics g)
		{
			Pen pen = new Pen(Color.Black, 3);

			for (int i = 0; i < pictureWidth / _placeSizeWidth; i++)
			{
				for (int j = 0; j < pictureHeight / _placeSizeHeight + 1; ++j)
				{
					g.DrawLine(pen, i * _placeSizeWidth, (j) * _placeSizeHeight, i * _placeSizeWidth + _placeSizeWidth / 2, (j )* _placeSizeHeight);                 } 

					g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, (pictureHeight / _placeSizeHeight) * _placeSizeHeight);
				}
			}
		}

	}
