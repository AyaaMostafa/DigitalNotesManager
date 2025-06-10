using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalNotesManager.Domain.Models;
using DigitalNotesManager.Services.Interfaces;

namespace Presentation
{
    public partial class RegisterForm : Form
    {
        private readonly IUserService _userService;
        private readonly INotesServices _notesService;
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Constructor: Initializes RegisterForm with the required services.
        /// </summary>
        public RegisterForm(
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
        /// Handles the Register button click event.
        /// Validates input, registers the user, and opens LoginForm on success.
        /// </summary>
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUserName.Text.Trim();
            var password = txtPassword.Text;
            var confirmPassword = txtConfirmPassword.Text;

            // Input validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Warning");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Warning");
                return;
            }

            var user = new User
            {
                UserName = username,
                PasswordHash = password // You might want to hash the password in the service
            };

            // Call the backend service
            var response = await _userService.RegisterAsync(user);

            if (response.Status)
            {
                MessageBox.Show(response.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var loginForm = new LoginForm(_userService, _notesService, _categoryService);
                loginForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the "Back to Login" button click event.
        /// Opens the LoginForm and hides the RegisterForm.
        /// </summary>
        private void btnToLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(_userService, _notesService, _categoryService);
            loginForm.Show();
            this.Hide();
        }
    }
}