namespace Presentation
{
    partial class AddNoteForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            formattingToolStrip = new ToolStrip();
            editDropDown = new ToolStripDropDownButton();
            fontStyleDropDown = new ToolStripDropDownButton();
            colorDropDown = new ToolStripDropDownButton();
            titleTxt = new TextBox();
            CategoryCombo = new ComboBox();
            contentBox = new RichTextBox();
            DateTimePickerReminder = new DateTimePicker();
            SaveAsTxtBtn = new Button();
            cancelBtn = new Button();
            CategoryLab = new Label();
            ReminderLab = new Label();
            TitleTab = new Label();
            fontDialog = new FontDialog();
            colorDialog = new ColorDialog();
            AddBtn = new Button();
            AddCategoryBtn = new Button();
            toolTip1 = new ToolTip(components);
            formattingToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // formattingToolStrip
            // 
            formattingToolStrip.BackColor = Color.WhiteSmoke;
            formattingToolStrip.ImageScalingSize = new Size(20, 20);
            formattingToolStrip.Items.AddRange(new ToolStripItem[] { editDropDown, fontStyleDropDown, colorDropDown });
            formattingToolStrip.Location = new Point(0, 0);
            formattingToolStrip.Name = "formattingToolStrip";
            formattingToolStrip.Size = new Size(550, 32);
            formattingToolStrip.TabIndex = 101;
            formattingToolStrip.Text = "formattingToolStrip";
            // 
            // editDropDown
            // 
            editDropDown.DisplayStyle = ToolStripItemDisplayStyle.Text;
            editDropDown.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            editDropDown.Name = "editDropDown";
            editDropDown.Size = new Size(81, 29);
            editDropDown.Text = "Edit ▼";
            // 
            // fontStyleDropDown
            // 
            fontStyleDropDown.DisplayStyle = ToolStripItemDisplayStyle.Text;
            fontStyleDropDown.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            fontStyleDropDown.Name = "fontStyleDropDown";
            fontStyleDropDown.Size = new Size(136, 29);
            fontStyleDropDown.Text = "Font Style ▼";
            // 
            // colorDropDown
            // 
            colorDropDown.DisplayStyle = ToolStripItemDisplayStyle.Text;
            colorDropDown.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            colorDropDown.Name = "colorDropDown";
            colorDropDown.Size = new Size(96, 29);
            colorDropDown.Text = "Color ▼";
            // 
            // titleTxt
            // 
            titleTxt.Font = new Font("Segoe UI", 11F);
            titleTxt.Location = new Point(196, 76);
            titleTxt.Name = "titleTxt";
            titleTxt.Size = new Size(200, 32);
            titleTxt.TabIndex = 6;
            // 
            // CategoryCombo
            // 
            CategoryCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            CategoryCombo.Font = new Font("Segoe UI", 11F);
            CategoryCombo.Location = new Point(196, 40);
            CategoryCombo.Name = "CategoryCombo";
            CategoryCombo.Size = new Size(170, 33);
            CategoryCombo.TabIndex = 7;
            // 
            // contentBox
            // 
            contentBox.BackColor = Color.White;
            contentBox.BorderStyle = BorderStyle.FixedSingle;
            contentBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contentBox.Location = new Point(26, 168);
            contentBox.Name = "contentBox";
            contentBox.RightToLeft = RightToLeft.No;
            contentBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            contentBox.Size = new Size(500, 200);
            contentBox.TabIndex = 8;
            contentBox.Text = "";
            contentBox.TextChanged += contentBox_TextChanged;
            // 
            // DateTimePickerReminder
            // 
            DateTimePickerReminder.Font = new Font("Segoe UI", 11F);
            DateTimePickerReminder.Format = DateTimePickerFormat.Short;
            DateTimePickerReminder.Location = new Point(196, 120);
            DateTimePickerReminder.Name = "DateTimePickerReminder";
            DateTimePickerReminder.Size = new Size(200, 32);
            DateTimePickerReminder.TabIndex = 9;
            // 
            // SaveAsTxtBtn
            // 
            SaveAsTxtBtn.BackColor = Color.LightSteelBlue;
            SaveAsTxtBtn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            SaveAsTxtBtn.Location = new Point(426, 380);
            SaveAsTxtBtn.Name = "SaveAsTxtBtn";
            SaveAsTxtBtn.Size = new Size(100, 34);
            SaveAsTxtBtn.TabIndex = 10;
            SaveAsTxtBtn.Text = "Save As Txt";
            SaveAsTxtBtn.UseVisualStyleBackColor = false;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = Color.Silver;
            cancelBtn.Font = new Font("Segoe UI", 11F);
            cancelBtn.Location = new Point(26, 380);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(100, 34);
            cancelBtn.TabIndex = 11;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            // 
            // CategoryLab
            // 
            CategoryLab.AutoSize = true;
            CategoryLab.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            CategoryLab.Location = new Point(77, 40);
            CategoryLab.Name = "CategoryLab";
            CategoryLab.Size = new Size(109, 25);
            CategoryLab.TabIndex = 5;
            CategoryLab.Text = "Category  :";
            // 
            // ReminderLab
            // 
            ReminderLab.AutoSize = true;
            ReminderLab.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            ReminderLab.Location = new Point(77, 120);
            ReminderLab.Name = "ReminderLab";
            ReminderLab.Size = new Size(113, 25);
            ReminderLab.TabIndex = 4;
            ReminderLab.Text = "Reminder  :";
            // 
            // TitleTab
            // 
            TitleTab.AutoSize = true;
            TitleTab.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            TitleTab.Location = new Point(77, 78);
            TitleTab.Name = "TitleTab";
            TitleTab.Size = new Size(114, 25);
            TitleTab.TabIndex = 3;
            TitleTab.Text = "Note Title  :";
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.FromArgb(44, 187, 99);
            AddBtn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(226, 380);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(94, 34);
            AddBtn.TabIndex = 1;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = false;
            // 
            // AddCategoryBtn
            // 
            AddCategoryBtn.BackColor = Color.RoyalBlue;
            AddCategoryBtn.FlatStyle = FlatStyle.Flat;
            AddCategoryBtn.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddCategoryBtn.ForeColor = Color.White;
            AddCategoryBtn.Location = new Point(372, 40);
            AddCategoryBtn.Name = "AddCategoryBtn";
            AddCategoryBtn.Size = new Size(38, 34);
            AddCategoryBtn.TabIndex = 13;
            AddCategoryBtn.Text = "+";
            toolTip1.SetToolTip(AddCategoryBtn, "Add new category");
            AddCategoryBtn.UseVisualStyleBackColor = false;
            AddCategoryBtn.Click += AddCategoryBtn_Click;
            // 
            // AddNoteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 255);
            ClientSize = new Size(550, 434);
            Controls.Add(formattingToolStrip);
            Controls.Add(AddCategoryBtn);
            Controls.Add(CategoryCombo);
            Controls.Add(CategoryLab);
            Controls.Add(AddBtn);
            Controls.Add(TitleTab);
            Controls.Add(ReminderLab);
            Controls.Add(titleTxt);
            Controls.Add(contentBox);
            Controls.Add(DateTimePickerReminder);
            Controls.Add(SaveAsTxtBtn);
            Controls.Add(cancelBtn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "AddNoteForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add/Edit Note";
            formattingToolStrip.ResumeLayout(false);
            formattingToolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip formattingToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton editDropDown;
        private System.Windows.Forms.ToolStripDropDownButton fontStyleDropDown;
        private System.Windows.Forms.ToolStripDropDownButton colorDropDown;
        private System.Windows.Forms.TextBox titleTxt;
        private System.Windows.Forms.ComboBox CategoryCombo;
        private System.Windows.Forms.RichTextBox contentBox;
        private System.Windows.Forms.DateTimePicker DateTimePickerReminder;
        private System.Windows.Forms.Button SaveAsTxtBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label CategoryLab;
        private System.Windows.Forms.Label ReminderLab;
        private System.Windows.Forms.Label TitleTab;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button AddCategoryBtn;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}