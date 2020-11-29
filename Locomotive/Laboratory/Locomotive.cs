using System.Drawing;

namespace lab4
{
	public class Locomotive : Vehicle
	{
		protected readonly int locomotiveWidth = 90;
		protected readonly int locomotiveHeight = 50;
		public Locomotive(int maxSpeed, float weight, Color mainColor)
		{
			MaxSpeed = maxSpeed;
			Weight = weight;
			MainColor = mainColor;
		}
		protected Locomotive(int maxSpeed, float weight, Color mainColor, int carWidth, int carHeight)
		{
			MaxSpeed = maxSpeed;
			Weight = weight;
			MainColor = mainColor;
			this.locomotiveWidth = carWidth;
			this.locomotiveHeight = carHeight;
		}
		public override void MoveTransport(Direction direction)
		{
			float step = MaxSpeed * 100 / Weight;
			switch (direction)
			{
				// вправо
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
		public override void DrawTransport(Graphics g)
		{
			Pen pen = new Pen(Color.Black);
			Brush br_main = new SolidBrush(MainColor);
			Brush br_wheels = new SolidBrush(Color.Black);

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
