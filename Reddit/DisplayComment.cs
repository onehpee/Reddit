using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.XPath;

namespace Reddit
{
    public partial class DisplayComment : Panel
    {
        private bool _isUpvoted;
        private bool _isDownvoted;
        private Comment _panelComment;

        public DisplayComment(Comment comment)
        {
            InitializeComponent();
            _panelComment = comment;

            // Set Control Locations
            Upvote_Button.Location = new Point(0, 0);
            Score_Text_Box.Location = new Point(0, 30);
            Downvote_Button.Location = new Point(0, 50);
            Post_Info_Text_Box.Location = new Point(75, 0);
            Comments_Text_Box.Location = new Point(50, 150);
            Comments_Picture_Box.Location = new Point(30, 145);
            Content_Text_Box.Location = new Point(75, 75);
            Reply_Picture_Box.Location = new Point(180, 145);

            // Set all Text Boxes to readonly
            Score_Text_Box.ReadOnly = true;
            Post_Info_Text_Box.ReadOnly = true;
            Content_Text_Box.ReadOnly = true;

            // Add our up vote and down vote buttons
            Controls.Add(Upvote_Button);
            Controls.Add(Downvote_Button);

            // Add our comments "button" and icon
            var commentCount = 0;
            foreach (var reply in comment.commentReplies)
            {
                commentCount += CommentCount(reply);
            }

            Comments_Text_Box.Text = $"{commentCount} Comments";
            Controls.Add(Comments_Text_Box);
            Controls.Add(Comments_Picture_Box);

            // Set the score text and add the control
            Score_Text_Box.Text = comment.Score.ToString();
            Controls.Add(Score_Text_Box);

            // Set the posted info text and add the control
            var timeSpan = DateTime.Now.Subtract(comment.timeStamp);

            // Assign time since posted
            var timeSince = "";
            if (timeSpan.TotalHours < 1)
                timeSince = $"{(int)timeSpan.TotalMinutes} minutes ago";
            else if (timeSpan.TotalDays < 1)
                timeSince = $"{(int)timeSpan.TotalHours} hours ago";
            else if (timeSpan.TotalDays > 1)
                timeSince = $"{(int) timeSpan.TotalDays} days ago";

            // Set post info text and add the control
            Post_Info_Text_Box.Text = $"Commented by {Form1._users.FirstOrDefault(user => user.Id == comment.authorID).Name} {timeSince}";
            Controls.Add(Post_Info_Text_Box);

            // Set the Content text and add the control Defaulted to hidden control
            Content_Text_Box.Text = comment.Content;
            Controls.Add(Content_Text_Box);

            // Add the Reply picture box control
            Controls.Add(Reply_Picture_Box);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        /// <summary>
        ///     Recursive helper function to add comments
        /// </summary>
        /// <param name="parent">Parent comment</param>
        /// <param name="commentToAdd">Comment to be added to parent</param>
        /// <returns></returns>
        private static int CommentCount(Comment parent)
        {
            // When there's still replies
            if (parent.commentReplies.Count > 0)
                foreach (var currentComment in parent.commentReplies)
                    return 1 + CommentCount(parent.commentReplies.First());

            // Base case
            return 0;
        }


        // Upvote logic start
        private void Upvote_Button_MouseHover(object sender, EventArgs e)
        {
            if (!_isUpvoted)
                Upvote_Button.Image = Properties.Resources.upVote_red;
        }

        private void Upvote_Button_MouseLeave(object sender, EventArgs e)
        {
            if (!_isUpvoted)
                Upvote_Button.Image = Properties.Resources.upVote_grey;
        }

        private void Upvote_Button_Click(object sender, EventArgs e)
        {
            if (!_isUpvoted)
            {
                _isUpvoted = true;
                if (_isDownvoted)
                    Downvote_Button.Image = Properties.Resources.downVote_grey;
                Upvote_Button.Image = Properties.Resources.upVote_red;
            }
            else
            {
                _isUpvoted = false;
                Upvote_Button.Image = Properties.Resources.upVote_grey;
            }
        }
        
        // Downvote logic start
        private void Downvote_Button_MouseHover(object sender, EventArgs e)
        {
            if(!_isDownvoted)
                Downvote_Button.Image = Properties.Resources.downVote_blue;
        }

        private void Downvote_Button_MouseLeave(object sender, EventArgs e)
        {
            if (!_isDownvoted)
                Downvote_Button.Image = Properties.Resources.downVote_grey;
        }

        private void Downvote_Button_Click(object sender, EventArgs e)
        {
            if (!_isDownvoted)
            {
                _isDownvoted = true;
                if (_isUpvoted)
                    Upvote_Button.Image = Properties.Resources.upVote_grey;
                Downvote_Button.Image = Properties.Resources.downVote_blue;
            }
            else
            {
                _isDownvoted = false;
                Downvote_Button.Image = Properties.Resources.downVote_grey;
            }
        }

        private void Reply_Picture_Box_Click(object sender, EventArgs e)
        {
            // Create a new DisplayPost Object
            var currentCommentControl = new DisplayReplyTo(_panelComment)
            {
                Location = new Point(Location.X, Location.Y+200)
            };
            Controls.Add(currentCommentControl);
            // TODO: Adjust all other comment positions when we add this
        }
    }
}
