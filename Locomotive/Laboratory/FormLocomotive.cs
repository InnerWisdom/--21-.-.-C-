using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab1
{
    public partial class FormLocomotive : Form
    {
        private Locomotive locomotive;
        public FormLocomotive()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            locomotive = new Locomotive(random.Next(100, 300), random.Next(1000, 2000), Color.Green, Color.Red, true, true, true, true, true, true);
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
                        locomotive.MoveLocomotive(Direction.Up);
                        break;
                    case "buttonDown":
                        locomotive.MoveLocomotive(Direction.Down);
                        break;
                    case "buttonLeft":
                        locomotive.MoveLocomotive(Direction.Left);
                        break;
                    case "buttonRight":
                        locomotive.MoveLocomotive(Direction.Right);
                        break;
                }
                Draw();
            }
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
