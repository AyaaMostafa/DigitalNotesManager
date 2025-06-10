using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalNotesManager.Services.Interfaces;
using DigitalNotesManager.Domain.DTOs;

namespace Presentation
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        private readonly INotesServices _notesService;
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Constructor: Initializes LoginForm with the required services.
        /// </summary>
        public LoginForm(
            IUserService userService,
            INotesServices notesService,
            ICategoryService categoryService)
        {
            InitializeComponent();
            _userService = userService;
            _notesService = notesService;
            _categoryService = categoryService;
        }

        /// <summary>
        /// Handles the Login button click event.
        /// Validates user input, calls login service, and opens MainForm on success.
        /// </summary>
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Warning");
                return;
            }

            var response = await _userService.LoginAsync(username, password);

            if (response.Status && response.Data != null)
            {
                MessageBox.Show($"Welcome {response.Data.UserName}", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MainForm mainForm = new MainForm(response.Data.Id, _notesService, _categoryService);
                mainForm.Show();

                this.Hide();
            }
            else
            {
                // Show clear error message for wrong username or password
                if (response.Message == "Password is wrong" || response.Message == "User is not found")
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(response.Message ?? "Login failed.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the Register button click event.
        /// Opens the RegisterForm and hides the LoginForm.
        /// </summary>
        private void btnToRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm(_userService, _notesService, _categoryService);
            registerForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the Cancel button click event and closes the application.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}