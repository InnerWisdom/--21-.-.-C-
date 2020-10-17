using System.Drawing;

namespace lab2
{
	class Locomotive
	{
		//4 variant
		private float _startPosX;

		private float _startPosY;

		private int _pictureWidth;

		private int _pictureHeight;

		private readonly int locomotiveWidth = 100;

		private readonly int locomotiveHeight = 60;

		public int MaxSpeed { private set; get; }
		public float Weight { private set; get; }
		public Color MainColor { private set; get; }
		public Color DopColor { private set; get; }
		public bool HasFrontBumper { private set; get; }
		public bool HasFirstHorn { private set; get; }
		public bool HasSecondHorn { private set; get; }
		public bool HasThirdHorn { private set; get; }
		public bool HasUpperPipe { private set; get; }
		public bool HasBackLine { private set; get; }

		public Locomotive(int maxSpeed, float weight, Color mainColor, Color dopColor,
			bool hasFrontBumper, bool hasFirstHorn, bool hasSecondHorn, bool hasThirdHorn, bool hasUpperPipe, bool hasBackLine)
		{
			MaxSpeed = maxSpeed;
			Weight = weight;
			MainColor = mainColor;
			DopColor = dopColor;
			HasFrontBumper = hasFrontBumper;
			HasFirstHorn = hasFirstHorn;
			HasSecondHorn = hasSecondHorn;
			HasThirdHorn = hasThirdHorn;
			HasUpperPipe = hasUpperPipe;
			HasBackLine = hasBackLine;
		}
		public void SetPosition(int x, int y, int frameWidth, int frameHeight)
		{
			_startPosX = x;
			_startPosY = y;

			_pictureWidth = frameWidth;
			_pictureHeight = frameHeight;
		}


		public void MoveTransport(Direction direction)
		{
			float step = MaxSpeed * 100 / Weight;
			switch (direction)
			{
				case Direction.Right:
					if (_startPosX + step < _pictureWidth - locomotiveWidth)
					{
						_startPosX += step;
					}
					break;
				case Direction.Left:
					if (_startPosX - step > 0)
					{
						_startPosX -= step;
					}
					break;
				case Direction.Down:
					if (_startPosY + step < _pictureHeight - locomotiveHeight)
					{
						_startPosY += step;
					}
					break;
				case Direction.Up:
					if (_startPosY - step > 0)
					{
						_startPosY -= step;
					}
					break;
			}

		}


		public void MoveLocomotive(Direction direction)
		{
			float step = MaxSpeed * 100 / Weight;
			switch (direction)
			{
				case Direction.Right:
					if (_startPosX + step < _pictureWidth - locomotiveWidth)
					{
						_startPosX += step;
					}
					break;
				case Direction.Left:
					if (_startPosX - step > 0)
					{
						_startPosX -= step;
					}
					break;
				case Direction.Down:
					if (_startPosY + step < _pictureHeight - locomotiveHeight)
					{
						_startPosY += step;
					}
					break;
				case Direction.Up:
					if (_startPosY - step > 0)
					{
						_startPosY -= step;
					}
					break;
			}

		}


		public void DrawLocomotive(Graphics g)
		{

			Pen pen = new Pen(Color.Black);
			Pen penred = new Pen(Color.Red);
			Brush br = new SolidBrush(DopColor);
			Brush br_main = new SolidBrush(MainColor);
			Brush br_wheels = new SolidBrush(Color.Black);

			//additions
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
			if (HasUpperPipe)
			{
				g.FillEllipse(br, _startPosX + 20, _startPosY - 4, 100, 6);
			}

			//core
			g.DrawEllipse(pen, _startPosX + 20, _startPosY, 80, 40);
			g.FillRectangle(br_main, _startPosX + 80, _startPosY, 40, 40);
			g.FillRectangle(br_main, _startPosX, _startPosY, 40, 40);
			g.FillEllipse(br_main, _startPosX + 20, _startPosY, 80, 40);


			g.DrawRectangle(pen, _startPosX, _startPosY, 40, 40);
			g.DrawRectangle(pen, _startPosX + 80, _startPosY, 40, 40);

			//wheels
			g.FillEllipse(br_wheels, _startPosX + 3, _startPosY + 40, 10, 10);
			g.FillEllipse(br_wheels, _startPosX + 13, _startPosY + 40, 10, 10);
			g.FillEllipse(br_wheels, _startPosX + 23, _startPosY + 40, 10, 10);
			g.FillEllipse(br_wheels, _startPosX + 33, _startPosY + 40, 10, 10);
			g.FillEllipse(br_wheels, _startPosX + 83, _startPosY + 40, 10, 10);
			g.FillEllipse(br_wheels, _startPosX + 93, _startPosY + 40, 10, 10);
			g.FillEllipse(br_wheels, _startPosX + 103, _startPosY + 40, 10, 10);
			g.FillEllipse(br_wheels, _startPosX + 113, _startPosY + 40, 10, 10);
			g.FillEllipse(br_wheels, _startPosX - 3, _startPosY + 38, 135, 10);

		}

	}
}
