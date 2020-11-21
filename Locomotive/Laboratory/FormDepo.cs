using System;
using System.Drawing; 
using System.Windows.Forms; 

namespace lab4
{
	public partial class FormDepo : Form
	{
		private readonly DepoCollection depoCollection;

		private PictureBox pictureBoxDepo;
		private GroupBox groupBoxDepo;
		private Button buttonTakeLocomotive;
		private Label labelPlace;
		private MaskedTextBox maskedTextBox;

		private Button buttonSetLocomotive;
		private ListBox listBoxDepo;
		private Button buttonAddDepo;
		private Button buttonDelDepo;
		private Label labelDepo;
		private TextBox textBoxNewLevelName;

		public FormDepo()
		{
			InitializeComponent();
			depoCollection = new DepoCollection(pictureBoxDepo.Width, pictureBoxDepo.Height);
			Draw();
		}

		private void ReloadLevels()
		{
			int index = listBoxDepo.SelectedIndex;
			listBoxDepo.Items.Clear();
			for (int i = 0; i < depoCollection.Keys.Count; i++)
			{
				listBoxDepo.Items.Add(depoCollection.Keys[i]);
			}
			if (listBoxDepo.Items.Count > 0 && (index == -1 || index >= listBoxDepo.Items.Count))
			{
				listBoxDepo.SelectedIndex = 0;
			}
			else if (listBoxDepo.Items.Count > 0 && index > -1 && index < listBoxDepo.Items.Count)
			{
				listBoxDepo.SelectedIndex = index;
			}
		}

		private void Draw() 
		{
			if (listBoxDepo.SelectedIndex > -1)
			{//если выбран один из пуктов в listBox (при старте программы ни один пункт не будет выбран и может возникнуть ошибка, если мы попытаемся обратиться к элементу listBox)
				Bitmap bmp = new Bitmap(pictureBoxDepo.Width, pictureBoxDepo.Height);
				Graphics gr = Graphics.FromImage(bmp);
				depoCollection[listBoxDepo.SelectedItem.ToString()].Draw(gr);
				pictureBoxDepo.Image = bmp;
			}
		}

		private void buttonAddDepo_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxNewLevelName.Text))
			{
				MessageBox.Show("Введите название депо", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			depoCollection.AddDepo(textBoxNewLevelName.Text);
			ReloadLevels();
		}

		private void buttonDelDepo_Click(object sender, EventArgs e)
		{
			if (listBoxDepo.SelectedIndex > -1)
			{
				if (MessageBox.Show($"Удалить депо {listBoxDepo.SelectedItem.ToString()}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					depoCollection.DelParking(listBoxDepo.SelectedItem.ToString());
					ReloadLevels();
				}
			}
		}


		private void buttonTakeLocomotive_Click(object sender, EventArgs e)
		{
			if (listBoxDepo.SelectedIndex > -1 && maskedTextBox.Text != "")
			{
				var locomotive = depoCollection[listBoxDepo.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBox.Text);
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
			var locomotiveConfig = new LocomotiveConfig();
			locomotiveConfig.AddEvent(AddLocomotive);
			locomotiveConfig.Show();
		}

		private void AddLocomotive(Vehicle locomotive)
		{
			if (locomotive != null && listBoxDepo.SelectedIndex > -1)
			{
				if ((depoCollection[listBoxDepo.SelectedItem.ToString()]) + locomotive)
				{
					Draw();
				}
				else
				{
					MessageBox.Show("Локомотив не удалось поставить");
				}
			}
		}

		private void listBoxDepo_SelectedIndexChanged(object sender, EventArgs e)
		{
			Draw();
		}
		

		private void InitializeComponent()
		{
			this.pictureBoxDepo = new System.Windows.Forms.PictureBox();
			this.groupBoxDepo = new System.Windows.Forms.GroupBox();
			this.buttonTakeLocomotive = new System.Windows.Forms.Button();
			this.labelPlace = new System.Windows.Forms.Label();
			this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.buttonSetLocomotive = new System.Windows.Forms.Button();
			this.listBoxDepo = new System.Windows.Forms.ListBox();
			this.buttonAddDepo = new System.Windows.Forms.Button();
			this.buttonDelDepo = new System.Windows.Forms.Button();
			this.textBoxNewLevelName = new System.Windows.Forms.TextBox();
			this.labelDepo = new System.Windows.Forms.Label();
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
			this.pictureBoxDepo.Click += new System.EventHandler(this.pictureBoxDepo_Click);
			// 
			// groupBoxDepo
			// 
			this.groupBoxDepo.Controls.Add(this.buttonTakeLocomotive);
			this.groupBoxDepo.Controls.Add(this.labelPlace);
			this.groupBoxDepo.Controls.Add(this.maskedTextBox);
			this.groupBoxDepo.Location = new System.Drawing.Point(811, 407);
			this.groupBoxDepo.Name = "groupBoxDepo";
			this.groupBoxDepo.Size = new System.Drawing.Size(125, 86);
			this.groupBoxDepo.TabIndex = 11;
			this.groupBoxDepo.TabStop = false;
			this.groupBoxDepo.Text = "Забрать состав";
			this.groupBoxDepo.Enter += new System.EventHandler(this.groupBoxDepo_Enter);
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
			// labelPlace
			// 
			this.labelPlace.AutoSize = true;
			this.labelPlace.Location = new System.Drawing.Point(27, 36);
			this.labelPlace.Name = "labelPlace";
			this.labelPlace.Size = new System.Drawing.Size(39, 13);
			this.labelPlace.TabIndex = 1;
			this.labelPlace.Text = "Место";
			// 
			// maskedTextBox
			// 
			this.maskedTextBox.Location = new System.Drawing.Point(85, 35);
			this.maskedTextBox.Name = "maskedTextBox";
			this.maskedTextBox.Size = new System.Drawing.Size(28, 20);
			this.maskedTextBox.TabIndex = 0;
			this.maskedTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox_MaskInputRejected);
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
			// listBoxDepo
			// 
			this.listBoxDepo.FormattingEnabled = true;
			this.listBoxDepo.Location = new System.Drawing.Point(810, 93);
			this.listBoxDepo.Name = "listBoxDepo";
			this.listBoxDepo.Size = new System.Drawing.Size(126, 121);
			this.listBoxDepo.TabIndex = 14;
			this.listBoxDepo.SelectedIndexChanged += new System.EventHandler(this.listBoxDepo_SelectedIndexChanged);
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
			// textBoxNewLevelName
			// 
			this.textBoxNewLevelName.Location = new System.Drawing.Point(820, 22);
			this.textBoxNewLevelName.Name = "textBoxNewLevelName";
			this.textBoxNewLevelName.Size = new System.Drawing.Size(103, 20);
			this.textBoxNewLevelName.TabIndex = 17;
			// 
			// labelDepo
			// 
			this.labelDepo.AutoSize = true;
			this.labelDepo.Location = new System.Drawing.Point(843, 5);
			this.labelDepo.Name = "labelDepo";
			this.labelDepo.Size = new System.Drawing.Size(37, 13);
			this.labelDepo.TabIndex = 18;
			this.labelDepo.Text = "Депо:";
			// 
			// FormDepo
			// 
			this.ClientSize = new System.Drawing.Size(944, 561);
			this.Controls.Add(this.labelDepo);
			this.Controls.Add(this.textBoxNewLevelName);
			this.Controls.Add(this.buttonDelDepo);
			this.Controls.Add(this.buttonAddDepo);
			this.Controls.Add(this.listBoxDepo);
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

		private void groupBoxDepo_Enter(object sender, EventArgs e)
		{

		}

		private void maskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{

		}

		private void pictureBoxDepo_Click(object sender, EventArgs e)
		{

		}

		
	}
}
