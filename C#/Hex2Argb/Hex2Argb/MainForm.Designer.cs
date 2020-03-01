namespace Hex2Argb.exe
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.autoLabel1 = new System.Windows.Forms.Label();
            this.textBoxExt1 = new System.Windows.Forms.TextBox();
            this.A = new System.Windows.Forms.NumericUpDown();
            this.autoLabel2 = new System.Windows.Forms.Label();
            this.autoLabel3 = new System.Windows.Forms.Label();
            this.R = new System.Windows.Forms.NumericUpDown();
            this.autoLabel4 = new System.Windows.Forms.Label();
            this.G = new System.Windows.Forms.NumericUpDown();
            this.autoLabel5 = new System.Windows.Forms.Label();
            this.B = new System.Windows.Forms.NumericUpDown();
            this.autoLabel6 = new System.Windows.Forms.Label();
            this.textBoxExt2 = new System.Windows.Forms.TextBox();
            this.textBoxExt3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B)).BeginInit();
            this.SuspendLayout();
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(10, 9);
            this.autoLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(27, 14);
            this.autoLabel1.TabIndex = 2;
            this.autoLabel1.Text = "Hex:";
            // 
            // textBoxExt1
            // 
            this.textBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxExt1.Location = new System.Drawing.Point(40, 7);
            this.textBoxExt1.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxExt1.Name = "textBoxExt1";
            this.textBoxExt1.Size = new System.Drawing.Size(241, 20);
            this.textBoxExt1.TabIndex = 3;
            this.textBoxExt1.Text = "#adffa2";
            this.textBoxExt1.TextChanged += new System.EventHandler(this.textBoxExt1_TextChanged);
            // 
            // A
            // 
            this.A.Location = new System.Drawing.Point(40, 30);
            this.A.Margin = new System.Windows.Forms.Padding(2);
            this.A.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(42, 20);
            this.A.TabIndex = 4;
            this.A.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.A.ValueChanged += new System.EventHandler(this.A_ValueChanged);
            // 
            // autoLabel2
            // 
            this.autoLabel2.Location = new System.Drawing.Point(22, 32);
            this.autoLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(16, 14);
            this.autoLabel2.TabIndex = 5;
            this.autoLabel2.Text = "A:";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Location = new System.Drawing.Point(87, 32);
            this.autoLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(16, 14);
            this.autoLabel3.TabIndex = 7;
            this.autoLabel3.Text = "R:";
            // 
            // R
            // 
            this.R.Location = new System.Drawing.Point(106, 30);
            this.R.Margin = new System.Windows.Forms.Padding(2);
            this.R.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.R.Name = "R";
            this.R.Size = new System.Drawing.Size(42, 20);
            this.R.TabIndex = 6;
            this.R.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.R.ValueChanged += new System.EventHandler(this.A_ValueChanged);
            // 
            // autoLabel4
            // 
            this.autoLabel4.Location = new System.Drawing.Point(153, 32);
            this.autoLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(17, 14);
            this.autoLabel4.TabIndex = 9;
            this.autoLabel4.Text = "G:";
            // 
            // G
            // 
            this.G.Location = new System.Drawing.Point(173, 30);
            this.G.Margin = new System.Windows.Forms.Padding(2);
            this.G.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(42, 20);
            this.G.TabIndex = 8;
            this.G.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.G.ValueChanged += new System.EventHandler(this.A_ValueChanged);
            // 
            // autoLabel5
            // 
            this.autoLabel5.Location = new System.Drawing.Point(220, 32);
            this.autoLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel5.Name = "autoLabel5";
            this.autoLabel5.Size = new System.Drawing.Size(16, 14);
            this.autoLabel5.TabIndex = 11;
            this.autoLabel5.Text = "B:";
            // 
            // B
            // 
            this.B.Location = new System.Drawing.Point(238, 30);
            this.B.Margin = new System.Windows.Forms.Padding(2);
            this.B.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(42, 20);
            this.B.TabIndex = 10;
            this.B.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.B.ValueChanged += new System.EventHandler(this.A_ValueChanged);
            // 
            // autoLabel6
            // 
            this.autoLabel6.Location = new System.Drawing.Point(286, 9);
            this.autoLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel6.Name = "autoLabel6";
            this.autoLabel6.Size = new System.Drawing.Size(38, 82);
            this.autoLabel6.TabIndex = 12;
            // 
            // textBoxExt2
            // 
            this.textBoxExt2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxExt2.Location = new System.Drawing.Point(40, 53);
            this.textBoxExt2.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxExt2.Name = "textBoxExt2";
            this.textBoxExt2.Size = new System.Drawing.Size(241, 20);
            this.textBoxExt2.TabIndex = 13;
            this.textBoxExt2.Text = "255; 255; 255; 255";
            // 
            // textBoxExt3
            // 
            this.textBoxExt3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxExt3.Location = new System.Drawing.Point(40, 76);
            this.textBoxExt3.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxExt3.Name = "textBoxExt3";
            this.textBoxExt3.Size = new System.Drawing.Size(241, 20);
            this.textBoxExt3.TabIndex = 14;
            this.textBoxExt3.Text = "255, 255, 255, 255";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(311, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Set Background";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.SystemColors.Control;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 128);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxExt3);
            this.Controls.Add(this.textBoxExt2);
            this.Controls.Add(this.autoLabel6);
            this.Controls.Add(this.autoLabel5);
            this.Controls.Add(this.B);
            this.Controls.Add(this.autoLabel4);
            this.Controls.Add(this.G);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.R);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.A);
            this.Controls.Add(this.textBoxExt1);
            this.Controls.Add(this.autoLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(350, 167);
            this.MinimumSize = new System.Drawing.Size(350, 167);
            this.Name = "Form1";
            this.Text = "Hex<2>ARGB";
            ((System.ComponentModel.ISupportInitialize)(this.A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label autoLabel1;
        private System.Windows.Forms.TextBox textBoxExt1;
        private System.Windows.Forms.NumericUpDown A;
        private System.Windows.Forms.Label autoLabel2;
        private System.Windows.Forms.Label autoLabel3;
        private System.Windows.Forms.NumericUpDown R;
        private System.Windows.Forms.Label autoLabel4;
        private System.Windows.Forms.NumericUpDown G;
        private System.Windows.Forms.Label autoLabel5;
        private System.Windows.Forms.NumericUpDown B;
        private System.Windows.Forms.Label autoLabel6;
        private System.Windows.Forms.TextBox textBoxExt2;
        private System.Windows.Forms.TextBox textBoxExt3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

