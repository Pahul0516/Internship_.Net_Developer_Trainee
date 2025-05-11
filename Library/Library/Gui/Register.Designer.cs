namespace Library.Gui
{
    partial class Register
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
            label1 = new Label();
            textBoxName = new TextBox();
            textBoxEmail = new TextBox();
            textBoxPassword = new TextBox();
            btnRegister = new Button();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21F);
            label1.Location = new Point(290, 74);
            label1.Name = "label1";
            label1.Size = new Size(230, 74);
            label1.TabIndex = 0;
            label1.Text = "Register";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(303, 174);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(200, 39);
            textBoxName.TabIndex = 3;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(303, 237);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(200, 39);
            textBoxEmail.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(303, 305);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(200, 39);
            textBoxPassword.TabIndex = 5;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(327, 378);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 46);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(327, 450);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(158, 32);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Back to LogIn";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 588);
            Controls.Add(linkLabel1);
            Controls.Add(btnRegister);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            Name = "Register";
            Text = "Register";
            Load += Register_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxName;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private Button btnRegister;
        private LinkLabel linkLabel1;
    }
}