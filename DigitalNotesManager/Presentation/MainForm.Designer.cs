namespace Presentation
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip topMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNoteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveNotesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadNotesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importLoadedNotesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitAppMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.Label searchNotesLabel;
        private System.Windows.Forms.TextBox searchNotesTextBox;
        private System.Windows.Forms.Label FilterByCreatedDateLabel;
        private System.Windows.Forms.DateTimePicker reminderDatePicker;
        private System.Windows.Forms.DataGridView notesDataGridView;
        private System.Windows.Forms.ComboBox categoryFilterComboBox;
        private System.Windows.Forms.Label categoryFilterLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            topMenuStrip = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem();
            addNoteMenuItem = new ToolStripMenuItem();
            saveNotesMenuItem = new ToolStripMenuItem();
            loadNotesMenuItem = new ToolStripMenuItem();
            importLoadedNotesMenuItem = new ToolStripMenuItem();
            exitAppMenuItem = new ToolStripMenuItem();
            viewMenuItem = new ToolStripMenuItem();
            helpMenuItem = new ToolStripMenuItem();
            searchNotesLabel = new Label();
            searchNotesTextBox = new TextBox();
            FilterByCreatedDateLabel = new Label();
            reminderDatePicker = new DateTimePicker();
            notesDataGridView = new DataGridView();
            categoryFilterComboBox = new ComboBox();
            categoryFilterLabel = new Label();
            topMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)notesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // topMenuStrip
            // 
            topMenuStrip.ImageScalingSize = new Size(20, 20);
            topMenuStrip.Items.AddRange(new ToolStripItem[] { fileMenuItem, viewMenuItem, helpMenuItem });
            topMenuStrip.Location = new Point(0, 0);
            topMenuStrip.Name = "topMenuStrip";
            topMenuStrip.Size = new Size(1100, 28);
            topMenuStrip.TabIndex = 0;
            topMenuStrip.Text = "topMenuStrip";
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addNoteMenuItem, saveNotesMenuItem, loadNotesMenuItem, importLoadedNotesMenuItem, exitAppMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new Size(46, 24);
            fileMenuItem.Text = "File";
            // 
            // addNoteMenuItem
            // 
            addNoteMenuItem.Name = "addNoteMenuItem";
            addNoteMenuItem.Size = new Size(262, 26);
            addNoteMenuItem.Text = "Add Note";
            // 
            // saveNotesMenuItem
            // 
            saveNotesMenuItem.Name = "saveNotesMenuItem";
            saveNotesMenuItem.Size = new Size(262, 26);
            saveNotesMenuItem.Text = "Save Notes to device";
            // 
            // loadNotesMenuItem
            // 
            loadNotesMenuItem.Name = "loadNotesMenuItem";
            loadNotesMenuItem.Size = new Size(262, 26);
            loadNotesMenuItem.Text = "Load Notes from device";
            // 
            // importLoadedNotesMenuItem
            // 
            importLoadedNotesMenuItem.Name = "importLoadedNotesMenuItem";
            importLoadedNotesMenuItem.Size = new Size(262, 26);
            importLoadedNotesMenuItem.Text = "Save Loaded to my Notes";
            // 
            // exitAppMenuItem
            // 
            exitAppMenuItem.Name = "exitAppMenuItem";
            exitAppMenuItem.Size = new Size(262, 26);
            exitAppMenuItem.Text = "Exit";
            // 
            // viewMenuItem
            // 
            viewMenuItem.Name = "viewMenuItem";
            viewMenuItem.Size = new Size(55, 24);
            viewMenuItem.Text = "View";
            // 
            // helpMenuItem
            // 
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new Size(55, 24);
            helpMenuItem.Text = "Help";
            // 
            // searchNotesLabel
            // 
            searchNotesLabel.AutoSize = true;
            searchNotesLabel.Location = new Point(12, 54);
            searchNotesLabel.Name = "searchNotesLabel";
            searchNotesLabel.Size = new Size(78, 25);
            searchNotesLabel.TabIndex = 3;
            searchNotesLabel.Text = "Search :";
            // 
            // searchNotesTextBox
            // 
            searchNotesTextBox.Font = new Font("Segoe UI", 11F);
            searchNotesTextBox.Location = new Point(99, 45);
            searchNotesTextBox.Name = "searchNotesTextBox";
            searchNotesTextBox.Size = new Size(134, 32);
            searchNotesTextBox.TabIndex = 4;
            // 
            // FilterByCreatedDateLabel
            // 
            FilterByCreatedDateLabel.AutoSize = true;
            FilterByCreatedDateLabel.Location = new Point(576, 56);
            FilterByCreatedDateLabel.Name = "FilterByCreatedDateLabel";
            FilterByCreatedDateLabel.Size = new Size(178, 25);
            FilterByCreatedDateLabel.TabIndex = 1;
            FilterByCreatedDateLabel.Text = "Created Date Filter :";
            // 
            // reminderDatePicker
            // 
            reminderDatePicker.Font = new Font("Segoe UI", 11F);
            reminderDatePicker.Location = new Point(760, 49);
            reminderDatePicker.Name = "reminderDatePicker";
            reminderDatePicker.Size = new Size(320, 32);
            reminderDatePicker.TabIndex = 2;
            // 
            // notesDataGridView
            // 
            notesDataGridView.AllowUserToAddRows = false;
            notesDataGridView.AllowUserToDeleteRows = false;
            notesDataGridView.AllowUserToOrderColumns = true;
            notesDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            notesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            notesDataGridView.BackgroundColor = Color.White;
            notesDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            notesDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            notesDataGridView.ColumnHeadersHeight = 29;
            notesDataGridView.EnableHeadersVisualStyles = false;
            notesDataGridView.GridColor = Color.FromArgb(232, 232, 232);
            notesDataGridView.Location = new Point(20, 95);
            notesDataGridView.Name = "notesDataGridView";
            notesDataGridView.RowHeadersVisible = false;
            notesDataGridView.RowHeadersWidth = 51;
            notesDataGridView.RowTemplate.Height = 38;
            notesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            notesDataGridView.Size = new Size(1060, 540);
            notesDataGridView.TabIndex = 5;
            // 
            // categoryFilterComboBox
            // 
            categoryFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryFilterComboBox.Font = new Font("Segoe UI", 11F);
            categoryFilterComboBox.Location = new Point(436, 46);
            categoryFilterComboBox.Name = "categoryFilterComboBox";
            categoryFilterComboBox.Size = new Size(134, 33);
            categoryFilterComboBox.TabIndex = 7;
            // 
            // categoryFilterLabel
            // 
            categoryFilterLabel.AutoSize = true;
            categoryFilterLabel.Location = new Point(286, 54);
            categoryFilterLabel.Name = "categoryFilterLabel";
            categoryFilterLabel.Size = new Size(144, 25);
            categoryFilterLabel.TabIndex = 6;
            categoryFilterLabel.Text = "Category Filter :";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(233, 236, 239);
            ClientSize = new Size(1100, 660);
            Controls.Add(categoryFilterComboBox);
            Controls.Add(categoryFilterLabel);
            Controls.Add(notesDataGridView);
            Controls.Add(reminderDatePicker);
            Controls.Add(FilterByCreatedDateLabel);
            Controls.Add(searchNotesTextBox);
            Controls.Add(searchNotesLabel);
            Controls.Add(topMenuStrip);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = topMenuStrip;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Digital Notes Manager";
            topMenuStrip.ResumeLayout(false);
            topMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)notesDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}