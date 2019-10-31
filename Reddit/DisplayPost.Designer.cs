namespace Reddit
{
    partial class DisplayPost
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Post_Info_Text_Box = new System.Windows.Forms.RichTextBox();
            this.Title_Text_Box = new System.Windows.Forms.RichTextBox();
            this.Downvote_Button = new System.Windows.Forms.Button();
            this.Upvote_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Post_Info_Text_Box
            // 
            this.Post_Info_Text_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Post_Info_Text_Box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Post_Info_Text_Box.ForeColor = System.Drawing.Color.White;
            this.Post_Info_Text_Box.Location = new System.Drawing.Point(0, 0);
            this.Post_Info_Text_Box.Name = "Post_Info_Text_Box";
            this.Post_Info_Text_Box.Size = new System.Drawing.Size(300, 23);
            this.Post_Info_Text_Box.TabIndex = 0;
            this.Post_Info_Text_Box.Text = "";
            // 
            // Title_Text_Box
            // 
            this.Title_Text_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Title_Text_Box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Title_Text_Box.ForeColor = System.Drawing.Color.White;
            this.Title_Text_Box.Location = new System.Drawing.Point(0, 0);
            this.Title_Text_Box.Name = "Title_Text_Box";
            this.Title_Text_Box.Size = new System.Drawing.Size(300, 23);
            this.Title_Text_Box.TabIndex = 0;
            this.Title_Text_Box.Text = "";
            // 
            // Downvote_Button
            // 
            this.Downvote_Button.BackColor = System.Drawing.Color.Transparent;
            this.Downvote_Button.FlatAppearance.BorderSize = 0;
            this.Downvote_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Downvote_Button.Image = global::Reddit.Properties.Resources.downVote_grey;
            this.Downvote_Button.Location = new System.Drawing.Point(0, 0);
            this.Downvote_Button.Name = "Downvote_Button";
            this.Downvote_Button.Size = new System.Drawing.Size(21, 21);
            this.Downvote_Button.TabIndex = 0;
            this.Downvote_Button.TabStop = false;
            this.Downvote_Button.UseVisualStyleBackColor = false;
            this.Downvote_Button.Click += new System.EventHandler(this.Downvote_Button_Click);
            this.Downvote_Button.MouseLeave += new System.EventHandler(this.Downvote_Button_MouseLeave);
            this.Downvote_Button.MouseHover += new System.EventHandler(this.Downvote_Button_MouseHover);
            // 
            // Upvote_Button
            // 
            this.Upvote_Button.BackColor = System.Drawing.Color.Transparent;
            this.Upvote_Button.FlatAppearance.BorderSize = 0;
            this.Upvote_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Upvote_Button.Image = global::Reddit.Properties.Resources.upVote_grey;
            this.Upvote_Button.Location = new System.Drawing.Point(0, 0);
            this.Upvote_Button.Name = "Upvote_Button";
            this.Upvote_Button.Size = new System.Drawing.Size(21, 21);
            this.Upvote_Button.TabIndex = 0;
            this.Upvote_Button.TabStop = false;
            this.Upvote_Button.UseVisualStyleBackColor = false;
            this.Upvote_Button.Click += new System.EventHandler(this.Upvote_Button_Click);
            this.Upvote_Button.MouseLeave += new System.EventHandler(this.Upvote_Button_MouseLeave);
            this.Upvote_Button.MouseHover += new System.EventHandler(this.Upvote_Button_MouseHover);
            // 
            // DisplayPost
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(350, 175);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Upvote_Button;
        private System.Windows.Forms.Button Downvote_Button;
        private System.Windows.Forms.RichTextBox Post_Info_Text_Box;
        private System.Windows.Forms.RichTextBox Title_Text_Box;
    }
}
