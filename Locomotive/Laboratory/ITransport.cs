using System.Drawing;

namespace lab3
{
	public interface ITransport
	{
		void SetPosition(int x, int y, int width, int height);
		void MoveTransport(Direction direction);
		void Draw(Graphics g);
	}
}
