using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DigitalNotesManager.Domain.DTOs;
using DigitalNotesManager.Domain.Models;
using DigitalNotesManager.Services.Interfaces;

namespace Presentation
{
    public partial class AddNoteForm : Form
    {
        private readonly int _userId;
        private readonly INotesServices _notesService;
        private readonly ICategoryService _categoryService;
        private readonly NoteDto _editNote;

        /// <summary>
        /// Constructor for AddNoteForm. Initializes controls and event handlers.
        /// </summary>
        public AddNoteForm(int userId, INotesServices notesService, ICategoryService categoryService, NoteDto noteToEdit = null)
        {
            InitializeComponent();
            _userId = userId;
            _notesService = notesService;
            _categoryService = categoryService;
            _editNote = noteToEdit;

            cancelBtn.Click += (s, e) => this.Close();
            AddBtn.Click += SaveBtn_Click;
            SaveAsTxtBtn.Click += SaveAsTxtBtn_Click;
            AddCategoryBtn.Click += AddCategoryBtn_Click;
            this.Load += AddNoteForm_Load;

            // ==== Edit DropDown (Cut/Copy/Paste) ====
            editDropDown.DropDownItems.Clear();
            editDropDown.DropDownItems.Add("Cut", null, (s, e) => contentBox.Cut());
            editDropDown.DropDownItems.Add("Copy", null, (s, e) => contentBox.Copy());
            editDropDown.DropDownItems.Add("Paste", null, (s, e) => contentBox.Paste());

            // ==== Font Style DropDown (Bold/Italic/Underline + FontDialog) ====
            fontStyleDropDown.DropDownItems.Clear();
            fontStyleDropDown.DropDownItems.Add("Bold", null, fontBold_Click);
            fontStyleDropDown.DropDownItems.Add("Italic", null, fontItalic_Click);
            fontStyleDropDown.DropDownItems.Add("Underline", null, fontUnderline_Click);
            fontStyleDropDown.DropDownItems.Add(new ToolStripSeparator());
            var fontDialogItem = new ToolStripMenuItem("Custom Font...");
            fontDialogItem.Click += fontDialogItem_Click;
            fontStyleDropDown.DropDownItems.Add(fontDialogItem);

            // ==== Color DropDown (Predefined + ColorDialog) ====
            colorDropDown.DropDownItems.Clear();
            colorDropDown.DropDownItems.Add("Black", null, (s, e) => SetRichTextBoxColor(Color.Black));
            colorDropDown.DropDownItems.Add("Red", null, (s, e) => SetRichTextBoxColor(Color.Red));
            colorDropDown.DropDownItems.Add("Green", null, (s, e) => SetRichTextBoxColor(Color.Green));
            colorDropDown.DropDownItems.Add("Blue", null, (s, e) => SetRichTextBoxColor(Color.Blue));
            colorDropDown.DropDownItems.Add("Orange", null, (s, e) => SetRichTextBoxColor(Color.Orange));
            colorDropDown.DropDownItems.Add("Purple", null, (s, e) => SetRichTextBoxColor(Color.Purple));
            colorDropDown.DropDownItems.Add(new ToolStripSeparator());
            var moreColorItem = new ToolStripMenuItem("More Colors...");
            moreColorItem.Click += moreColorItem_Click;
            colorDropDown.DropDownItems.Add(moreColorItem);
        }

        /// <summary>
        /// Loads categories and, if editing, fills controls with note data.
        /// </summary>
        private async void AddNoteForm_Load(object sender, EventArgs e)
        {
            var response = await _categoryService.GetCategoriesByUserId(_userId);
            if (response.Status && response.Data != null)
            {
                CategoryCombo.DataSource = response.Data.ToList();
                CategoryCombo.DisplayMember = "Name";
                CategoryCombo.ValueMember = "CategoryId";
            }
            else
            {
                CategoryCombo.DataSource = null;
            }

            if (_editNote != null)
            {
                titleTxt.Text = _editNote.Title;
                try
                {
                    contentBox.Rtf = _editNote.Content;
                }
                catch
                {
                    contentBox.Text = _editNote.Content;
                }
                if (_editNote.ReminderDate.HasValue)
                    DateTimePickerReminder.Value = _editNote.ReminderDate.Value;

                var selectedCat = response.Data?.FirstOrDefault(c => c.CategoryId == _editNote.CategoryId);
                if (selectedCat != null)
                    CategoryCombo.SelectedItem = selectedCat;

                AddBtn.Text = "Update";
            }
            else
            {
                AddBtn.Text = "Add";
            }
        }

        /// <summary>
        /// Saves the note content as either RTF (with formatting) or plain text file.
        /// </summary>
        private void SaveAsTxtBtn_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(dialog.FileName).ToLower() == ".rtf")
                    {
                        contentBox.SaveFile(dialog.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        File.WriteAllText(dialog.FileName, contentBox.Text);
                    }
                    MessageBox.Show("Note saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Handles save button click: validates and adds/updates note in the database.
        /// </summary>
        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTxt.Text))
            {
                MessageBox.Show("Please enter a note title.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CategoryCombo.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int categoryId = ((CategoryDto)CategoryCombo.SelectedItem).CategoryId;

            if (_editNote == null)
            {
                var note = new Note
                {
                    Title = titleTxt.Text.Trim(),
                    Content = contentBox.Rtf, // Save as rtf 
                    UserId = _userId,
                    CategoryId = categoryId,
                    CreationDate = DateTime.Now,
                    ReminderDate = DateTimePickerReminder.Value
                };
                var response = await _notesService.AddNote(note);
                if (response.Status)
                {
                    MessageBox.Show("Note added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var note = new Note
                {
                    Id = _editNote.Id,
                    Title = titleTxt.Text.Trim(),
                    Content = contentBox.Rtf,
                    UserId = _userId,
                    CategoryId = categoryId,
                    CreationDate = _editNote.CreationDate,
                    ReminderDate = DateTimePickerReminder.Value
                };
                var response = await _notesService.UpdateNote(note);
                if (response.Status)
                {
                    MessageBox.Show("Note updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// (Optional) Handles text change in the RichTextBox for live preview or word count.
        /// </summary>
        private void contentBox_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Adds a new category after checking for duplicates, and updates the combo box.
        /// </summary>
        private async void AddCategoryBtn_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter new category name:", "Add Category", "");

            if (!string.IsNullOrWhiteSpace(input))
            {
                var currentList = CategoryCombo.DataSource as System.Collections.IEnumerable;
                if (currentList != null)
                {
                    foreach (var cat in currentList)
                    {
                        var c = cat as CategoryDto;
                        if (c != null && c.Name.Equals(input.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Category already exists.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }

                var newCat = new DigitalNotesManager.Domain.Models.Category
                {
                    Name = input.Trim(),
                    UserId = _userId
                };
                var resp = await _categoryService.AddCategory(newCat);
                if (resp.Status)
                {
                    MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var response = await _categoryService.GetCategoriesByUserId(_userId);
                    if (response.Status && response.Data != null)
                    {
                        CategoryCombo.DataSource = response.Data.ToList();
                        CategoryCombo.DisplayMember = "Name";
                        CategoryCombo.ValueMember = "CategoryId";
                        var added = response.Data.FirstOrDefault(c => c.Name.Equals(input.Trim(), StringComparison.OrdinalIgnoreCase));
                        if (added != null)
                            CategoryCombo.SelectedItem = added;
                    }
                }
                else
                {
                    MessageBox.Show("Failed to add category.\n" + resp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==== Font Style (Bold/Italic/Underline + FontDialog) ====

        /// <summary>
        /// Applies bold formatting to selected text in RichTextBox.
        /// </summary>
        private void fontBold_Click(object sender, EventArgs e)
        {
            if (contentBox.SelectionLength > 0)
            {
                var font = contentBox.SelectionFont ?? contentBox.Font;
                var style = font.Style ^ FontStyle.Bold;
                contentBox.SelectionFont = new Font(font, style);
            }
        }

        /// <summary>
        /// Applies italic formatting to selected text in RichTextBox.
        /// </summary>
        private void fontItalic_Click(object sender, EventArgs e)
        {
            if (contentBox.SelectionLength > 0)
            {
                var font = contentBox.SelectionFont ?? contentBox.Font;
                var style = font.Style ^ FontStyle.Italic;
                contentBox.SelectionFont = new Font(font, style);
            }
        }

        /// <summary>
        /// Applies underline formatting to selected text in RichTextBox.
        /// </summary>
        private void fontUnderline_Click(object sender, EventArgs e)
        {
            if (contentBox.SelectionLength > 0)
            {
                var font = contentBox.SelectionFont ?? contentBox.Font;
                var style = font.Style ^ FontStyle.Underline;
                contentBox.SelectionFont = new Font(font, style);
            }
        }

        /// <summary>
        /// Shows a FontDialog to select custom font for selected text or whole box.
        /// </summary>
        private void fontDialogItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = contentBox.SelectionFont ?? contentBox.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                if (contentBox.SelectionLength > 0)
                    contentBox.SelectionFont = fontDialog.Font;
                else
                    contentBox.Font = fontDialog.Font;
            }
        }

        // ==== Color (Predefined + ColorDialog) ====

        /// <summary>
        /// Sets color for selected text (or all text if no selection) in RichTextBox.
        /// </summary>
        private void SetRichTextBoxColor(Color color)
        {
            if (contentBox.SelectionLength > 0)
            {
                contentBox.SelectionColor = color;
            }
            else
            {
                contentBox.ForeColor = color;
            }
        }

        /// <summary>
        /// Opens the ColorDialog to pick a custom color for text.
        /// </summary>
        private void moreColorItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = contentBox.SelectionColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SetRichTextBoxColor(colorDialog.Color);
            }
        }
    }
}