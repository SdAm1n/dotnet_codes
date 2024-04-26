using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailValidation
{
    public partial class Form1 : Form
    {
        private string email_regex = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        public Form1()
        {
            InitializeComponent();
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                NameerrorProvider.Icon = Properties.Resources.close;
                NameerrorProvider.SetError(this.textBox1, "Please enter your name");  
            }
            else
            {
                   NameerrorProvider.Clear();
            }
        }

        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                EmailerrorProvider.Icon = Properties.Resources.close;
                EmailerrorProvider.SetError(this.textBox2, "Please enter your email");
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, email_regex) == false)
                {
                    textBox2.Focus();
                    EmailerrorProvider.SetError(this.textBox2, "Please enter a valid email");
                }
                else
                {
                    EmailerrorProvider.Clear();
                }
            }

        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                EmailerrorProvider.Icon = Properties.Resources.close;
                NameerrorProvider.SetError(this.textBox1, "Please enter your name");
            }


            else if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, email_regex) == false)
            {
                textBox2.Focus();
                EmailerrorProvider.Icon = Properties.Resources.close;
                EmailerrorProvider.SetError(this.textBox2, "Please enter a valid email");
            }

            else
            { 
                MessageBox.Show("Thank you for submitting your information", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
