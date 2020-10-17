using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace lab2
{
	public interface ITransport
	{
		void SetPosition(int x, int y, int width, int height);
		void MoveTransport(Direction direction);
		void Draw(Graphics g);
	}
}
