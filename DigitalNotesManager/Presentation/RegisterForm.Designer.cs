namespace Presentation
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnToLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            lblTitle = new Label();
            lblUserName = new Label();
            txtUserName = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            btnToLogin = new Button();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.None;
            mainPanel.BackColor = Color.FromArgb(231, 231, 231);
            mainPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(lblUserName);
            mainPanel.Controls.Add(txtUserName);
            mainPanel.Controls.Add(lblPassword);
            mainPanel.Controls.Add(txtPassword);
            mainPanel.Controls.Add(lblConfirmPassword);
            mainPanel.Controls.Add(txtConfirmPassword);
            mainPanel.Controls.Add(btnRegister);
            mainPanel.Controls.Add(btnToLogin);
            mainPanel.Location = new Point(25, 37);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(16);
            mainPanel.Size = new Size(330, 360);
            mainPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(34, 112, 220);
            lblTitle.Location = new Point(16, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(296, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Register Now";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            lblUserName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUserName.ForeColor = Color.DimGray;
            lblUserName.Location = new Point(10, 70);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(120, 24);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Username";
            // 
            // txtUserName
            // 
            txtUserName.BackColor = Color.White;
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Font = new Font("Segoe UI", 11F);
            txtUserName.Location = new Point(10, 95);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Enter your username";
            txtUserName.Size = new Size(295, 32);
            txtUserName.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.DimGray;
            lblPassword.Location = new Point(10, 135);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(120, 24);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(10, 160);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.Size = new Size(295, 32);
            txtPassword.TabIndex = 4;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.DimGray;
            lblConfirmPassword.Location = new Point(10, 200);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(140, 24);
            lblConfirmPassword.TabIndex = 5;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.White;
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Segoe UI", 11F);
            txtConfirmPassword.Location = new Point(10, 225);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.PlaceholderText = "Re-enter your password";
            txtConfirmPassword.Size = new Size(295, 32);
            txtConfirmPassword.TabIndex = 6;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(34, 112, 220);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(10, 275);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(295, 40);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnToLogin
            // 
            btnToLogin.BackColor = Color.Transparent;
            btnToLogin.Cursor = Cursors.Hand;
            btnToLogin.FlatAppearance.BorderSize = 0;
            btnToLogin.FlatStyle = FlatStyle.Flat;
            btnToLogin.Font = new Font("Segoe UI", 9F);
            btnToLogin.ForeColor = Color.FromArgb(34, 112, 220);
            btnToLogin.Location = new Point(10, 320);
            btnToLogin.Name = "btnToLogin";
            btnToLogin.Size = new Size(295, 28);
            btnToLogin.TabIndex = 8;
            btnToLogin.Text = "Already have an account? Login";
            btnToLogin.UseVisualStyleBackColor = false;
            btnToLogin.Click += btnToLogin_Click;
            // 
            // RegisterForm
            // 
            BackColor = Color.FromArgb(245, 248, 255);
            ClientSize = new Size(380, 434);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register New User";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}