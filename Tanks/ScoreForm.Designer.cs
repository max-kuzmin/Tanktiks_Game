using System.Drawing;

namespace Tanks
{
    partial class ScoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreForm));
            this.goMenuBut = new System.Windows.Forms.Button();
            this.scoreLab = new System.Windows.Forms.Label();
            this.cancelBut = new System.Windows.Forms.Button();
            this.winLab = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.enterName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // goMenuBut
            // 
            this.goMenuBut.Location = new System.Drawing.Point(51, 173);
            this.goMenuBut.Name = "goMenuBut";
            this.goMenuBut.Size = new System.Drawing.Size(117, 35);
            this.goMenuBut.TabIndex = 0;
            this.goMenuBut.Text = "Выйти в меню";
            this.goMenuBut.UseVisualStyleBackColor = true;
            this.goMenuBut.Click += new System.EventHandler(this.goMenuBut_Click);
            // 
            // scoreLab
            // 
            this.scoreLab.BackColor = System.Drawing.Color.Transparent;
            this.scoreLab.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreLab.Location = new System.Drawing.Point(47, 80);
            this.scoreLab.Name = "scoreLab";
            this.scoreLab.Size = new System.Drawing.Size(219, 30);
            this.scoreLab.TabIndex = 1;
            this.scoreLab.Text = "scoreLine";
            this.scoreLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelBut
            // 
            this.cancelBut.Location = new System.Drawing.Point(183, 173);
            this.cancelBut.Name = "cancelBut";
            this.cancelBut.Size = new System.Drawing.Size(87, 35);
            this.cancelBut.TabIndex = 2;
            this.cancelBut.Text = "Закрыть";
            this.cancelBut.UseVisualStyleBackColor = true;
            this.cancelBut.Click += new System.EventHandler(this.cancelBut_Click);
            // 
            // winLab
            // 
            this.winLab.BackColor = System.Drawing.Color.Transparent;
            this.winLab.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.winLab.Location = new System.Drawing.Point(36, 23);
            this.winLab.Name = "winLab";
            this.winLab.Size = new System.Drawing.Size(243, 46);
            this.winLab.TabIndex = 3;
            this.winLab.Text = "winSide";
            this.winLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(149, 133);
            this.nameBox.MaxLength = 20;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 4;
            this.nameBox.Text = "Игрок";
            this.nameBox.Visible = false;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // enterName
            // 
            this.enterName.AutoSize = true;
            this.enterName.BackColor = System.Drawing.Color.Transparent;
            this.enterName.Location = new System.Drawing.Point(64, 136);
            this.enterName.Name = "enterName";
            this.enterName.Size = new System.Drawing.Size(75, 13);
            this.enterName.TabIndex = 5;
            this.enterName.Text = "Введите имя:";
            this.enterName.Visible = false;
            // 
            // ScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(318, 231);
            this.ControlBox = false;
            this.Controls.Add(this.enterName);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.winLab);
            this.Controls.Add(this.cancelBut);
            this.Controls.Add(this.scoreLab);
            this.Controls.Add(this.goMenuBut);
            this.Name = "ScoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра окончена";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreLab;
        private System.Windows.Forms.Label winLab;
        public System.Windows.Forms.Button goMenuBut;
        public System.Windows.Forms.Button cancelBut;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label enterName;
    }
}