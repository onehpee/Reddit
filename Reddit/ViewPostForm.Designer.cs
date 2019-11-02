namespace Reddit
{
    partial class ViewPostForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewPostForm));
            this.Comments_Text_Box = new System.Windows.Forms.RichTextBox();
            this.Submit_Comment_Button = new System.Windows.Forms.Button();
            this.User_Info_Comment_Box = new System.Windows.Forms.RichTextBox();
            this.Content_Panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Comments_Text_Box
            // 
            this.Comments_Text_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.Comments_Text_Box.ForeColor = System.Drawing.Color.White;
            this.Comments_Text_Box.Location = new System.Drawing.Point(12, 217);
            this.Comments_Text_Box.Name = "Comments_Text_Box";
            this.Comments_Text_Box.Size = new System.Drawing.Size(402, 144);
            this.Comments_Text_Box.TabIndex = 0;
            this.Comments_Text_Box.Text = "";
            // 
            // Submit_Comment_Button
            // 
            this.Submit_Comment_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(225)))), ((int)(((byte)(227)))));
            this.Submit_Comment_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit_Comment_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(134)))), ((int)(((byte)(136)))));
            this.Submit_Comment_Button.Location = new System.Drawing.Point(309, 367);
            this.Submit_Comment_Button.Name = "Submit_Comment_Button";
            this.Submit_Comment_Button.Size = new System.Drawing.Size(105, 27);
            this.Submit_Comment_Button.TabIndex = 1;
            this.Submit_Comment_Button.Text = "Comment";
            this.Submit_Comment_Button.UseVisualStyleBackColor = false;
            // 
            // User_Info_Comment_Box
            // 
            this.User_Info_Comment_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.User_Info_Comment_Box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.User_Info_Comment_Box.ForeColor = System.Drawing.Color.White;
            this.User_Info_Comment_Box.Location = new System.Drawing.Point(12, 186);
            this.User_Info_Comment_Box.Name = "User_Info_Comment_Box";
            this.User_Info_Comment_Box.ReadOnly = true;
            this.User_Info_Comment_Box.Size = new System.Drawing.Size(145, 25);
            this.User_Info_Comment_Box.TabIndex = 2;
            this.User_Info_Comment_Box.Text = "";
            // 
            // Content_Panel
            // 
            this.Content_Panel.AutoScroll = true;
            this.Content_Panel.Location = new System.Drawing.Point(13, 401);
            this.Content_Panel.Name = "Content_Panel";
            this.Content_Panel.Size = new System.Drawing.Size(641, 247);
            this.Content_Panel.TabIndex = 3;
            // 
            // ViewPostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.ClientSize = new System.Drawing.Size(666, 660);
            this.Controls.Add(this.Content_Panel);
            this.Controls.Add(this.User_Info_Comment_Box);
            this.Controls.Add(this.Submit_Comment_Button);
            this.Controls.Add(this.Comments_Text_Box);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewPostForm";
            this.Text = "ViewPostForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Comments_Text_Box;
        private System.Windows.Forms.Button Submit_Comment_Button;
        private System.Windows.Forms.RichTextBox User_Info_Comment_Box;
        private System.Windows.Forms.Panel Content_Panel;
    }
}