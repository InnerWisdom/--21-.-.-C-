using NLog;
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

		readonly Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

		private Button buttonSetLocomotive;
		private ListBox listBoxDepo;
		private Button buttonAddDepo;
		private Button buttonDelDepo;
		private Label labelDepo;
		private TextBox textBoxNewLevelName;

		private System.Windows.Forms.SaveFileDialog saveDepoDialog;
		private System.Windows.Forms.OpenFileDialog loadDepoDialog;

		private System.Windows.Forms.MenuStrip depoMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;

		public FormDepo()
		{
			InitializeComponent();
			depoCollection = new DepoCollection(pictureBoxDepo.Width, pictureBoxDepo.Height);
			logger = LogManager.GetCurrentClassLogger();
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
			Bitmap bmp = new Bitmap(pictureBoxDepo.Width, pictureBoxDepo.Height);
			Graphics gr = Graphics.FromImage(bmp);
			if (listBoxDepo.SelectedIndex > -1)
			{
				depoCollection[listBoxDepo.SelectedItem.ToString()].Draw(gr);
			}
			else
			{
				gr.FillRectangle(new SolidBrush(Color.Transparent), 0, 0, pictureBoxDepo.Width, pictureBoxDepo.Height);
			}
			pictureBoxDepo.Image = bmp;
		}

		private void buttonAddDepo_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxNewLevelName.Text))
			{
				MessageBox.Show("Введите название депо", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			logger.Info($"Добавили депо {textBoxNewLevelName.Text}");
			depoCollection.AddDepo(textBoxNewLevelName.Text);
			ReloadLevels();
		}

		private void buttonDelDepo_Click(object sender, EventArgs e)
		{
			if (listBoxDepo.SelectedIndex > -1)
			{
				if (MessageBox.Show($"Удалить депо {listBoxDepo.SelectedItem.ToString()}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					logger.Info($"Удалили депо{ listBoxDepo.SelectedItem.ToString()}");
					depoCollection.DelDepo(listBoxDepo.SelectedItem.ToString());
				}
			}
			ReloadLevels();
			Draw();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveDepoDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					depoCollection.SaveData(saveDepoDialog.FileName);
					MessageBox.Show("Сохранение прошло успешно", "Результат",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
					logger.Info("Сохранено в файл " + saveDepoDialog.FileName);
				}
				catch (Exception ex)
				{
					logger.Warn("Неизвестная ошибка при сохранении" + ex.Message);
					MessageBox .Show(ex.Message, "Неизвестная ошибка при сохранении",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void llo(object sender, EventArgs e)
		{
			if (loadDepoDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					depoCollection.LoadData(loadDepoDialog.FileName);
					MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
					logger.Info("Загружено из файла " + loadDepoDialog.FileName);
					ReloadLevels();
					Draw();
				}
				catch (DepoOverflowException ex)
				{
					logger.Warn("Занятое место" + ex.Message);
					MessageBox.Show(ex.Message, "Занятое место", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					logger.Warn("Неизвестная ошибка при сохранении" + ex.Message);
					MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void buttonTakeLocomotive_Click(object sender, EventArgs e)
		{
			if (listBoxDepo.SelectedIndex > -1 && maskedTextBox.Text != "")
			{
				try
				{
					var locomotive = depoCollection[listBoxDepo.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBox.Text);
					if (locomotive != null)
					{
						FormLocomotive form = new FormLocomotive();
						form.SetLocomotive(locomotive);
						form.ShowDialog();
						logger.Info($"Изъят локомотив {locomotive} с места{ maskedTextBox.Text}");

					}
				}
				catch (DepoNotFoundException ex)
				{
					logger.Warn("Не найдено депо" + ex.Message);
					MessageBox.Show(ex.Message, "Не найдено депо", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					logger.Warn("Неизвестная ошибка" + ex.Message);
					MessageBox.Show(ex.Message, "Неизвестная ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				}


			}

			ReloadLevels();
			Draw();
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
				try
				{
					if ((depoCollection[listBoxDepo.SelectedItem.ToString()]) +
				   locomotive)
					{
						Draw();
						logger.Info($"Добавлен локомотив {locomotive}");
					}
					else
					{
						logger.Warn("Локомотив не удалось поставить");
						MessageBox.Show("Локомотив не удалось поставить");
					}
					Draw();
				}
				catch (DepoOverflowException ex)
				{
					logger.Warn("Переполнение" + ex.Message);
					MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					logger.Warn("Неизвестная ошибка" + ex.Message);
					MessageBox.Show(ex.Message, "Неизвестная ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

		}

		private void listBoxDepo_SelectedIndexChanged(object sender, EventArgs e)
		{
			logger.Info($"Перешли к депо{ listBoxDepo.SelectedItem.ToString()}");

			Draw();
		}


		private void InitializeComponent()
		{

			this.depoMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.depoMenuStrip.SuspendLayout();
			this.labelDepo = new System.Windows.Forms.Label();

			this.saveDepoDialog = new System.Windows.Forms.SaveFileDialog();
			this.loadDepoDialog = new System.Windows.Forms.OpenFileDialog();
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
			this.groupBoxDepo.Controls.Add(this.labelPlace);
			this.groupBoxDepo.Controls.Add(this.maskedTextBox);
			this.groupBoxDepo.Location = new System.Drawing.Point(811, 407);
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
			// saveDepoDialog
			//
			this.saveDepoDialog.Filter = "txt file | *.txt";
			// 
			// depoMenuStrip
			// 
			this.depoMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem});
			this.depoMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.depoMenuStrip.Name = "menuStrip1";
			this.depoMenuStrip.Size = new System.Drawing.Size(687, 24);
			this.depoMenuStrip.TabIndex = 7;
			this.depoMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.saveToolStripMenuItem,
			this.loadToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.fileToolStripMenuItem.Text = "Файл";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.saveToolStripMenuItem.Name = "toolStripMenuItem1";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveToolStripMenuItem.Text = "Сохранить";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "toolStripMenuItem1ToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.loadToolStripMenuItem.Text = "Загрузить";
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
			// 
			// loadDepoDialog
			// 
			this.loadDepoDialog.FileName = "openFileDialog1";
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

			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loa);


			this.Controls.Add(this.depoMenuStrip);
			this.MainMenuStrip = this.depoMenuStrip;
			this.depoMenuStrip.ResumeLayout(false);
			this.depoMenuStrip.PerformLayout();
			this.Name = "FormDepo";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDepo)).EndInit();
			this.groupBoxDepo.ResumeLayout(false);
			this.groupBoxDepo.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
