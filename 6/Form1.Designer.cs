namespace _6
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
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.MinXText = new System.Windows.Forms.TextBox();
            this.MaxXText = new System.Windows.Forms.TextBox();
            this.MinYText = new System.Windows.Forms.TextBox();
            this.MaxYText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.axisCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(727, 565);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxOnPaint);
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(765, 158);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(100, 20);
            this.countTextBox.TabIndex = 3;
            this.countTextBox.Text = "60";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(765, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Количество линий";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(764, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Перерисовать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MinXText
            // 
            this.MinXText.Location = new System.Drawing.Point(756, 210);
            this.MinXText.Name = "MinXText";
            this.MinXText.Size = new System.Drawing.Size(100, 20);
            this.MinXText.TabIndex = 8;
            this.MinXText.Text = "-20";
            // 
            // MaxXText
            // 
            this.MaxXText.Location = new System.Drawing.Point(756, 262);
            this.MaxXText.Name = "MaxXText";
            this.MaxXText.Size = new System.Drawing.Size(100, 20);
            this.MaxXText.TabIndex = 9;
            this.MaxXText.Text = "20";
            // 
            // MinYText
            // 
            this.MinYText.Location = new System.Drawing.Point(756, 304);
            this.MinYText.Name = "MinYText";
            this.MinYText.Size = new System.Drawing.Size(100, 20);
            this.MinYText.TabIndex = 10;
            this.MinYText.Text = "-20";
            // 
            // MaxYText
            // 
            this.MaxYText.Location = new System.Drawing.Point(756, 343);
            this.MaxYText.Name = "MaxYText";
            this.MaxYText.Size = new System.Drawing.Size(100, 20);
            this.MaxYText.TabIndex = 11;
            this.MaxYText.Text = "20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(756, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "MinX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(756, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "MaxX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(756, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "MinY";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(756, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "MaxY";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Без сокрытия",
            "Плавающий горизонт",
            "Сетка",
            "Полутон"});
            this.comboBox1.Location = new System.Drawing.Point(764, 72);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 18;
            // 
            // axisCheckBox
            // 
            this.axisCheckBox.AutoSize = true;
            this.axisCheckBox.Location = new System.Drawing.Point(756, 387);
            this.axisCheckBox.Name = "axisCheckBox";
            this.axisCheckBox.Size = new System.Drawing.Size(46, 17);
            this.axisCheckBox.TabIndex = 19;
            this.axisCheckBox.Text = "Оси";
            this.axisCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 581);
            this.Controls.Add(this.axisCheckBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MaxYText);
            this.Controls.Add(this.MinYText);
            this.Controls.Add(this.MaxXText);
            this.Controls.Add(this.MinXText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox MinXText;
        private System.Windows.Forms.TextBox MaxXText;
        private System.Windows.Forms.TextBox MinYText;
        private System.Windows.Forms.TextBox MaxYText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox axisCheckBox;
    }
}

