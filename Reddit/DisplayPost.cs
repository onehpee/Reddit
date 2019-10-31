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
    public partial class DisplayPost : Panel
    {
        public DisplayPost(Post post)
        {
            InitializeComponent();

            // Set Control Locations
            Upvote_Button.Location = new Point(0, 0);
            Downvote_Button.Location = new Point(0, 25);
            Post_Info_Text_Box.Location = new Point(75, 0);
            Title_Text_Box.Location = new Point(75, 25);
            

            // Add our up vote and down vote buttons
            Controls.Add(Upvote_Button);
            Controls.Add(Downvote_Button);

            // Set the posted info text and add the control
            var timeSpan = DateTime.Now.Subtract(post.timeStamp);

            // Assign time since posted
            var timeSince = "";
            if (timeSpan.TotalHours < 1)
                timeSince = $"{(int)timeSpan.TotalMinutes} minutes ago";
            else if (timeSpan.TotalDays < 1)
                timeSince = $"{(int)timeSpan.TotalHours} hours ago";
            else if (timeSpan.TotalDays > 1)
                timeSince = $"{(int) timeSpan.TotalDays} days ago";

            // Set post info text and add the control
            Post_Info_Text_Box.Text = $"{"/r/all"} * Posted by {post.authorID.ToString()} {timeSince}";
            Controls.Add(Post_Info_Text_Box);

            // Set the Title text and add the control
            Title_Text_Box.Text = post.Title;
            Controls.Add(Title_Text_Box);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
