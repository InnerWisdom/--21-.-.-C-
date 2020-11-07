using System.Drawing;

namespace lab4
{
	public interface ITransport
	{
		void SetPosition(int x, int y, int width, int height);
		void MoveTransport(Direction direction);
		void Draw(Graphics g);
	}
}
