namespace _2
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
            this.rightXUpDown = new System.Windows.Forms.NumericUpDown();
            this.leftXUpDown = new System.Windows.Forms.NumericUpDown();
            this.formulaButton = new System.Windows.Forms.Button();
            this.fButton = new System.Windows.Forms.Button();
            this.sinButton = new System.Windows.Forms.Button();
            this.cosButton = new System.Windows.Forms.Button();
            this.chButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rightXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rightXUpDown
            // 
            this.rightXUpDown.DecimalPlaces = 1;
            this.rightXUpDown.Location = new System.Drawing.Point(693, 216);
            this.rightXUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.rightXUpDown.Name = "rightXUpDown";
            this.rightXUpDown.Size = new System.Drawing.Size(45, 20);
            this.rightXUpDown.TabIndex = 0;
            this.rightXUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // leftXUpDown
            // 
            this.leftXUpDown.DecimalPlaces = 1;
            this.leftXUpDown.Location = new System.Drawing.Point(624, 216);
            this.leftXUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.leftXUpDown.Name = "leftXUpDown";
            this.leftXUpDown.Size = new System.Drawing.Size(54, 20);
            this.leftXUpDown.TabIndex = 3;
            this.leftXUpDown.ThousandsSeparator = true;
            this.leftXUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // formulaButton
            // 
            this.formulaButton.Location = new System.Drawing.Point(624, 257);
            this.formulaButton.Name = "formulaButton";
            this.formulaButton.Size = new System.Drawing.Size(75, 23);
            this.formulaButton.TabIndex = 4;
            this.formulaButton.Text = "Формула";
            this.formulaButton.UseVisualStyleBackColor = true;
            this.formulaButton.Click += new System.EventHandler(this.formulaButton_Click);
            // 
            // fButton
            // 
            this.fButton.Location = new System.Drawing.Point(624, 297);
            this.fButton.Name = "fButton";
            this.fButton.Size = new System.Drawing.Size(75, 23);
            this.fButton.TabIndex = 5;
            this.fButton.Text = "f(x)";
            this.fButton.UseVisualStyleBackColor = true;
            this.fButton.Click += new System.EventHandler(this.fButton_Click);
            // 
            // sinButton
            // 
            this.sinButton.Location = new System.Drawing.Point(577, 370);
            this.sinButton.Name = "sinButton";
            this.sinButton.Size = new System.Drawing.Size(75, 23);
            this.sinButton.TabIndex = 6;
            this.sinButton.Text = "sin(x)";
            this.sinButton.UseVisualStyleBackColor = true;
            this.sinButton.Click += new System.EventHandler(this.sinButton_Click);
            // 
            // cosButton
            // 
            this.cosButton.Location = new System.Drawing.Point(663, 370);
            this.cosButton.Name = "cosButton";
            this.cosButton.Size = new System.Drawing.Size(75, 23);
            this.cosButton.TabIndex = 7;
            this.cosButton.Text = "cos(x)";
            this.cosButton.UseVisualStyleBackColor = true;
            this.cosButton.Click += new System.EventHandler(this.cosButton_Click);
            // 
            // chButton
            // 
            this.chButton.Location = new System.Drawing.Point(663, 415);
            this.chButton.Name = "chButton";
            this.chButton.Size = new System.Drawing.Size(75, 23);
            this.chButton.TabIndex = 9;
            this.chButton.Text = "ch(x)";
            this.chButton.UseVisualStyleBackColor = true;
            this.chButton.Click += new System.EventHandler(this.chButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(886, 521);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 545);
            this.Controls.Add(this.chButton);
            this.Controls.Add(this.cosButton);
            this.Controls.Add(this.sinButton);
            this.Controls.Add(this.fButton);
            this.Controls.Add(this.formulaButton);
            this.Controls.Add(this.leftXUpDown);
            this.Controls.Add(this.rightXUpDown);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rightXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown rightXUpDown;
        private System.Windows.Forms.NumericUpDown leftXUpDown;
        private System.Windows.Forms.Button formulaButton;
        private System.Windows.Forms.Button fButton;
        private System.Windows.Forms.Button sinButton;
        private System.Windows.Forms.Button cosButton;
        private System.Windows.Forms.Button chButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}