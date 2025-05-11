using Library.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Gui
{
    public partial class Register : Form
    {

        private static Register _instance;
        private Controller _controller;

        private Register(Controller controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        public static Register GetInstance(Controller controller)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new Register(controller);
            }

            return _instance;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var login = Login.GetInstance(_controller);
            login.Show();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            SetPlaceholder(textBoxName, "Name");
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            String name = textBoxName.Text;
            String email = textBoxEmail.Text;
            String password = textBoxPassword.Text;
            try
            {
                ValidationContext validator = new ValidationContext(new EmailRegisterValidationStrategy(_controller.getUserRepo()));
                validator.ExecuteValidation(email);
                validator.SetStrategy(new PasswordRegisterValidationStrategy(_controller.getUserRepo()));
                validator.ExecuteValidation(password);

                _controller.addUser(name, email, password);

                this.Hide();
                var login = Login.GetInstance(_controller);
                login.Show();
               

            }catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
