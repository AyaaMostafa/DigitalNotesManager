using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalNotesManager.Domain.DTOs;
using DigitalNotesManager.Services.Interfaces;

namespace Presentation
{
    public partial class MainForm : Form
    {
        // === Fields ===
        private readonly int _userId;
        private readonly INotesServices _notesService;
        private readonly ICategoryService _categoryService;
        private int addNoteFormHeight = 480;
        private Dictionary<int, string> _categoriesDict = new Dictionary<int, string>();
        private List<dynamic> _allNotesList = new List<dynamic>();

        // Notification fields for reminders
        private NotifyIcon notifyIcon1 = new NotifyIcon();
        private System.Windows.Forms.Timer reminderTimer = new System.Windows.Forms.Timer(); // Unambiguous!
        private HashSet<int> notifiedNotes = new HashSet<int>();

        /// <summary>
        /// MainForm Constructor - Initializes everything and sets up all event handlers and DataGridView styles.
        /// </summary>
        public MainForm(int userId, INotesServices notesService, ICategoryService categoryService)
        {
            _userId = userId;
            _notesService = notesService;
            _categoryService = categoryService;

            InitializeComponent();

            // === Event Handlers ===
            notesDataGridView.CellContentClick += NotesDataGridView_CellContentClick;
            notesDataGridView.CellDoubleClick += NotesDataGridView_CellDoubleClick;
            notesDataGridView.CellPainting += NotesGridView_CellPainting_Actions;
            searchNotesTextBox.TextChanged += searchNotesTextBox_TextChanged;
            reminderDatePicker.ValueChanged += reminderDatePicker_ValueChanged;
            addNoteMenuItem.Click += addNoteMenuItem_Click;
            saveNotesMenuItem.Click += saveNotesMenuItem_Click;
            loadNotesMenuItem.Click += loadNotesMenuItem_Click;
            importLoadedNotesMenuItem.Click += importLoadedNotesMenuItem_Click;
            exitAppMenuItem.Click += exitAppMenuItem_Click;
            categoryFilterComboBox.SelectedIndexChanged += categoryFilterComboBox_SelectedIndexChanged;
            helpMenuItem.Click += helpMenuItem_Click;
            this.Load += MainForm_Load;

            // === DataGridView Style ===
            notesDataGridView.EnableHeadersVisualStyles = false;
            notesDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            notesDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            notesDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            notesDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            notesDataGridView.DefaultCellStyle.BackColor = Color.White;
            notesDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            notesDataGridView.DefaultCellStyle.SelectionBackColor = Color.White;
            notesDataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            notesDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // === Notification Icon for reminders ===
            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "Reminder";

            // === Timer for reminders ===
            reminderTimer.Interval = 60000; // 1 minute
            reminderTimer.Tick += ReminderTimer_Tick;
            reminderTimer.Start();
        }

        /// <summary>
        /// On form load: load all notes to the grid.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            _ = LoadNotesToGridAsync();
        }

        /// <summary>
        /// Loads categories from database and fills the category filter dropdown.
        /// </summary>
        private async Task LoadCategoriesAsync()
        {
            var catResponse = await _categoryService.GetCategoriesByUserId(_userId);
            if (catResponse.Status && catResponse.Data != null)
                _categoriesDict = catResponse.Data.ToDictionary(c => c.CategoryId, c => c.Name);
            else
                _categoriesDict = new Dictionary<int, string>();

            // Fill category filter dropdown
            var categoriesList = _categoriesDict.OrderBy(x => x.Value)
                                                .Select(x => x.Value)
                                                .ToList();
            categoriesList.Insert(0, "All");
            categoryFilterComboBox.DataSource = categoriesList;
        }

        /// <summary>
        /// Loads all notes into the DataGridView, applies category names, and sets up the actions column.
        /// </summary>
        private async Task LoadNotesToGridAsync()
        {
            await LoadCategoriesAsync();

            var response = await _notesService.GetAllNotes(_userId);
            if (response.Status)
            {
                var notesList = response.Data
                    .ToList()
                    .Select(note => new
                    {
                        NoteId = note.Id,
                        NoteTitle = note.Title,
                        // يعرض الكونتينت كنص عادي مش RTF:
                        NoteContent = RtfToPlainText(note.Content),
                        Category = _categoriesDict.TryGetValue(note.CategoryId, out var name) ? name : "",
                        NoteCreationDate = note.CreationDate,
                        NoteReminderDate = note.ReminderDate
                    })
                    .OrderBy(x => x.Category)
                    .Cast<dynamic>()
                    .ToList();

                _allNotesList = notesList;

                notesDataGridView.DataSource = notesList;

                if (notesDataGridView.Columns.Contains("NoteId"))
                    notesDataGridView.Columns["NoteId"].Visible = false;

                if (notesDataGridView.Columns.Contains("ActionsColumn"))
                    notesDataGridView.Columns.Remove("ActionsColumn");

                if (!notesDataGridView.Columns.Contains("ActionsColumn"))
                {
                    var actionsCol = new DataGridViewButtonColumn
                    {
                        Name = "ActionsColumn",
                        HeaderText = "Actions",
                        UseColumnTextForButtonValue = false,
                        FlatStyle = FlatStyle.Flat,
                        Width = 100
                    };
                    notesDataGridView.Columns.Add(actionsCol);
                }

                if (notesDataGridView.Columns.Contains("Category"))
                    notesDataGridView.Columns["Category"].HeaderText = "Category";
            }
            else
            {
                notesDataGridView.DataSource = null;
                MessageBox.Show(response.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// تحويل نص RTF إلى نص عادي (Plain Text)
        /// </summary>
        private static string RtfToPlainText(string rtf)
        {
            using (var rtb = new RichTextBox())
            {
                try
                {
                    rtb.Rtf = rtf;
                    return rtb.Text;
                }
                catch
                {
                    // لو مش RTF أصلاً
                    return rtf;
                }
            }
        }

        /// <summary>
        /// Draws a red "Delete" button in the Actions column for each row in the grid.
        /// </summary>
        private void NotesGridView_CellPainting_Actions(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (notesDataGridView.Columns[e.ColumnIndex].Name == "ActionsColumn" && e.RowIndex >= 0)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                int buttonHeight = e.CellBounds.Height - 10;
                int buttonWidth = e.CellBounds.Width - 16;
                int padding = 8;

                Rectangle deleteRect = new Rectangle(
                    e.CellBounds.Left + padding,
                    e.CellBounds.Top + (e.CellBounds.Height - buttonHeight) / 2,
                    buttonWidth,
                    buttonHeight
                );

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(244, 67, 54)))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.FillRectangle(brush, deleteRect);
                    e.Graphics.DrawString("Delete", new Font("Segoe UI", 10, FontStyle.Bold), textBrush, deleteRect, sf);
                }
            }
        }

        /// <summary>
        /// Opens the AddNoteForm above the grid for adding a new note.
        /// </summary>
        private void addNoteMenuItem_Click(object sender, EventArgs e)
        {
            ShowAddNoteFormAboveGrid();
        }

        /// <summary>
        /// Shows the AddNoteForm above the grid. If editing, loads the selected note.
        /// </summary>
        private void ShowAddNoteFormAboveGrid(int? noteId = null)
        {
            if (this.Controls.OfType<AddNoteForm>().Any(f => f.Visible))
                return;

            int originalTop = notesDataGridView.Top;
            notesDataGridView.Top = notesDataGridView.Top + addNoteFormHeight + 10;
            notesDataGridView.Height = notesDataGridView.Height - addNoteFormHeight - 10;

            NoteDto note = null;
            if (noteId.HasValue)
            {
                note = _notesService.GetNoteById(noteId.Value, _userId).Result.Data;
            }
            var addNoteForm = new AddNoteForm(_userId, _notesService, _categoryService, note)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                Size = new Size(notesDataGridView.Width, addNoteFormHeight),
                Location = new Point(notesDataGridView.Left, notesDataGridView.Top - addNoteFormHeight - 10),
                StartPosition = FormStartPosition.Manual
            };

            addNoteForm.FormClosed += async (s, ev) =>
            {
                notesDataGridView.Top = originalTop;
                notesDataGridView.Height = this.ClientSize.Height - notesDataGridView.Top - 20;
                await LoadNotesToGridAsync();
            };

            this.Controls.Add(addNoteForm);
            addNoteForm.BringToFront();
            addNoteForm.Show();
        }

        /// <summary>
        /// Handles double-click on the grid to open a note for editing.
        /// </summary>
        private void NotesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int noteId = Convert.ToInt32(notesDataGridView.Rows[e.RowIndex].Cells["NoteId"].Value);
                ShowAddNoteFormAboveGrid(noteId);
            }
        }

        /// <summary>
        /// Handles click on the "Delete" button in the Actions column and deletes the note.
        /// </summary>
        private async void NotesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || notesDataGridView.Columns[e.ColumnIndex].Name != "ActionsColumn")
                return;

            var cell = notesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            Rectangle cellRect = notesDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            int buttonHeight = cell.Size.Height - 10;
            int buttonWidth = cell.Size.Width - 16;
            int padding = 8;

            Rectangle deleteRect = new Rectangle(
                cellRect.Left + padding,
                cellRect.Top + (cell.Size.Height - buttonHeight) / 2,
                buttonWidth,
                buttonHeight
            );

            Point mouse = notesDataGridView.PointToClient(Cursor.Position);

            int noteId = Convert.ToInt32(notesDataGridView.Rows[e.RowIndex].Cells["NoteId"].Value);
            if (deleteRect.Contains(mouse))
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this note?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    var response = await _notesService.DeleteNote(noteId, _userId);
                    if (response.Status)
                    {
                        MessageBox.Show("Note deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadNotesToGridAsync();
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Handles text change in the search box and filters notes in the grid accordingly.
        /// </summary>
        private async void searchNotesTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchNotesTextBox.Text.Trim();
            if (string.IsNullOrEmpty(searchText) && (categoryFilterComboBox.SelectedIndex <= 0 || categoryFilterComboBox.SelectedIndex == -1))
            {
                await LoadNotesToGridAsync();
                return;
            }

            IEnumerable<dynamic> filtered = _allNotesList;

            // Apply category filter if selected
            if (categoryFilterComboBox.SelectedIndex > 0)
            {
                string selectedCategory = categoryFilterComboBox.SelectedItem.ToString();
                filtered = filtered.Where(x => x.Category == selectedCategory);
            }

            // Apply search filter if not empty
            if (!string.IsNullOrEmpty(searchText))
            {
                filtered = filtered.Where(x =>
                    (x.NoteTitle ?? "").ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (x.NoteContent ?? "").ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0
                );
            }

            notesDataGridView.DataSource = filtered.OrderBy(x => x.Category).ToList();
        }

        /// <summary>
        /// Handles changing the category filter combo and filters notes accordingly.
        /// </summary>
        private void categoryFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = categoryFilterComboBox.SelectedItem.ToString();
            IEnumerable<dynamic> filtered = _allNotesList;

            if (selectedCategory != "All")
            {
                filtered = filtered.Where(x => x.Category == selectedCategory);
            }

            notesDataGridView.DataSource = filtered.OrderBy(x => x.Category).ToList();
        }

        /// <summary>
        /// Handles value change in the reminder date picker and filters notes by date.
        /// </summary>
        private async void reminderDatePicker_ValueChanged(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();

            var response = await _notesService.GetAllNotes(_userId);
            if (response.Status)
            {
                var notes = response.Data;
                var filterResponse = await _notesService.FilterNotesByDate(reminderDatePicker.Value, notes);
                if (filterResponse.Status)
                {
                    var notesList = filterResponse.Data
                        .ToList()
                        .Select(note => new
                        {
                            NoteId = note.Id,
                            NoteTitle = note.Title,
                            NoteContent = RtfToPlainText(note.Content),
                            Category = _categoriesDict.TryGetValue(note.CategoryId, out var name) ? name : "",
                            NoteCreationDate = note.CreationDate,
                            NoteReminderDate = note.ReminderDate
                        })
                        .OrderBy(x => x.Category)
                        .Cast<dynamic>()
                        .ToList();

                    _allNotesList = notesList;

                    notesDataGridView.DataSource = notesList;
                }
                else
                {
                    notesDataGridView.DataSource = null;
                    MessageBox.Show(filterResponse.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Saves all notes in the grid to a text file.
        /// </summary>
        private void saveNotesMenuItem_Click(object sender, EventArgs e)
        {
            if (notesDataGridView.DataSource == null) return;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var rows = notesDataGridView.Rows;
                var lines = "Title\tContent\tCategory\tCreated\tReminder";
                foreach (DataGridViewRow dgRow in rows)
                {
                    if (!dgRow.IsNewRow)
                    {
                        lines += $"\n{dgRow.Cells["NoteTitle"].Value}\t{dgRow.Cells["NoteContent"].Value}\t{dgRow.Cells["Category"].Value}\t{dgRow.Cells["NoteCreationDate"].Value}\t{dgRow.Cells["NoteReminderDate"].Value}";
                    }
                }
                File.WriteAllText(saveFileDialog.FileName, lines);
                MessageBox.Show("Notes saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Loads notes from a text file into the grid (not the database).
        /// </summary>
        private void loadNotesMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Load Notes",
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var lines = File.ReadAllLines(openFileDialog.FileName, Encoding.UTF8);
                    if (lines.Length <= 1)
                    {
                        MessageBox.Show("No notes found in this file.", "Load Notes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var notesList = new List<dynamic>();
                    for (int i = 1; i < lines.Length; i++)
                    {
                        var cols = lines[i].Split('\t');
                        if (cols.Length < 5) continue;
                        notesList.Add(new
                        {
                            NoteTitle = cols[0],
                            NoteContent = cols[1],
                            Category = cols[2],
                            NoteCreationDate = cols[3],
                            NoteReminderDate = cols[4]
                        });
                    }

                    _allNotesList = notesList.OrderBy(x => x.Category).Cast<dynamic>().ToList();
                    notesDataGridView.DataSource = _allNotesList;

                    MessageBox.Show("Notes loaded into grid (not saved in database).", "Load Notes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load notes.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Imports notes currently in the grid into the database (from a loaded file).
        /// </summary>
        private async void importLoadedNotesMenuItem_Click(object sender, EventArgs e)
        {
            if (notesDataGridView.DataSource == null || notesDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("No loaded notes to import.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int imported = 0, failed = 0;
            foreach (DataGridViewRow row in notesDataGridView.Rows)
            {
                if (row.IsNewRow) continue;
                try
                {
                    string title = Convert.ToString(row.Cells["NoteTitle"].Value);
                    string content = Convert.ToString(row.Cells["NoteContent"].Value);
                    string categoryName = Convert.ToString(row.Cells["Category"].Value);
                    string creationDateStr = Convert.ToString(row.Cells["NoteCreationDate"].Value);
                    string reminderDateStr = Convert.ToString(row.Cells["NoteReminderDate"].Value);

                    int categoryId = 0;
                    var category = _categoriesDict.FirstOrDefault(x => x.Value == categoryName);
                    if (category.Key == 0 && !string.IsNullOrWhiteSpace(categoryName))
                    {
                        var resp = await _categoryService.AddCategory(new DigitalNotesManager.Domain.Models.Category
                        {
                            Name = categoryName,
                            UserId = _userId
                        });
                        if (resp.Status)
                        {
                            await LoadCategoriesAsync();
                            categoryId = _categoriesDict.FirstOrDefault(x => x.Value == categoryName).Key;
                        }
                    }
                    else
                    {
                        categoryId = category.Key;
                    }

                    var note = new DigitalNotesManager.Domain.Models.Note
                    {
                        Title = title,
                        Content = content,
                        UserId = _userId,
                        CategoryId = categoryId,
                        CreationDate = DateTime.TryParse(creationDateStr, out var cd) ? cd : DateTime.Now,
                        ReminderDate = DateTime.TryParse(reminderDateStr, out var rd) ? rd : (DateTime?)null
                    };
                    var result = await _notesService.AddNote(note);
                    if (result.Status) imported++;
                    else failed++;
                }
                catch
                {
                    failed++;
                }
            }
            MessageBox.Show($"Import finished.\nSuccessfully added: {imported}\nFailed: {failed}", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadNotesToGridAsync();
        }

        /// <summary>
        /// Shows a help/about message box with usage info and app version.
        /// </summary>
        private void helpMenuItem_Click(object sender, EventArgs e)
        {
            string fakeHelp =
          @"Digital Notes Manager v1.0.0
 
         كيفية استخدام التطبيق: 
         - لإضافة Note جديدة: اضغط على File > Add Note أو زر الإضافة.
         - للبحث عن Note: استخدم مربع البحث في الأعلى.
         - لفلترة النوتس حسب التصنيف: اختر التصنيف من القائمة المنسدلة (Category).
         - لتعديل أو حذف Note: اضغط مرتين لتعديل أو زر Delete للحذف.
         - يمكنك حفظ جميع النوتس كملف نصي أو استيرادها من ملف.
            التطبيق من تطوير فريقك المفضل :) ";

            MessageBox.Show(fakeHelp, "مساعدة (Help / About)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        private void exitAppMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Timer Tick Event: Checks for notes with ReminderDate equal to now and shows notification.
        /// </summary>
        private async void ReminderTimer_Tick(object sender, EventArgs e)
        {
            var response = await _notesService.GetAllNotes(_userId);
            if (response.Status && response.Data != null)
            {
                var notes = response.Data
                    .Where(n => n.ReminderDate.HasValue)
                    .ToList();

                foreach (var note in notes)
                {
                    if (note.ReminderDate.Value.Date == DateTime.Now.Date &&
                        note.ReminderDate.Value.Hour == DateTime.Now.Hour &&
                        note.ReminderDate.Value.Minute == DateTime.Now.Minute)
                    {
                        if (!notifiedNotes.Contains(note.Id))
                        {
                            notifyIcon1.BalloonTipText = $"Don't forget: {note.Title}\n{RtfToPlainText(note.Content)}";
                            notifyIcon1.ShowBalloonTip(10000);
                            notifiedNotes.Add(note.Id);
                        }
                    }
                }
            }
        }
    }
}