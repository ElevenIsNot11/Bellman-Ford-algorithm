namespace BellmanFord
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DirectionsLB = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DotsLB = new System.Windows.Forms.ListBox();
            this.AddDirection = new System.Windows.Forms.Button();
            this.v = new System.Windows.Forms.Panel();
            this.DirectionLengthTB = new System.Windows.Forms.TextBox();
            this.Dot2CB = new System.Windows.Forms.ComboBox();
            this.Dot1CB = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DotNameTB = new System.Windows.Forms.TextBox();
            this.DotAdd = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Dot3CB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.v.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Вычислить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(131, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(196, 264);
            this.listBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(572, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Направления";
            // 
            // DirectionsLB
            // 
            this.DirectionsLB.FormattingEnabled = true;
            this.DirectionsLB.Items.AddRange(new object[] {
            "AB=7",
            "AC=5",
            "AD=6",
            "BE=4",
            "CF=3",
            "DF=9",
            "FI=4",
            "FH=5",
            "EH=8",
            "EG=6",
            "GJ=9",
            "HJ-7",
            "IJ=11"});
            this.DirectionsLB.Location = new System.Drawing.Point(575, 28);
            this.DirectionsLB.Name = "DirectionsLB";
            this.DirectionsLB.Size = new System.Drawing.Size(206, 225);
            this.DirectionsLB.TabIndex = 3;
            this.DirectionsLB.DoubleClick += new System.EventHandler(this.DirectionsLB_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(572, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Точки";
            // 
            // DotsLB
            // 
            this.DotsLB.FormattingEnabled = true;
            this.DotsLB.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J"});
            this.DotsLB.Location = new System.Drawing.Point(575, 279);
            this.DotsLB.Name = "DotsLB";
            this.DotsLB.Size = new System.Drawing.Size(206, 225);
            this.DotsLB.TabIndex = 5;
            this.DotsLB.DoubleClick += new System.EventHandler(this.DotsLB_DoubleClick);
            // 
            // AddDirection
            // 
            this.AddDirection.Location = new System.Drawing.Point(37, 48);
            this.AddDirection.Name = "AddDirection";
            this.AddDirection.Size = new System.Drawing.Size(86, 37);
            this.AddDirection.TabIndex = 6;
            this.AddDirection.Text = "Добавить направление";
            this.AddDirection.UseVisualStyleBackColor = true;
            this.AddDirection.Click += new System.EventHandler(this.button2_Click);
            // 
            // v
            // 
            this.v.Controls.Add(this.DirectionLengthTB);
            this.v.Controls.Add(this.AddDirection);
            this.v.Controls.Add(this.Dot2CB);
            this.v.Controls.Add(this.Dot1CB);
            this.v.Location = new System.Drawing.Point(383, 28);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(158, 100);
            this.v.TabIndex = 7;
            // 
            // DirectionLengthTB
            // 
            this.DirectionLengthTB.Location = new System.Drawing.Point(93, 12);
            this.DirectionLengthTB.Name = "DirectionLengthTB";
            this.DirectionLengthTB.Size = new System.Drawing.Size(59, 20);
            this.DirectionLengthTB.TabIndex = 2;
            // 
            // Dot2CB
            // 
            this.Dot2CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Dot2CB.FormattingEnabled = true;
            this.Dot2CB.Location = new System.Drawing.Point(48, 12);
            this.Dot2CB.Name = "Dot2CB";
            this.Dot2CB.Size = new System.Drawing.Size(39, 21);
            this.Dot2CB.TabIndex = 1;
            // 
            // Dot1CB
            // 
            this.Dot1CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Dot1CB.FormattingEnabled = true;
            this.Dot1CB.Location = new System.Drawing.Point(3, 12);
            this.Dot1CB.Name = "Dot1CB";
            this.Dot1CB.Size = new System.Drawing.Size(39, 21);
            this.Dot1CB.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DotNameTB);
            this.panel1.Controls.Add(this.DotAdd);
            this.panel1.Location = new System.Drawing.Point(386, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 100);
            this.panel1.TabIndex = 8;
            // 
            // DotNameTB
            // 
            this.DotNameTB.Location = new System.Drawing.Point(61, 22);
            this.DotNameTB.MaxLength = 1;
            this.DotNameTB.Name = "DotNameTB";
            this.DotNameTB.Size = new System.Drawing.Size(40, 20);
            this.DotNameTB.TabIndex = 2;
            this.DotNameTB.TextChanged += new System.EventHandler(this.DotNameTB_TextChanged);
            this.DotNameTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DotNameTB_KeyPress);
            // 
            // DotAdd
            // 
            this.DotAdd.Location = new System.Drawing.Point(37, 48);
            this.DotAdd.Name = "DotAdd";
            this.DotAdd.Size = new System.Drawing.Size(86, 37);
            this.DotAdd.TabIndex = 6;
            this.DotAdd.Text = "Добавить точку";
            this.DotAdd.UseVisualStyleBackColor = true;
            this.DotAdd.Click += new System.EventHandler(this.DotAdd_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(390, 144);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(159, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Неориентированный граф";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(29, 305);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(335, 264);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Dot3CB);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(383, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(158, 64);
            this.panel2.TabIndex = 11;
            // 
            // Dot3CB
            // 
            this.Dot3CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Dot3CB.FormattingEnabled = true;
            this.Dot3CB.Location = new System.Drawing.Point(7, 26);
            this.Dot3CB.Name = "Dot3CB";
            this.Dot3CB.Size = new System.Drawing.Size(39, 21);
            this.Dot3CB.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Стартовая точка";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.v);
            this.Controls.Add(this.DotsLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DirectionsLB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Нахождение путей до всех вершин графа";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.v.ResumeLayout(false);
            this.v.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox DirectionsLB;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListBox DotsLB;
        private System.Windows.Forms.Button AddDirection;
        private System.Windows.Forms.Panel v;
        private System.Windows.Forms.ComboBox Dot2CB;
        private System.Windows.Forms.ComboBox Dot1CB;
        private System.Windows.Forms.TextBox DirectionLengthTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox DotNameTB;
        private System.Windows.Forms.Button DotAdd;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox Dot3CB;
        private System.Windows.Forms.Label label3;
    }
}

