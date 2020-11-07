using System;
using System.Drawing; 
using System.Windows.Forms; 

namespace lab3
{
	public partial class FormDepo : Form
	{
		private PictureBox pictureBoxDepo;
		private GroupBox groupBoxDepo;
		private Button buttonTakeLocomotive;
		private Label label1;
		private MaskedTextBox maskedTextBox;
		private Button buttonSetLocomotive;
		private Button buttonSetElLocomotive;

		private readonly Depo<Locomotive> depo;

		public FormDepo()
		{
			InitializeComponent();
			depo = new Depo<Locomotive>(pictureBoxDepo.Width,
				pictureBoxDepo.Height);
			Draw();
		}

		private void Draw() 
		{ 
			Bitmap bmp = new Bitmap(pictureBoxDepo.Width,
				pictureBoxDepo.Height);
			Graphics gr = Graphics.FromImage(bmp);
			depo.Draw(gr);
			pictureBoxDepo.Image = bmp;
		}


		private void buttonTakeLocomotive_Click(object sender, EventArgs e)
		{
			if (maskedTextBox.Text != "")
			{
				var locomotive = depo - Convert.ToInt32(maskedTextBox.Text);
				if (locomotive != null)
				{
					FormLocomotive form = new FormLocomotive();
					form.SetLocomotive(locomotive);
					form.ShowDialog();
				}
				Draw();
			}
		}

		private void buttonSetLocomotive_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				var locomotive = new Locomotive(100, 100, dialog.Color);
				if (depo + locomotive)
				{
				Draw();
				}
				else{
				MessageBox.Show("Депо переполнено");
				}
			}
		}

		private void buttonSetElLocomotive_Click_1(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				ColorDialog dialogDop = new ColorDialog();
				if (dialogDop.ShowDialog() == DialogResult.OK)
				{
					var locomotive = new ElLocomotive(100, 1000, dialog.Color, dialogDop.Color, true, true, true, true, true, true);
					if (depo + locomotive)
					{
						Draw();
					}
					else
					{
						MessageBox.Show("Депо переполнено");
					}
				}
			}
		}

		private void InitializeComponent()
		{
			this.pictureBoxDepo = new System.Windows.Forms.PictureBox();
			this.groupBoxDepo = new System.Windows.Forms.GroupBox();
			this.buttonTakeLocomotive = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.buttonSetLocomotive = new System.Windows.Forms.Button();
			this.buttonSetElLocomotive = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDepo)).BeginInit();
			this.groupBoxDepo.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxDepo
			// 
			this.pictureBoxDepo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBoxDepo.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxDepo.Name = "pictureBoxDepo";
			this.pictureBoxDepo.Size = new System.Drawing.Size(944, 561);
			this.pictureBoxDepo.TabIndex = 0;
			this.pictureBoxDepo.TabStop = false;
			// 
			// groupBoxDepo
			// 
			this.groupBoxDepo.Controls.Add(this.buttonTakeLocomotive);
			this.groupBoxDepo.Controls.Add(this.label1);
			this.groupBoxDepo.Controls.Add(this.maskedTextBox);
			this.groupBoxDepo.Location = new System.Drawing.Point(811, 140);
			this.groupBoxDepo.Name = "groupBoxDepo";
			this.groupBoxDepo.Size = new System.Drawing.Size(125, 86);
			this.groupBoxDepo.TabIndex = 11;
			this.groupBoxDepo.TabStop = false;
			this.groupBoxDepo.Text = "Забрать состав";
			// 
			// buttonTakeLocomotive
			// 
			this.buttonTakeLocomotive.Location = new System.Drawing.Point(29, 66);
			this.buttonTakeLocomotive.Name = "buttonTakeLocomotive";
			this.buttonTakeLocomotive.Size = new System.Drawing.Size(72, 19);
			this.buttonTakeLocomotive.TabIndex = 2;
			this.buttonTakeLocomotive.Text = "Забрать";
			this.buttonTakeLocomotive.UseVisualStyleBackColor = true;
			this.buttonTakeLocomotive.Click += new System.EventHandler(this.buttonTakeLocomotive_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Место";
			// 
			// maskedTextBox
			// 
			this.maskedTextBox.Location = new System.Drawing.Point(85, 35);
			this.maskedTextBox.Name = "maskedTextBox";
			this.maskedTextBox.Size = new System.Drawing.Size(28, 20);
			this.maskedTextBox.TabIndex = 0;
			// 
			// buttonSetLocomotive
			// 
			this.buttonSetLocomotive.Location = new System.Drawing.Point(811, 12);
			this.buttonSetLocomotive.Name = "buttonSetLocomotive";
			this.buttonSetLocomotive.Size = new System.Drawing.Size(125, 39);
			this.buttonSetLocomotive.TabIndex = 12;
			this.buttonSetLocomotive.Text = "Создать локомотив";
			this.buttonSetLocomotive.UseVisualStyleBackColor = true;
			this.buttonSetLocomotive.Click += new System.EventHandler(this.buttonSetLocomotive_Click);
			// 
			// buttonSetElLocomotive
			// 
			this.buttonSetElLocomotive.Location = new System.Drawing.Point(811, 57);
			this.buttonSetElLocomotive.Name = "buttonSetElLocomotive";
			this.buttonSetElLocomotive.Size = new System.Drawing.Size(125, 39);
			this.buttonSetElLocomotive.TabIndex = 13;
			this.buttonSetElLocomotive.Text = "Создать электровоз";
			this.buttonSetElLocomotive.UseVisualStyleBackColor = true;
			this.buttonSetElLocomotive.Click += new System.EventHandler(this.buttonSetElLocomotive_Click_1);
			// 
			// FormParking
			// 
			this.ClientSize = new System.Drawing.Size(944, 561);
			this.Controls.Add(this.buttonSetElLocomotive);
			this.Controls.Add(this.buttonSetLocomotive);
			this.Controls.Add(this.groupBoxDepo);
			this.Controls.Add(this.pictureBoxDepo);
			this.Name = "FormDepo";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDepo)).EndInit();
			this.groupBoxDepo.ResumeLayout(false);
			this.groupBoxDepo.PerformLayout();
			this.ResumeLayout(false);

		}

	}
}
