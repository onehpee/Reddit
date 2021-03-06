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

            // Display when Authenticated
            if (true)
            {
                // Show authenticated user
                // Display comments
                int[] position = {0, 0};
                foreach (var comment in post.postComments)
                {
                    // Create a new DisplayPost Object
                    var currentCommentControl = new DisplayComment(comment)
                    {
                        Location = new Point()
                    };
                    Content_Panel.Controls.Add(currentCommentControl);
                    position[1] += 100;
                }
            }
            else
            {
                User_Info_Comment_Box.Hide();
                Comments_Text_Box.Hide();
                Submit_Comment_Button.Hide();
            }
        }
    }
}
