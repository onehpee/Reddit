﻿using System;
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
    public partial class ViewPostForm : Form
    {
        private Post _post;
        public ViewPostForm(Post post)
        {
            InitializeComponent();
            // Create a new DisplayPost Object
            var currentPostControl = new DisplayPost(post, true)
            {
                Location = new Point(0, 0)
            };
            Controls.Add(currentPostControl);
        }
    }
}
