using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace lab4
{
	public class ElLocomotive : Locomotive
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

		public override void DrawTransport(Graphics g)
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


			base.DrawTransport(g);

			if (UpperPipe)
			{
				g.FillEllipse(br, _startPosX + 20, _startPosY - 4, 100, 6);
			}
		}

		public void SetDopColor(Color color)
		{
			DopColor = color;
		}


	}
}
