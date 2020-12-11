using System;
using System.Drawing;


namespace lab4
{
	public class ElLocomotive : Locomotive, IEquatable<ElLocomotive>
	{
		//4 variant
		public Color DopColor { private set; get; }

		public bool FrontBumper { private set; get; }

		public bool FirstHorn { private set; get; }

		public bool SecondHorn { private set; get; }

		public bool ThirdHorn { private set; get; }
		public bool UpperPipe { private set; get; }

		public bool BackLine { private set; get; }

		public ElLocomotive(int maxSpeed, float weight, Color mainColor, Color dopColor,
			bool frontBumber, bool firstHorn, bool secondHorn, bool thirdHorn, bool upperPipe, bool backLine) :
base(maxSpeed, weight, mainColor, 100, 60)
		{
			MaxSpeed = maxSpeed;
			Weight = weight;
			MainColor = mainColor;
			DopColor = dopColor;
			FrontBumper = frontBumber;
			FirstHorn = firstHorn;
			SecondHorn = secondHorn;
			ThirdHorn = thirdHorn;
			UpperPipe = upperPipe;
			BackLine = backLine;
		}

		public ElLocomotive(string info) : base(info)
		{
			string[] strs = info.Split(separator);
			if (strs.Length == 10)
			{
				MaxSpeed = Convert.ToInt32(strs[0]);
				Weight = Convert.ToInt32(strs[1]);
				MainColor = Color.FromName(strs[2]);
				DopColor = Color.FromName(strs[3]);
				FrontBumper = Convert.ToBoolean(strs[4]);
				FirstHorn = Convert.ToBoolean(strs[5]);
				SecondHorn = Convert.ToBoolean(strs[6]);
				ThirdHorn = Convert.ToBoolean(strs[7]);
				UpperPipe = Convert.ToBoolean(strs[8]);
				BackLine = Convert.ToBoolean(strs[9]);
			}
		}

		public override void DrawLocomotive(Graphics g)
		{

			Pen pen = new Pen(Color.Black);
			Pen penred = new Pen(Color.Red);
			Pen penDop = new Pen(DopColor);
			Brush br = new SolidBrush(DopColor);
			Brush br_wheels = new SolidBrush(Color.Black);

			if (BackLine)
			{
				for (int i = 0; i < 30; i += 3)
				{
					g.FillRectangle(br, _startPosX + 120 - i, _startPosY + i, 20, 20);
				}
			}

			if (FrontBumper)
			{
				g.FillEllipse(br, _startPosX - 12, _startPosY + 18, 16, 20);
				g.DrawLine(penDop, _startPosX - 8, _startPosY + 24, _startPosX + 6, _startPosY - 4);
			}
			if (FirstHorn)
			{
				g.DrawLine(penDop, _startPosX + 5, _startPosY + 3, _startPosX - 14, _startPosY - 16);
				g.DrawLine(penDop, _startPosX - 14, _startPosY - 16, _startPosX + 5, _startPosY - 32);

				g.DrawLine(penDop, _startPosX + 5, _startPosY + 3, _startPosX + 24, _startPosY - 16);
				g.DrawLine(penDop, _startPosX + 24, _startPosY - 16, _startPosX + 5, _startPosY - 32);

			}

			if (SecondHorn)
			{
				g.DrawLine(penDop, _startPosX + 5 + 50, _startPosY + 3, _startPosX - 14 + 50, _startPosY - 16);
				g.DrawLine(penDop, _startPosX - 14 + 50, _startPosY - 16, _startPosX + 5 + 50, _startPosY - 32);

				g.DrawLine(penDop, _startPosX + 5 + 50, _startPosY + 3, _startPosX + 24 + 50, _startPosY - 16);
				g.DrawLine(penDop, _startPosX + 24 + 50, _startPosY - 16, _startPosX + 5 + 50, _startPosY - 32);

			}

			if (ThirdHorn)
			{
				g.DrawLine(penDop, _startPosX + 5 + 100, _startPosY + 3, _startPosX - 14 + 100, _startPosY - 16);
				g.DrawLine(penDop, _startPosX - 14 + 100, _startPosY - 16, _startPosX + 5 + 100, _startPosY - 32);

				g.DrawLine(penDop, _startPosX + 5 + 100, _startPosY + 3, _startPosX + 24 + 100, _startPosY - 16);
				g.DrawLine(penDop, _startPosX + 24 + 100, _startPosY - 16, _startPosX + 5 + 100, _startPosY - 32);

			}


			base.DrawLocomotive(g);

			if (UpperPipe)
			{
				g.FillEllipse(br, _startPosX + 20, _startPosY - 4, 100, 6);
			}
		}

		public void SetDopColor(Color color)
		{
			DopColor = color;
		}

		public override string ToString()
		{
			return $"{base.ToString()}{separator}{DopColor.Name}{separator}{FrontBumper}" +
				$"{separator}{FirstHorn}{separator}{SecondHorn}{separator}{ThirdHorn}{separator}{UpperPipe}{separator}{BackLine}";
		}

		public bool Equals(ElLocomotive otherElLocomotive)
		{
			if (otherElLocomotive == null)
			{
				return false;
			}
			if (GetType().Name != otherElLocomotive.GetType().Name)
			{
				return false;
			}
			if (MaxSpeed != otherElLocomotive.MaxSpeed)
			{
				return false;
			}
			if (Weight != otherElLocomotive.Weight)
			{
				return false;
			}
			if (MainColor != otherElLocomotive.MainColor)
			{
				return false;
			}
			if (DopColor != otherElLocomotive.DopColor)
			{
				return false;
			}
			if (FirstHorn != otherElLocomotive.FirstHorn)
			{
				return false;
			}
			if (SecondHorn != otherElLocomotive.SecondHorn)
			{
				return false;
			}
			if (ThirdHorn != otherElLocomotive.ThirdHorn)
			{
				return false;
			}
			if (UpperPipe != otherElLocomotive.UpperPipe)
			{
				return false;
			}
			if (FrontBumper != otherElLocomotive.FrontBumper)
			{
				return false;
			}
			if (BackLine != otherElLocomotive.BackLine)
			{
				return false;
			}
			return true;
		}

		public override bool Equals(Object obj)
		{
			if (obj == null)
			{
				return false;

			}
			if (!(obj is ElLocomotive elLocomotiveObj))
			{
				return false;
			}
			else
			{
				return Equals(elLocomotiveObj);
			}
		}

	}
}
