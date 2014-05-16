namespace Tanks
{
    partial class HelpForm
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
            this.helpContent = new System.Windows.Forms.WebBrowser();
            this.copyrightLab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // helpContent
            // 
            this.helpContent.AllowWebBrowserDrop = false;
            this.helpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpContent.IsWebBrowserContextMenuEnabled = false;
            this.helpContent.Location = new System.Drawing.Point(0, 0);
            this.helpContent.MinimumSize = new System.Drawing.Size(20, 20);
            this.helpContent.Name = "helpContent";
            this.helpContent.Size = new System.Drawing.Size(778, 332);
            this.helpContent.TabIndex = 0;
            this.helpContent.TabStop = false;
            this.helpContent.Url = new System.Uri("", System.UriKind.Relative);
            this.helpContent.WebBrowserShortcutsEnabled = false;
            // 
            // copyrightLab
            // 
            this.copyrightLab.AutoSize = true;
            this.copyrightLab.Location = new System.Drawing.Point(492, 310);
            this.copyrightLab.Name = "copyrightLab";
            this.copyrightLab.Size = new System.Drawing.Size(258, 13);
            this.copyrightLab.TabIndex = 1;
            this.copyrightLab.Text = "Копирайт (C) 2014 Максим Кузьмин, версия 1.0.1";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 332);
            this.Controls.Add(this.copyrightLab);
            this.Controls.Add(this.helpContent);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "HelpForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.WebBrowser helpContent;
        private System.Windows.Forms.Label copyrightLab;

    }
}