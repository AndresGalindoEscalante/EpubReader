using EpubReader.Controller;
using EpubReader.Model;
using System.Security;
using System.Windows.Forms;

namespace EpubReader
{
    public partial class MainPage : Form
    {
        private readonly Font standarFont = new Font("Microsoft Sans Serif", 12);

        public MainPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBooks();
            BooksBinding.CellMouseClick += BooksBinding_CellMouseClick;
        }

        private void AddBookButton(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                FileName = "Select epub file",
                Filter = "ePub files (*.epub)|*.epub|All files (*.*)|*.*",
                Title = "Open ePub File"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string bookName = openFileDialog.SafeFileName;
                    string safeFileName = openFileDialog.SafeFileName;

                    string filePathOld = openFileDialog.FileName;

                    Book? newBook = FileController.ObtainBookData(filePathOld);
                    if (newBook == null)
                    {
                        Console.WriteLine("Error obtaining book data");
                        return;
                    }
                    BookController.AddBook(newBook);
                    LoadBooks();
                }
                catch (SecurityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void LoadBooks()
        {
            BooksBinding.DataSource = BookController.GetBooks();
            DataGridViewColumn? idColumn = BooksBinding.Columns["Id"];
            if (idColumn != null)
            {
                idColumn.Visible = false;
            }
            DataGridViewColumn? uniqueIdColumn = BooksBinding.Columns["UniqueId"];
            if (uniqueIdColumn != null)
            {
                uniqueIdColumn.Visible = false;
            }
        }

        private void BooksBinding_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //Selects right clicked row, clears other rows
                if (BooksBinding.SelectedRows.Count <= 1 && sender is DataGridView cell)
                {
                    cell.ClearSelection();
                    cell.Rows[e.RowIndex].Selected = true;
                }
                //Gets IDs of selected rows
                int[] ids = [.. BooksBinding.SelectedRows
                        .Cast<DataGridViewRow>()
                        .Select(r => (int)r.Cells[0].Value!)];

                ToolStripMenuItem deleteItem = new("Delete", null, DeleteBook)
                {
                    Tag = ids
                };
                ContextMenuStrip contextMenuStrip = new();
                contextMenuStrip.Items.Add(deleteItem);
                contextMenuStrip.Show(Cursor.Position);
            }
        }
        private void DeleteBook(object? sender, EventArgs e)
        {
            if (sender is ToolStripItem item && item.Tag is int[] ids)
            {
                BookController.DeleteBooks(ids);
                LoadBooks();
            }
        }
    }
}
