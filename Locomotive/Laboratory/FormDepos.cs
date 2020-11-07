using System;
using System.Drawing; 
using System.Windows.Forms; 

namespace lab4
{
	public partial class FormDepos : Form
	{
		private readonly DepoCollection depoCollection;

		private PictureBox pictureBoxDepo;
		private GroupBox groupBoxDepo;
		private Button buttonTakeLocomotive;
		private Label label1;
		private MaskedTextBox maskedTextBox;

		private Button buttonSetLocomotive;
		private Button buttonSetElLocomotive;
		private ListBox listBoxDepos;
		private Button buttonAddDepo;
		private Button buttonDelDepo;
		private Label label2;
		private TextBox textBoxNewDepoName;

		public FormDepos()
		{
			InitializeComponent();
			depoCollection = new DepoCollection(pictureBoxDepo.Width, pictureBoxDepo.Height);
		}

		private void ReloadLevels()
		{
			int index = listBoxDepos.SelectedIndex;

			listBoxDepos.Items.Clear();
			for (int i = 0; i < depoCollection.Keys.Count; i++)
			{
				listBoxDepos.Items.Add(depoCollection.Keys[i]);
			}

			if (listBoxDepos.Items.Count > 0 && (index == -1 || index >= listBoxDepos.Items.Count))
			{
				listBoxDepos.SelectedIndex = 0;
			}
			else if (listBoxDepos.Items.Count > 0 && index > -1 && index < listBoxDepos.Items.Count)
			{
				listBoxDepos.SelectedIndex = index;
			}
		}

		private void Draw() 
		{
			Bitmap bmp = new Bitmap(pictureBoxDepo.Width, pictureBoxDepo.Height);
			Graphics gr = Graphics.FromImage(bmp);
			if (listBoxDepos.SelectedIndex > -1)
			{
				depoCollection[listBoxDepos.SelectedItem.ToString()].Draw(gr);
			}
			else
			{
				gr.FillRectangle(new SolidBrush(Color.Transparent), 0, 0, pictureBoxDepo.Width, pictureBoxDepo.Height);
			}
			pictureBoxDepo.Image = bmp;
		}

		private void buttonAddDepo_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBoxNewDepoName.Text))
			{
				depoCollection.AddDepo(textBoxNewDepoName.Text);
				ReloadLevels();
				Draw();
			}
			else
			{
				MessageBox.Show("Введите название депо", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonDelDepo_Click(object sender, EventArgs e)
		{
			if (listBoxDepos.SelectedIndex > -1)
			{
				if (MessageBox.Show($"Удалить депо {listBoxDepos.SelectedItem.ToString()}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					depoCollection.DelDepo(listBoxDepos.SelectedItem.ToString());
					ReloadLevels();
					Draw();
				}
			}
		}


		private void buttonTakeLocomotive_Click(object sender, EventArgs e)
		{
			if (listBoxDepos.SelectedIndex > -1 && maskedTextBox.Text != "")
			{
				var locomotive = depoCollection[listBoxDepos.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBox.Text);
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
			if (listBoxDepos.SelectedIndex > -1)
			{
				ColorDialog dialog = new ColorDialog();
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					var locomotive = new Locomotive(100, 1000, dialog.Color);
					if (depoCollection[listBoxDepos.SelectedItem.ToString()] + locomotive)
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
		private void listBoxParkings_SelectedIndexChanged(object sender, EventArgs e)
		{
			Draw();
		}
		private void buttonSetElLocomotive_Click_1(object sender, EventArgs e)
		{
			if (listBoxDepos.SelectedIndex > -1)
			{
				ColorDialog dialog = new ColorDialog();
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					ColorDialog dialogDop = new ColorDialog();
					if (dialogDop.ShowDialog() == DialogResult.OK)
					{
						var locomotive = new ElLocomotive(100, 1000, dialog.Color, dialogDop.Color, true, true, true, true, true, true);
						if (depoCollection[listBoxDepos.SelectedItem.ToString()] + locomotive)
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
			this.listBoxDepos = new System.Windows.Forms.ListBox();
			this.buttonAddDepo = new System.Windows.Forms.Button();
			this.buttonDelDepo = new System.Windows.Forms.Button();
			this.textBoxNewDepoName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
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
			this.groupBoxDepo.Location = new System.Drawing.Point(811, 407);
			this.groupBoxDepo.Name = "groupBoxDepo";
			this.groupBoxDepo.Size = new System.Drawing.Size(125, 106);
			this.groupBoxDepo.TabIndex = 11;
			this.groupBoxDepo.TabStop = false;
			this.groupBoxDepo.Text = "Забрать состав";
			// 
			// buttonTakeLocomotive
			// 
			this.buttonTakeLocomotive.Location = new System.Drawing.Point(29, 66);
			this.buttonTakeLocomotive.Name = "buttonTakeLocomotive";
			this.buttonTakeLocomotive.Size = new System.Drawing.Size(72, 29);
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
			this.buttonSetLocomotive.Location = new System.Drawing.Point(811, 279);
			this.buttonSetLocomotive.Name = "buttonSetLocomotive";
			this.buttonSetLocomotive.Size = new System.Drawing.Size(125, 39);
			this.buttonSetLocomotive.TabIndex = 12;
			this.buttonSetLocomotive.Text = "Создать локомотив";
			this.buttonSetLocomotive.UseVisualStyleBackColor = true;
			this.buttonSetLocomotive.Click += new System.EventHandler(this.buttonSetLocomotive_Click);
			// 
			// buttonSetElLocomotive
			// 
			this.buttonSetElLocomotive.Location = new System.Drawing.Point(811, 324);
			this.buttonSetElLocomotive.Name = "buttonSetElLocomotive";
			this.buttonSetElLocomotive.Size = new System.Drawing.Size(125, 39);
			this.buttonSetElLocomotive.TabIndex = 13;
			this.buttonSetElLocomotive.Text = "Создать электровоз";
			this.buttonSetElLocomotive.UseVisualStyleBackColor = true;
			this.buttonSetElLocomotive.Click += new System.EventHandler(this.buttonSetElLocomotive_Click_1);
			// 
			// listBoxDepos
			// 
			this.listBoxDepos.FormattingEnabled = true;
			this.listBoxDepos.Location = new System.Drawing.Point(810, 93);
			this.listBoxDepos.Name = "listBoxDepos";
			this.listBoxDepos.Size = new System.Drawing.Size(126, 121);
			this.listBoxDepos.TabIndex = 14;
			this.listBoxDepos.SelectedIndexChanged += new System.EventHandler(this.listBoxParkings_SelectedIndexChanged);
			// 
			// buttonAddDepo
			// 
			this.buttonAddDepo.Location = new System.Drawing.Point(822, 50);
			this.buttonAddDepo.Name = "buttonAddDepo";
			this.buttonAddDepo.Size = new System.Drawing.Size(90, 34);
			this.buttonAddDepo.TabIndex = 15;
			this.buttonAddDepo.Text = "Добавить";
			this.buttonAddDepo.UseVisualStyleBackColor = true;
			this.buttonAddDepo.Click += new System.EventHandler(this.buttonAddDepo_Click);
			// 
			// buttonDelDepo
			// 
			this.buttonDelDepo.Location = new System.Drawing.Point(828, 228);
			this.buttonDelDepo.Name = "buttonDelDepo";
			this.buttonDelDepo.Size = new System.Drawing.Size(96, 36);
			this.buttonDelDepo.TabIndex = 16;
			this.buttonDelDepo.Text = "Удалить";
			this.buttonDelDepo.UseVisualStyleBackColor = true;
			this.buttonDelDepo.Click += new System.EventHandler(this.buttonDelDepo_Click);
			// 
			// textBoxNewDepoName
			// 
			this.textBoxNewDepoName.Location = new System.Drawing.Point(820, 22);
			this.textBoxNewDepoName.Name = "textBoxNewDepoName";
			this.textBoxNewDepoName.Size = new System.Drawing.Size(103, 20);
			this.textBoxNewDepoName.TabIndex = 17;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(843, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 18;
			this.label2.Text = "Депо:";
			// 
			// FormDepo
			// 
			this.ClientSize = new System.Drawing.Size(944, 561);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxNewDepoName);
			this.Controls.Add(this.buttonDelDepo);
			this.Controls.Add(this.buttonAddDepo);
			this.Controls.Add(this.listBoxDepos);
			this.Controls.Add(this.buttonSetElLocomotive);
			this.Controls.Add(this.buttonSetLocomotive);
			this.Controls.Add(this.groupBoxDepo);
			this.Controls.Add(this.pictureBoxDepo);
			this.Name = "FormDepo";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDepo)).EndInit();
			this.groupBoxDepo.ResumeLayout(false);
			this.groupBoxDepo.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	
	}
}
