using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab4
{
    public partial class LocomotiveConfig : Form
    {
        Vehicle locomotive = null;

        private event Action<Vehicle> eventAddLocomotive;
       
        public LocomotiveConfig()
        {
            InitializeComponent();
            foreach(var item in groupBoxColors.Controls)
            {
                if(item is Panel)
                {
                    ((Panel)item).MouseDown += panelColor_MouseDown;
                }
            }
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }
       
        private void DrawLocomotive()
        {
            if (locomotive != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxLocomotive.Width, pictureBoxLocomotive.Height);
                Graphics gr = Graphics.FromImage(bmp);
                locomotive.SetPosition(12, 30, pictureBoxLocomotive.Width, pictureBoxLocomotive.Height);
                locomotive.DrawTransport(gr);
                pictureBoxLocomotive.Image = bmp;
            }
        }
       
        public void AddEvent(Action<Vehicle> ev)
        {
            if (eventAddLocomotive == null)
            {
                eventAddLocomotive = new Action<Vehicle>(ev);
            }
            else
            {
                eventAddLocomotive += ev;
            }
        }
       
        private void labelLocomotive_MouseDown(object sender, MouseEventArgs e)
        {
            labelLocomotive.DoDragDrop(labelLocomotive.Name, DragDropEffects.Move | DragDropEffects.Copy);
        }
       
        private void labelElLocomotive_MouseDown(object sender, MouseEventArgs e)
        {
            labelElLocomotive.DoDragDrop(labelElLocomotive.Name, DragDropEffects.Move | DragDropEffects.Copy);
        }
       
        private void panelLocomotive_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }
        //fBumper,fHorn,sHorn,tHorn,upperPipe,backLine
        private void panelLocomotive_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "labelLocomotive":
                    locomotive = new Locomotive((int)numericUpDownMaxSpeed.Value, (int)numericUpDownWeight.Value, Color.Green);
                    break;
                case "labelElLocomotive":
                    locomotive = new ElLocomotive((int)numericUpDownMaxSpeed.Value, (int)numericUpDownWeight.Value, Color.Green, Color.Black,  
                        checkBoxFBumper.Checked, checkBoxFHorn.Checked, checkBoxSHorn.Checked, checkBoxTHorn.Checked, checkBoxUpperPipe.Checked, checkBoxBackLine.Checked);
                    break;
            }
            DrawLocomotive();
        }
       
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            ((Panel)sender).DoDragDrop(((Panel)sender).BackColor, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void labelColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void labelMainColor_DragDrop(object sender, DragEventArgs e)
        {
            locomotive?.SetMainColor((Color)(e.Data.GetData(typeof(Color))));
            DrawLocomotive();
        }

        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if(locomotive is ElLocomotive)
            {
                ElLocomotive thisLocomotive = (ElLocomotive)locomotive;
                thisLocomotive.SetDopColor((Color)(e.Data.GetData(typeof(Color))));
                locomotive = thisLocomotive;
                DrawLocomotive();
            }
        }
       
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            eventAddLocomotive?.Invoke(locomotive);
            Close();
        }
    }
}