namespace _5
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.масштToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проекцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.центральнаяОдноточечнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ортогональнаяПараллельнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObliqueProjMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.переносToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(816, 521);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.масштToolStripMenuItem,
            this.проекцияToolStripMenuItem,
            this.переносToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(840, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // масштToolStripMenuItem
            // 
            this.масштToolStripMenuItem.Name = "масштToolStripMenuItem";
            this.масштToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.масштToolStripMenuItem.Text = "Масштабирование";
            this.масштToolStripMenuItem.Click += new System.EventHandler(this.ResizeButtonOnClick);
            // 
            // проекцияToolStripMenuItem
            // 
            this.проекцияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.центральнаяОдноточечнаяToolStripMenuItem,
            this.ортогональнаяПараллельнаяToolStripMenuItem,
            this.ObliqueProjMenu});
            this.проекцияToolStripMenuItem.Name = "проекцияToolStripMenuItem";
            this.проекцияToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.проекцияToolStripMenuItem.Text = "Проекция";
            // 
            // центральнаяОдноточечнаяToolStripMenuItem
            // 
            this.центральнаяОдноточечнаяToolStripMenuItem.Name = "центральнаяОдноточечнаяToolStripMenuItem";
            this.центральнаяОдноточечнаяToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.центральнаяОдноточечнаяToolStripMenuItem.Text = "Центральная одноточечная";
            this.центральнаяОдноточечнаяToolStripMenuItem.Click += new System.EventHandler(this.CentralProjectionOnClick);
            // 
            // ортогональнаяПараллельнаяToolStripMenuItem
            // 
            this.ортогональнаяПараллельнаяToolStripMenuItem.Name = "ортогональнаяПараллельнаяToolStripMenuItem";
            this.ортогональнаяПараллельнаяToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.ортогональнаяПараллельнаяToolStripMenuItem.Text = "Ортогональная параллельная";
            this.ортогональнаяПараллельнаяToolStripMenuItem.Click += new System.EventHandler(this.OrthProjectionOnClick);
            // 
            // ObliqueProjMenu
            // 
            this.ObliqueProjMenu.Name = "ObliqueProjMenu";
            this.ObliqueProjMenu.Size = new System.Drawing.Size(240, 22);
            this.ObliqueProjMenu.Text = "Косоугольная";
            this.ObliqueProjMenu.Click += new System.EventHandler(this.ObliqueProjectionOnClick);
            // 
            // переносToolStripMenuItem
            // 
            this.переносToolStripMenuItem.Name = "переносToolStripMenuItem";
            this.переносToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.переносToolStripMenuItem.Text = "Перенос";
            this.переносToolStripMenuItem.Click += new System.EventHandler(this.MoveOnClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 560);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem масштToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проекцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem центральнаяОдноточечнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ортогональнаяПараллельнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ObliqueProjMenu;
        private System.Windows.Forms.ToolStripMenuItem переносToolStripMenuItem;
    }
}

