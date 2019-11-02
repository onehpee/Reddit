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
    public partial class Log_In_Form : Form
    {
        private static SortedSet<Subreddit> _subreddits;
        private static SortedSet<User> _users;
        private static Subreddit _selectedSubreddit;
        private static Post _selectedPost;
        private static uint _selectedCommentId;
        private static User _selectedUser;
        private static User _authenticatedUser;
        private static SortedSet<Post> _collectivePosts;
        private Label label1;
        private Label label2;
        public TextBox User_Name_Textbox;
        public TextBox Password_Textbox;
        public Button Log_In_Button;

        public Log_In_Form()
        {
            InitializeComponent();
            _subreddits = new SortedSet<Subreddit>();
            _users = new SortedSet<User>();
            _selectedSubreddit = new Subreddit();
            _selectedPost = new Post();
            _authenticatedUser = new User();
            _selectedCommentId = 0;
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.User_Name_Textbox = new System.Windows.Forms.TextBox();
            this.Password_Textbox = new System.Windows.Forms.TextBox();
            this.Log_In_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "USER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // User_Name_Textbox
            // 
            this.User_Name_Textbox.Location = new System.Drawing.Point(118, 28);
            this.User_Name_Textbox.Name = "User_Name_Textbox";
            this.User_Name_Textbox.Size = new System.Drawing.Size(144, 20);
            this.User_Name_Textbox.TabIndex = 2;
            // 
            // Password_Textbox
            // 
            this.Password_Textbox.Location = new System.Drawing.Point(122, 66);
            this.Password_Textbox.Name = "Password_Textbox";
            this.Password_Textbox.PasswordChar = '*';
            this.Password_Textbox.Size = new System.Drawing.Size(140, 20);
            this.Password_Textbox.TabIndex = 3;
            // 
            // Log_In_Button
            // 
            this.Log_In_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Log_In_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Log_In_Button.Location = new System.Drawing.Point(118, 108);
            this.Log_In_Button.Name = "Log_In_Button";
            this.Log_In_Button.Size = new System.Drawing.Size(78, 28);
            this.Log_In_Button.TabIndex = 4;
            this.Log_In_Button.Text = "Log-In";
            this.Log_In_Button.UseVisualStyleBackColor = true;
            // 
            // Log_In_Form
            // 
            this.ClientSize = new System.Drawing.Size(301, 139);
            this.Controls.Add(this.Log_In_Button);
            this.Controls.Add(this.Password_Textbox);
            this.Controls.Add(this.User_Name_Textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Log_In_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        public string LogInFormUser
        {
            get { return User_Name_Textbox.Text; }

        }

        public string LogInFormPass
        {
            get { return Password_Textbox.Text.GetHashCode().ToString("X"); }

        }


    }
    


    
}
