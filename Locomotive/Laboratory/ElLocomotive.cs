using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace lab2
{
	public class ElLocomotive : Locomotive
	{
		public Color DopColor { private set; get; }
		public bool HasFrontBumper { private set; get; }

		public bool HasFirstHorn { private set; get; }

		public bool HasSecondHorn { private set; get; }

		public bool HasThirdHorn { private set; get; }
		public bool HasUpperPipe { private set; get; }

		public bool HasBackLine { private set; get; }

		public ElLocomotive(int maxSpeed, float weight, Color mainColor, Color dopColor,
			bool hasFrontBumber, bool hasFirstHorn, bool hasSecondHorn, bool hasThirdHorn, bool hasUpperPipe, bool hasBackLine) :
base(maxSpeed, weight, mainColor, 100, 60)
		{
			MaxSpeed = maxSpeed;
			Weight = weight;
			MainColor = mainColor;
			DopColor = dopColor;
			HasFrontBumper = hasFrontBumber;
			HasFirstHorn = hasFirstHorn;
			HasSecondHorn = hasSecondHorn;
			HasThirdHorn = hasThirdHorn;
			HasUpperPipe = hasUpperPipe;
			HasBackLine = hasBackLine;
		}

		public override void Draw(Graphics g)
		{

			Pen pen = new Pen(Color.Black);
			Pen penred = new Pen(Color.Red);
			Brush br = new SolidBrush(DopColor);
			Brush br_wheels = new SolidBrush(Color.Black);

			if (HasBackLine)
			{
				for (int i = 0; i < 30; i += 3)
				{
					g.FillRectangle(br_wheels, _startPosX + 120 - i, _startPosY + i, 20, 20);
				}
			}

			if (HasFrontBumper)
			{
				g.FillEllipse(br_wheels, _startPosX - 12, _startPosY + 18, 16, 20);
				g.DrawLine(pen, _startPosX - 8, _startPosY + 24, _startPosX + 6, _startPosY - 4);
			}
			if (HasFirstHorn)
			{
				g.DrawLine(penred, _startPosX + 5, _startPosY + 3, _startPosX - 14, _startPosY - 16);
				g.DrawLine(penred, _startPosX - 14, _startPosY - 16, _startPosX + 5, _startPosY - 32);

				g.DrawLine(penred, _startPosX + 5, _startPosY + 3, _startPosX + 24, _startPosY - 16);
				g.DrawLine(penred, _startPosX + 24, _startPosY - 16, _startPosX + 5, _startPosY - 32);

			}

			if (HasSecondHorn)
			{
				g.DrawLine(penred, _startPosX + 5 + 50, _startPosY + 3, _startPosX - 14 + 50, _startPosY - 16);
				g.DrawLine(penred, _startPosX - 14 + 50, _startPosY - 16, _startPosX + 5 + 50, _startPosY - 32);

				g.DrawLine(penred, _startPosX + 5 + 50, _startPosY + 3, _startPosX + 24 + 50, _startPosY - 16);
				g.DrawLine(penred, _startPosX + 24 + 50, _startPosY - 16, _startPosX + 5 + 50, _startPosY - 32);

			}

			if (HasThirdHorn)
			{
				g.DrawLine(penred, _startPosX + 5 + 100, _startPosY + 3, _startPosX - 14 + 100, _startPosY - 16);
				g.DrawLine(penred, _startPosX - 14 + 100, _startPosY - 16, _startPosX + 5 + 100, _startPosY - 32);

				g.DrawLine(penred, _startPosX + 5 + 100, _startPosY + 3, _startPosX + 24 + 100, _startPosY - 16);
				g.DrawLine(penred, _startPosX + 24 + 100, _startPosY - 16, _startPosX + 5 + 100, _startPosY - 32);

			}


			base.Draw(g);

			if (HasUpperPipe)
			{
				g.FillEllipse(br, _startPosX + 20, _startPosY - 4, 100, 6);
			}
		}

	}
}
