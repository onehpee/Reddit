namespace Reddit
{
    partial class DisplayReplyTo
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
            this.Submit_Comment_Button = new System.Windows.Forms.Button();
            this.Comments_Text_Box = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
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
            // DisplayReplyTo
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(500, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Submit_Comment_Button;
        private System.Windows.Forms.RichTextBox Comments_Text_Box;
    }
}
