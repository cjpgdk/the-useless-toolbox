using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IsMatch_Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = textBox1.Text;
            string input = textBox2.Text;
            try
            {
                if (Regex.IsMatch(input, pattern))
                {
                    MessageBox.Show("IsMatch: Yes");
                }
                else
                {
                    MessageBox.Show("IsMatch: No");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
