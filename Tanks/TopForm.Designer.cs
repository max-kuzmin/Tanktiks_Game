namespace Tanks
{
    partial class TopForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopForm));
            this.listTop = new System.Windows.Forms.ListView();
            this.num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.score = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TopOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listTop
            // 
            this.listTop.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.listTop.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.num,
            this.name,
            this.score});
            this.listTop.Location = new System.Drawing.Point(12, 12);
            this.listTop.Name = "listTop";
            this.listTop.Size = new System.Drawing.Size(334, 204);
            this.listTop.TabIndex = 0;
            this.listTop.UseCompatibleStateImageBehavior = false;
            this.listTop.View = System.Windows.Forms.View.Details;
            // 
            // num
            // 
            this.num.Text = "Место";
            this.num.Width = 52;
            // 
            // name
            // 
            this.name.Text = "Имя";
            this.name.Width = 187;
            // 
            // score
            // 
            this.score.Text = "Счет";
            this.score.Width = 91;
            // 
            // TopOk
            // 
            this.TopOk.Location = new System.Drawing.Point(135, 236);
            this.TopOk.Name = "TopOk";
            this.TopOk.Size = new System.Drawing.Size(95, 27);
            this.TopOk.TabIndex = 1;
            this.TopOk.Text = "ОК";
            this.TopOk.UseVisualStyleBackColor = true;
            this.TopOk.Click += new System.EventHandler(this.TopOk_Click);
            // 
            // TopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(358, 275);
            this.Controls.Add(this.TopOk);
            this.Controls.Add(this.listTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TopForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лидеры игры";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listTop;
        private System.Windows.Forms.Button TopOk;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader score;
        private System.Windows.Forms.ColumnHeader num;
    }
}