namespace Tanks
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.startCampBut = new System.Windows.Forms.Button();
            this.topBut = new System.Windows.Forms.Button();
            this.loadLvlBut = new System.Windows.Forms.Button();
            this.settingBut = new System.Windows.Forms.Button();
            this.helpBut = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // startCampBut
            // 
            this.startCampBut.Location = new System.Drawing.Point(57, 165);
            this.startCampBut.Name = "startCampBut";
            this.startCampBut.Size = new System.Drawing.Size(208, 57);
            this.startCampBut.TabIndex = 0;
            this.startCampBut.Text = "Начать одиночную игру";
            this.startCampBut.UseVisualStyleBackColor = true;
            this.startCampBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // topBut
            // 
            this.topBut.Location = new System.Drawing.Point(372, 211);
            this.topBut.Name = "topBut";
            this.topBut.Size = new System.Drawing.Size(176, 29);
            this.topBut.TabIndex = 1;
            this.topBut.Text = "Лучшие игроки";
            this.topBut.UseVisualStyleBackColor = true;
            this.topBut.Click += new System.EventHandler(this.topBut_Click);
            // 
            // loadLvlBut
            // 
            this.loadLvlBut.Location = new System.Drawing.Point(95, 249);
            this.loadLvlBut.Name = "loadLvlBut";
            this.loadLvlBut.Size = new System.Drawing.Size(137, 38);
            this.loadLvlBut.TabIndex = 2;
            this.loadLvlBut.Text = "Загрузить уровни";
            this.loadLvlBut.UseVisualStyleBackColor = true;
            this.loadLvlBut.Click += new System.EventHandler(this.loadLvlBut_Click);
            // 
            // settingBut
            // 
            this.settingBut.Location = new System.Drawing.Point(372, 165);
            this.settingBut.Name = "settingBut";
            this.settingBut.Size = new System.Drawing.Size(176, 29);
            this.settingBut.TabIndex = 3;
            this.settingBut.Text = "Настройки";
            this.settingBut.UseVisualStyleBackColor = true;
            this.settingBut.Click += new System.EventHandler(this.settingBut_Click);
            // 
            // helpBut
            // 
            this.helpBut.Location = new System.Drawing.Point(372, 258);
            this.helpBut.Name = "helpBut";
            this.helpBut.Size = new System.Drawing.Size(176, 29);
            this.helpBut.TabIndex = 4;
            this.helpBut.Text = "Справка";
            this.helpBut.UseVisualStyleBackColor = true;
            this.helpBut.Click += new System.EventHandler(this.helpBut_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.ErrorImage = null;
            this.pictureBoxLogo.ImageLocation = "Textures\\logo.png";
            this.pictureBoxLogo.InitialImage = null;
            this.pictureBoxLogo.Location = new System.Drawing.Point(12, 22);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(572, 118);
            this.pictureBoxLogo.TabIndex = 5;
            this.pictureBoxLogo.TabStop = false;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(596, 309);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.helpBut);
            this.Controls.Add(this.settingBut);
            this.Controls.Add(this.loadLvlBut);
            this.Controls.Add(this.topBut);
            this.Controls.Add(this.startCampBut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Танки";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startCampBut;
        private System.Windows.Forms.Button topBut;
        private System.Windows.Forms.Button loadLvlBut;
        private System.Windows.Forms.Button settingBut;
        private System.Windows.Forms.Button helpBut;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}