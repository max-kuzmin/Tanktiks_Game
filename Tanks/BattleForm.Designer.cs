namespace Tanks
{
    partial class BattleForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleForm));
            this.DrawField = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DrawField)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawField
            // 
            this.DrawField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(103)))), ((int)(((byte)(55)))));
            this.DrawField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawField.Location = new System.Drawing.Point(0, 0);
            this.DrawField.Name = "DrawField";
            this.DrawField.Size = new System.Drawing.Size(584, 561);
            this.DrawField.TabIndex = 0;
            this.DrawField.TabStop = false;
            this.DrawField.WaitOnLoad = true;
            this.DrawField.Click += new System.EventHandler(this.DrawField_Click);
            this.DrawField.Resize += new System.EventHandler(this.DrawField_Resize);
            // 
            // BattleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.DrawField);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(128, 135);
            this.Name = "BattleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Танки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DrawField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox DrawField;

    }
}

