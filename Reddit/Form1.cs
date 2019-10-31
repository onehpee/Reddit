using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reddit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Search_Text_Box_Enter(object sender, EventArgs e)
        {
            if (Search_Text_Box.Text == "Search Reddit")
            {
                Search_Text_Box.Text = "";
            }
        }

        private void Search_Text_Box_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Search_Text_Box.Text))
                Search_Text_Box.Text = "Search Reddit";
        }
    }
}
