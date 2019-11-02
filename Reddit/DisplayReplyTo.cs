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
    public partial class DisplayReplyTo : Panel
    {
        private Comment _panelComment;

        public DisplayReplyTo(Comment comment)
        {
            InitializeComponent();
            _panelComment = comment;

            // Set Control Locations
            Comments_Text_Box.Location = new Point(0,0);
            Submit_Comment_Button.Location = new Point(300, 350);

            // Add controls
            Controls.Add(Comments_Text_Box);
            Controls.Add(Submit_Comment_Button);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
