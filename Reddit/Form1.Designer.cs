﻿namespace Reddit
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Reddit_Picture_Box = new System.Windows.Forms.PictureBox();
            this.Search_Text_Box = new System.Windows.Forms.RichTextBox();
            this.Subreddits_Combo_Box = new System.Windows.Forms.ComboBox();
            this.Login_Button = new System.Windows.Forms.Button();
            this.Content_Panel = new System.Windows.Forms.Panel();
            this.Navbar_Group_Box = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Reddit_Picture_Box)).BeginInit();
            this.Navbar_Group_Box.SuspendLayout();
            this.SuspendLayout();
            // 
            // Reddit_Picture_Box
            // 
            this.Reddit_Picture_Box.Image = ((System.Drawing.Image)(resources.GetObject("Reddit_Picture_Box.Image")));
            this.Reddit_Picture_Box.ImageLocation = "Images/logo.png";
            this.Reddit_Picture_Box.InitialImage = ((System.Drawing.Image)(resources.GetObject("Reddit_Picture_Box.InitialImage")));
            this.Reddit_Picture_Box.Location = new System.Drawing.Point(6, 10);
            this.Reddit_Picture_Box.Name = "Reddit_Picture_Box";
            this.Reddit_Picture_Box.Size = new System.Drawing.Size(110, 43);
            this.Reddit_Picture_Box.TabIndex = 0;
            this.Reddit_Picture_Box.TabStop = false;
            // 
            // Search_Text_Box
            // 
            this.Search_Text_Box.Location = new System.Drawing.Point(334, 20);
            this.Search_Text_Box.Name = "Search_Text_Box";
            this.Search_Text_Box.Size = new System.Drawing.Size(333, 33);
            this.Search_Text_Box.TabIndex = 1;
            this.Search_Text_Box.Text = "";
            this.Search_Text_Box.WordWrap = false;
            // 
            // Subreddits_Combo_Box
            // 
            this.Subreddits_Combo_Box.FormattingEnabled = true;
            this.Subreddits_Combo_Box.Location = new System.Drawing.Point(122, 32);
            this.Subreddits_Combo_Box.Name = "Subreddits_Combo_Box";
            this.Subreddits_Combo_Box.Size = new System.Drawing.Size(206, 21);
            this.Subreddits_Combo_Box.TabIndex = 2;
            // 
            // Login_Button
            // 
            this.Login_Button.Location = new System.Drawing.Point(911, 18);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(68, 34);
            this.Login_Button.TabIndex = 3;
            this.Login_Button.Text = "Login";
            this.Login_Button.UseVisualStyleBackColor = true;
            // 
            // Content_Panel
            // 
            this.Content_Panel.AutoScroll = true;
            this.Content_Panel.Location = new System.Drawing.Point(13, 76);
            this.Content_Panel.Name = "Content_Panel";
            this.Content_Panel.Size = new System.Drawing.Size(966, 548);
            this.Content_Panel.TabIndex = 4;
            // 
            // Navbar_Group_Box
            // 
            this.Navbar_Group_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Navbar_Group_Box.Controls.Add(this.Login_Button);
            this.Navbar_Group_Box.Controls.Add(this.Reddit_Picture_Box);
            this.Navbar_Group_Box.Controls.Add(this.Search_Text_Box);
            this.Navbar_Group_Box.Controls.Add(this.Subreddits_Combo_Box);
            this.Navbar_Group_Box.Location = new System.Drawing.Point(0, -6);
            this.Navbar_Group_Box.Name = "Navbar_Group_Box";
            this.Navbar_Group_Box.Size = new System.Drawing.Size(992, 59);
            this.Navbar_Group_Box.TabIndex = 0;
            this.Navbar_Group_Box.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(991, 636);
            this.Controls.Add(this.Content_Panel);
            this.Controls.Add(this.Navbar_Group_Box);
            this.Name = "Form1";
            this.Text = "Reddit";
            ((System.ComponentModel.ISupportInitialize)(this.Reddit_Picture_Box)).EndInit();
            this.Navbar_Group_Box.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Reddit_Picture_Box;
        private System.Windows.Forms.RichTextBox Search_Text_Box;
        private System.Windows.Forms.ComboBox Subreddits_Combo_Box;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.Panel Content_Panel;
        private System.Windows.Forms.GroupBox Navbar_Group_Box;
    }
}

