﻿namespace _4
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
            this.resizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отражениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.повернутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(34, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(754, 367);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeMenuItem,
            this.moveToolStripMenuItem,
            this.отражениеToolStripMenuItem,
            this.повернутьToolStripMenuItem,
            this.ResetToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // resizeMenuItem
            // 
            this.resizeMenuItem.Name = "resizeMenuItem";
            this.resizeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.resizeMenuItem.Size = new System.Drawing.Size(164, 20);
            this.resizeMenuItem.Text = "Маштабирование(Ctrl+M)";
            this.resizeMenuItem.Click += new System.EventHandler(this.resizeMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.moveToolStripMenuItem.Text = "Перенос(ctrl+s)";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // отражениеToolStripMenuItem
            // 
            this.отражениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.XToolStripMenuItem,
            this.YToolStripMenuItem,
            this.XYToolStripMenuItem});
            this.отражениеToolStripMenuItem.Name = "отражениеToolStripMenuItem";
            this.отражениеToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.отражениеToolStripMenuItem.Text = "Отражение";
            // 
            // XToolStripMenuItem
            // 
            this.XToolStripMenuItem.Name = "XToolStripMenuItem";
            this.XToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.XToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.XToolStripMenuItem.Text = "Относительно X";
            this.XToolStripMenuItem.Click += new System.EventHandler(this.XToolStripMenuItem_Click);
            // 
            // YToolStripMenuItem
            // 
            this.YToolStripMenuItem.Name = "YToolStripMenuItem";
            this.YToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.YToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.YToolStripMenuItem.Text = "Относительно Y";
            this.YToolStripMenuItem.Click += new System.EventHandler(this.YToolStripMenuItem_Click);
            // 
            // XYToolStripMenuItem
            // 
            this.XYToolStripMenuItem.Name = "XYToolStripMenuItem";
            this.XYToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.XYToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.XYToolStripMenuItem.Text = "Относительно Y=X ";
            this.XYToolStripMenuItem.Click += new System.EventHandler(this.XYToolStripMenuItem_Click);
            // 
            // повернутьToolStripMenuItem
            // 
            this.повернутьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CenterToolStripMenuItem,
            this.PointToolStripMenuItem});
            this.повернутьToolStripMenuItem.Name = "повернутьToolStripMenuItem";
            this.повернутьToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.повернутьToolStripMenuItem.Text = "Повернуть";
            // 
            // CenterToolStripMenuItem
            // 
            this.CenterToolStripMenuItem.Name = "CenterToolStripMenuItem";
            this.CenterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.CenterToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.CenterToolStripMenuItem.Text = "Относительно центра";
            this.CenterToolStripMenuItem.Click += new System.EventHandler(this.CenterToolStripMenuItem_Click);
            // 
            // PointToolStripMenuItem
            // 
            this.PointToolStripMenuItem.Name = "PointToolStripMenuItem";
            this.PointToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.PointToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.PointToolStripMenuItem.Text = "Относительно точки";
            this.PointToolStripMenuItem.Click += new System.EventHandler(this.PointToolStripMenuItem_Click);
            // 
            // ResetToolStripMenuItem
            // 
            this.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem";
            this.ResetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.R)));
            this.ResetToolStripMenuItem.Size = new System.Drawing.Size(263, 20);
            this.ResetToolStripMenuItem.Text = "Восстановить исходную позицию(ctrl+alt+r)";
            this.ResetToolStripMenuItem.Click += new System.EventHandler(this.ResetToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
        private System.Windows.Forms.ToolStripMenuItem resizeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отражениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem YToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem XYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem повернутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetToolStripMenuItem;
    }
}

