namespace lab4
{
    partial class FormLocomotive
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLocomotive));
            this.pictureBoxLocomotive = new System.Windows.Forms.PictureBox();
            this.buttonCreateLocomotive = new System.Windows.Forms.Button();
            this.buttonCreateElLocomotive = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocomotive)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxTanker
            // 
            this.pictureBoxLocomotive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLocomotive.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLocomotive.Name = "pictureBoxTanker";
            this.pictureBoxLocomotive.Size = new System.Drawing.Size(800, 450);
            this.pictureBoxLocomotive.TabIndex = 0;
            this.pictureBoxLocomotive.TabStop = false;
            // 
            // buttonCreateLocomotive
            // 
            this.buttonCreateLocomotive.Location = new System.Drawing.Point(12, 12);
            this.buttonCreateLocomotive.Name = "buttonCreateLocomotive";
            this.buttonCreateLocomotive.Size = new System.Drawing.Size(120, 30);
            this.buttonCreateLocomotive.TabIndex = 1;
            this.buttonCreateLocomotive.Text = "Create Locomotive";
            this.buttonCreateLocomotive.UseVisualStyleBackColor = true;
            this.buttonCreateLocomotive.Click += new System.EventHandler(this.buttonCreateLocomotive_Click);
            // 
            // buttonCreateElLocomotive
            // 
            this.buttonCreateElLocomotive.Location = new System.Drawing.Point(142, 12);
            this.buttonCreateElLocomotive.Name = "buttonCreateElLocomotive";
            this.buttonCreateElLocomotive.Size = new System.Drawing.Size(140, 30);
            this.buttonCreateElLocomotive.TabIndex = 1;
            this.buttonCreateElLocomotive.Text = "Create ElLocomotive";
            this.buttonCreateElLocomotive.UseVisualStyleBackColor = true;
            this.buttonCreateElLocomotive.Click += new System.EventHandler(this.buttonCreateElLocomotive_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLeft.BackgroundImage")));
            this.buttonLeft.Location = new System.Drawing.Point(686, 408);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(30, 30);
            this.buttonLeft.TabIndex = 1;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRight.BackgroundImage")));
            this.buttonRight.Location = new System.Drawing.Point(758, 408);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(30, 30);
            this.buttonRight.TabIndex = 1;
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUp.BackgroundImage")));
            this.buttonUp.Location = new System.Drawing.Point(722, 372);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(30, 30);
            this.buttonUp.TabIndex = 1;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDown.BackgroundImage")));
            this.buttonDown.Location = new System.Drawing.Point(722, 408);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(30, 30);
            this.buttonDown.TabIndex = 1;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // FormCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonCreateLocomotive);
            this.Controls.Add(this.buttonCreateElLocomotive);
            this.Controls.Add(this.pictureBoxLocomotive);
            this.Name = "FormLocomotive";
            this.Text = "FormLocomotive";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocomotive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLocomotive;
        private System.Windows.Forms.Button buttonCreateLocomotive;
        private System.Windows.Forms.Button buttonCreateElLocomotive;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
    }
}

