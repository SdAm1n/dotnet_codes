using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageWall
{
    public partial class Dashboard : Form
    {
        BindingList<string> list = new BindingList<string>();

        public Dashboard()
        {
            InitializeComponent();
            wireUp();
        }

        private void wireUp()
        {
            MessageListBox.DataSource = list;
        }

        private void AddButton(object sender, EventArgs e)
        {
           if (string.IsNullOrWhiteSpace(MessageBoxText.Text))
            {
                MessageBox.Show("Invalid Input", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                list.Add(MessageBoxText.Text);
                MessageBoxText.Text = "";
                MessageBoxText.Focus();
            }
        }

    }
}
