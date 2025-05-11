using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Library.Gui
{
    public partial class Login : Form
    {
        private Controller _controller;
        private static Login _instance;

        private Login(Controller controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        public static Login GetInstance(Controller controller)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new Login(controller);
            }

            return _instance;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            SetPlaceholder(textBoxEmail, "Email");
            SetPlaceholder(textBoxPassword, "Password");
            this.Focus();
            this.ActiveControl = null;
        }


        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            String password = textBoxPassword.Text;
            if (email == "Email" || password == "Password")
            {
                MessageBox.Show("Please enter your email and password.");
                return;
            }

            try
            {
                ValidationContext emailValidator = new ValidationContext(new EmailValidationStrategy());
                emailValidator.ExecuteValidation(email);
                ValidationContext passwordValidator = new ValidationContext(new PasswordValidationStrategy());
                passwordValidator.ExecuteValidation(password);
                LoginUser(email, password);

            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginUser(string email, string password)
        {
            if (email == "admin")
            {
                MessageBox.Show("Admin login successful!");
                var adminForm = new Admin(_controller);
                _controller.AddObserver(adminForm);
                adminForm.Show();
            }
            else
            {
                var user = _controller.GetUserByEmail(email);
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        MessageBox.Show("Login successful!");
                        var mainForm = new Home(_controller, user);
                        _controller.AddObserver(mainForm);
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid password.");
                    }
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var register = Register.GetInstance(_controller);
            register.Show();
        }
    }
}
