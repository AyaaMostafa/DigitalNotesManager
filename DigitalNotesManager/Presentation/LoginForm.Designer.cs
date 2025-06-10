namespace Presentation
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnToRegister;
        private System.Windows.Forms.PictureBox logoBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            mainPanel = new Panel();
            logoBox = new PictureBox();
            lblTitle = new Label();
            lblUserName = new Label();
            txtUserName = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnToRegister = new Button();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.None;
            mainPanel.BackColor = Color.FromArgb(231, 231, 231);
            mainPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(logoBox);
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(lblUserName);
            mainPanel.Controls.Add(txtUserName);
            mainPanel.Controls.Add(lblPassword);
            mainPanel.Controls.Add(txtPassword);
            mainPanel.Controls.Add(btnLogin);
            mainPanel.Controls.Add(btnToRegister);
            mainPanel.Location = new Point(20, 7);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(16);
            mainPanel.Size = new Size(340, 397);
            mainPanel.TabIndex = 0;
            // 
            // logoBox
            // 
            logoBox.Image = (Image)resources.GetObject("logoBox.Image");
            logoBox.Location = new Point(118, 19);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(95, 86);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(34, 112, 220);
            lblTitle.Location = new Point(30, 108);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 40);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Welcome Back!";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            lblUserName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUserName.ForeColor = Color.Gray;
            lblUserName.Location = new Point(28, 148);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(120, 25);
            lblUserName.TabIndex = 2;
            lblUserName.Text = "Username";
            // 
            // txtUserName
            // 
            txtUserName.BackColor = Color.White;
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Font = new Font("Segoe UI", 12F);
            txtUserName.Location = new Point(28, 175);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Enter your username";
            txtUserName.Size = new Size(280, 34);
            txtUserName.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.Gray;
            lblPassword.Location = new Point(28, 218);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(120, 25);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(28, 245);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.Size = new Size(280, 34);
            txtPassword.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(34, 112, 220);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(28, 318);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(135, 44);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnToRegister
            // 
            btnToRegister.BackColor = Color.White;
            btnToRegister.Cursor = Cursors.Hand;
            btnToRegister.FlatAppearance.BorderSize = 0;
            btnToRegister.FlatStyle = FlatStyle.Flat;
            btnToRegister.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnToRegister.ForeColor = Color.FromArgb(34, 112, 220);
            btnToRegister.Location = new Point(175, 318);
            btnToRegister.Name = "btnToRegister";
            btnToRegister.Size = new Size(135, 44);
            btnToRegister.TabIndex = 8;
            btnToRegister.Text = "or Register";
            btnToRegister.UseVisualStyleBackColor = false;
            btnToRegister.Click += btnToRegister_Click;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 255);
            ClientSize = new Size(380, 434);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
        }
    }
}