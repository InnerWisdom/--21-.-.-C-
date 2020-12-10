using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab4
{
    public partial class FormLocomotive : Form
    {
        private ITransport locomotive;
        public FormLocomotive()
        {
            InitializeComponent();
        }

        private void buttonCreateLocomotive_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            locomotive = new Locomotive(random.Next(100, 300), random.Next(1000, 2000), Color.Green);
            locomotive.SetPosition(random.Next(10, 100), random.Next(10, 100), pictureBoxLocomotive.Width, pictureBoxLocomotive.Height);
            Draw();
        }

        private void buttonCreateElLocomotive_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            locomotive = new ElLocomotive(random.Next(100, 300), random.Next(1000, 2000), Color.Green,
                Color.Red, true, true, true, true, true, true);
            locomotive.SetPosition(random.Next(10, 100), random.Next(10, 100), pictureBoxLocomotive.Width, pictureBoxLocomotive.Height);
            Draw();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            if (locomotive != null)
            {
                string name = (sender as Button).Name;
                switch (name)
                {
                    case "buttonUp":
                        locomotive.MoveTransport(Direction.Up);
                        break;
                    case "buttonDown":
                        locomotive.MoveTransport(Direction.Down);
                        break;
                    case "buttonLeft":
                        locomotive.MoveTransport(Direction.Left);
                        break;
                    case "buttonRight":
                        locomotive.MoveTransport(Direction.Right);
                        break;
                }
                Draw();
            }
        }

        public void SetLocomotive(ITransport locomotive)
        {
            this.locomotive = locomotive;
            Draw();
        }
        private void Draw()
        {
            Bitmap map = new Bitmap(pictureBoxLocomotive.Width, pictureBoxLocomotive.Height);
            Graphics g = Graphics.FromImage(map);
            locomotive.DrawLocomotive(g);
            pictureBoxLocomotive.Image = map;
        }
    }
}
