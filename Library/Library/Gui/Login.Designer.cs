namespace Library.Gui
{
    partial class Login
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
            textBoxEmail = new TextBox();
            textBoxPassword = new TextBox();
            btnLogin = new Button();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21F);
            label1.Location = new Point(161, 37);
            label1.Name = "label1";
            label1.Size = new Size(170, 74);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(140, 138);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(200, 39);
            textBoxEmail.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(140, 201);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(200, 39);
            textBoxPassword.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(170, 264);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 46);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "LogIn";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(117, 338);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(266, 32);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Don't have an account?";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // textBoxName
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 416);
            Controls.Add(linkLabel1);
            Controls.Add(btnLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxEmail);
            Controls.Add(label1);
            Name = "textBoxName";
            Text = "Form1";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private Button btnLogin;
        private LinkLabel linkLabel1;
    }
}