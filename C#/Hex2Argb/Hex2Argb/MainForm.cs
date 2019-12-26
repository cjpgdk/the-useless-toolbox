using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hex2Argb.exe
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            try
            {
                Color c = ColorTranslator.FromHtml(textBoxExt1.Text);
                autoLabel6.BackColor = c;

                A.Value = Convert.ToDecimal(c.A);
                R.Value = Convert.ToDecimal(c.R);
                G.Value = Convert.ToDecimal(c.G);
                B.Value = Convert.ToDecimal(c.B);

                textBoxExt2.Text = A.Value.ToString() + "; "
                    + R.Value.ToString() + "; "
                    + G.Value.ToString() + "; "
                    + B.Value.ToString();

                textBoxExt3.Text = A.Value.ToString() + ", "
                    + R.Value.ToString() + ", "
                    + G.Value.ToString() + ", "
                    + B.Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void textBoxExt1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Color c = ColorTranslator.FromHtml(textBoxExt1.Text);
                autoLabel6.BackColor = c;

                A.Value = Convert.ToDecimal(c.A);
                R.Value = Convert.ToDecimal(c.R);
                G.Value = Convert.ToDecimal(c.G);
                B.Value = Convert.ToDecimal(c.B);

                textBoxExt2.Text = A.Value.ToString() + "; "
                    + R.Value.ToString() + "; "
                    + G.Value.ToString() + "; "
                    + B.Value.ToString();

                textBoxExt3.Text = A.Value.ToString() + ", "
                    + R.Value.ToString() + ", "
                    + G.Value.ToString() + ", "
                    + B.Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void A_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxExt1.Text = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
                     Convert.ToByte(A.Value), Convert.ToByte(R.Value),
                     Convert.ToByte(G.Value), Convert.ToByte(B.Value));
            }
            catch (Exception ex)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }
    }
}
