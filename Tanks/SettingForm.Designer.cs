namespace Tanks
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.CancelBut = new System.Windows.Forms.Button();
            this.okBut = new System.Windows.Forms.Button();
            this.hardBut = new System.Windows.Forms.RadioButton();
            this.normBut = new System.Windows.Forms.RadioButton();
            this.easyBut = new System.Windows.Forms.RadioButton();
            this.wasdBut = new System.Windows.Forms.RadioButton();
            this.arrowsBut = new System.Windows.Forms.RadioButton();
            this.groupBoxDifficulty = new System.Windows.Forms.GroupBox();
            this.groupBoxKeys = new System.Windows.Forms.GroupBox();
            this.bonusRedBut = new System.Windows.Forms.CheckBox();
            this.collisionBut = new System.Windows.Forms.CheckBox();
            this.unlimRedBut = new System.Windows.Forms.CheckBox();
            this.groupBoxGame = new System.Windows.Forms.GroupBox();
            this.checkBoxBullets = new System.Windows.Forms.CheckBox();
            this.groupBoxDifficulty.SuspendLayout();
            this.groupBoxKeys.SuspendLayout();
            this.groupBoxGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelBut
            // 
            this.CancelBut.Location = new System.Drawing.Point(255, 166);
            this.CancelBut.Name = "CancelBut";
            this.CancelBut.Size = new System.Drawing.Size(89, 27);
            this.CancelBut.TabIndex = 0;
            this.CancelBut.Text = "Отмена";
            this.CancelBut.UseVisualStyleBackColor = true;
            this.CancelBut.Click += new System.EventHandler(this.CancelBut_Click);
            // 
            // okBut
            // 
            this.okBut.Location = new System.Drawing.Point(123, 166);
            this.okBut.Name = "okBut";
            this.okBut.Size = new System.Drawing.Size(89, 27);
            this.okBut.TabIndex = 1;
            this.okBut.Text = "ОК";
            this.okBut.UseVisualStyleBackColor = true;
            this.okBut.Click += new System.EventHandler(this.okBut_Click);
            // 
            // hardBut
            // 
            this.hardBut.AutoSize = true;
            this.hardBut.BackColor = System.Drawing.Color.Transparent;
            this.hardBut.Location = new System.Drawing.Point(21, 32);
            this.hardBut.Name = "hardBut";
            this.hardBut.Size = new System.Drawing.Size(64, 17);
            this.hardBut.TabIndex = 2;
            this.hardBut.TabStop = true;
            this.hardBut.Text = "Сложно";
            this.hardBut.UseVisualStyleBackColor = false;
            // 
            // normBut
            // 
            this.normBut.AutoSize = true;
            this.normBut.BackColor = System.Drawing.Color.Transparent;
            this.normBut.Location = new System.Drawing.Point(21, 55);
            this.normBut.Name = "normBut";
            this.normBut.Size = new System.Drawing.Size(83, 17);
            this.normBut.TabIndex = 3;
            this.normBut.TabStop = true;
            this.normBut.Text = "Нормально";
            this.normBut.UseVisualStyleBackColor = false;
            // 
            // easyBut
            // 
            this.easyBut.AutoSize = true;
            this.easyBut.BackColor = System.Drawing.Color.Transparent;
            this.easyBut.Location = new System.Drawing.Point(21, 78);
            this.easyBut.Name = "easyBut";
            this.easyBut.Size = new System.Drawing.Size(56, 17);
            this.easyBut.TabIndex = 4;
            this.easyBut.TabStop = true;
            this.easyBut.Text = "Легко";
            this.easyBut.UseVisualStyleBackColor = false;
            // 
            // wasdBut
            // 
            this.wasdBut.AutoSize = true;
            this.wasdBut.Location = new System.Drawing.Point(24, 56);
            this.wasdBut.Name = "wasdBut";
            this.wasdBut.Size = new System.Drawing.Size(91, 17);
            this.wasdBut.TabIndex = 5;
            this.wasdBut.TabStop = true;
            this.wasdBut.Text = "WASD + Shift";
            this.wasdBut.UseVisualStyleBackColor = true;
            // 
            // arrowsBut
            // 
            this.arrowsBut.AutoSize = true;
            this.arrowsBut.BackColor = System.Drawing.Color.Transparent;
            this.arrowsBut.Location = new System.Drawing.Point(24, 32);
            this.arrowsBut.Name = "arrowsBut";
            this.arrowsBut.Size = new System.Drawing.Size(100, 17);
            this.arrowsBut.TabIndex = 6;
            this.arrowsBut.TabStop = true;
            this.arrowsBut.Text = "Стрелки + Shift";
            this.arrowsBut.UseVisualStyleBackColor = false;
            // 
            // groupBoxDifficulty
            // 
            this.groupBoxDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxDifficulty.Controls.Add(this.easyBut);
            this.groupBoxDifficulty.Controls.Add(this.hardBut);
            this.groupBoxDifficulty.Controls.Add(this.normBut);
            this.groupBoxDifficulty.Location = new System.Drawing.Point(12, 30);
            this.groupBoxDifficulty.Name = "groupBoxDifficulty";
            this.groupBoxDifficulty.Size = new System.Drawing.Size(121, 112);
            this.groupBoxDifficulty.TabIndex = 7;
            this.groupBoxDifficulty.TabStop = false;
            this.groupBoxDifficulty.Text = "Сложность";
            // 
            // groupBoxKeys
            // 
            this.groupBoxKeys.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxKeys.Controls.Add(this.wasdBut);
            this.groupBoxKeys.Controls.Add(this.arrowsBut);
            this.groupBoxKeys.Location = new System.Drawing.Point(140, 30);
            this.groupBoxKeys.Name = "groupBoxKeys";
            this.groupBoxKeys.Size = new System.Drawing.Size(132, 112);
            this.groupBoxKeys.TabIndex = 8;
            this.groupBoxKeys.TabStop = false;
            this.groupBoxKeys.Text = "Управление";
            // 
            // bonusRedBut
            // 
            this.bonusRedBut.AutoSize = true;
            this.bonusRedBut.Location = new System.Drawing.Point(27, 42);
            this.bonusRedBut.Name = "bonusRedBut";
            this.bonusRedBut.Size = new System.Drawing.Size(127, 17);
            this.bonusRedBut.TabIndex = 9;
            this.bonusRedBut.Text = "Враги берут бонусы";
            this.bonusRedBut.UseVisualStyleBackColor = true;
            // 
            // collisionBut
            // 
            this.collisionBut.AutoSize = true;
            this.collisionBut.Location = new System.Drawing.Point(27, 65);
            this.collisionBut.Name = "collisionBut";
            this.collisionBut.Size = new System.Drawing.Size(136, 17);
            this.collisionBut.TabIndex = 10;
            this.collisionBut.Text = "Столкновения танков";
            this.collisionBut.UseVisualStyleBackColor = true;
            // 
            // unlimRedBut
            // 
            this.unlimRedBut.AutoSize = true;
            this.unlimRedBut.Location = new System.Drawing.Point(27, 19);
            this.unlimRedBut.Name = "unlimRedBut";
            this.unlimRedBut.Size = new System.Drawing.Size(126, 17);
            this.unlimRedBut.TabIndex = 11;
            this.unlimRedBut.Text = "Бесконечные враги";
            this.unlimRedBut.UseVisualStyleBackColor = true;
            // 
            // groupBoxGame
            // 
            this.groupBoxGame.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxGame.Controls.Add(this.checkBoxBullets);
            this.groupBoxGame.Controls.Add(this.unlimRedBut);
            this.groupBoxGame.Controls.Add(this.collisionBut);
            this.groupBoxGame.Controls.Add(this.bonusRedBut);
            this.groupBoxGame.Location = new System.Drawing.Point(277, 30);
            this.groupBoxGame.Name = "groupBoxGame";
            this.groupBoxGame.Size = new System.Drawing.Size(176, 112);
            this.groupBoxGame.TabIndex = 12;
            this.groupBoxGame.TabStop = false;
            this.groupBoxGame.Text = "Игровой процесс";
            // 
            // checkBoxBullets
            // 
            this.checkBoxBullets.AutoSize = true;
            this.checkBoxBullets.Location = new System.Drawing.Point(27, 88);
            this.checkBoxBullets.Name = "checkBoxBullets";
            this.checkBoxBullets.Size = new System.Drawing.Size(124, 17);
            this.checkBoxBullets.TabIndex = 12;
            this.checkBoxBullets.Text = "Столкновения пуль";
            this.checkBoxBullets.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(465, 214);
            this.Controls.Add(this.okBut);
            this.Controls.Add(this.CancelBut);
            this.Controls.Add(this.groupBoxDifficulty);
            this.Controls.Add(this.groupBoxKeys);
            this.Controls.Add(this.groupBoxGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.groupBoxDifficulty.ResumeLayout(false);
            this.groupBoxDifficulty.PerformLayout();
            this.groupBoxKeys.ResumeLayout(false);
            this.groupBoxKeys.PerformLayout();
            this.groupBoxGame.ResumeLayout(false);
            this.groupBoxGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton hardBut;
        private System.Windows.Forms.RadioButton normBut;
        private System.Windows.Forms.RadioButton easyBut;
        private System.Windows.Forms.RadioButton wasdBut;
        private System.Windows.Forms.RadioButton arrowsBut;
        private System.Windows.Forms.GroupBox groupBoxDifficulty;
        private System.Windows.Forms.GroupBox groupBoxKeys;
        private System.Windows.Forms.CheckBox bonusRedBut;
        private System.Windows.Forms.CheckBox collisionBut;
        private System.Windows.Forms.CheckBox unlimRedBut;
        private System.Windows.Forms.GroupBox groupBoxGame;
        public System.Windows.Forms.Button okBut;
        public System.Windows.Forms.Button CancelBut;
        private System.Windows.Forms.CheckBox checkBoxBullets;
    }
}