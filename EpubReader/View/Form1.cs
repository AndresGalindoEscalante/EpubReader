using EpubReader.Controller;
using EpubReader.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpubReader
{
    public partial class Form1 : Form
    {
        private readonly Font standarFont = new Font("Microsoft Sans Serif", 12);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void AddBookButton(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
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
                    string filePathNew = $@"{ConfigurationManager.AppSettings["BookFolder"]}\{safeFileName}";

                    FileController.ObtainBookData(filePathOld);

                    Book newBook = new Book
                    {
                        Name = bookName,
                        Author = "Author",
                        FilePath = filePathNew,
                        DateAdded = DateTime.Now,
                    };
                    BookController.AddBook(newBook);
                    LoadBooks();
                }
                catch (SecurityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void InitBooksTableHeaders()
        {
            
            booksTablePanel.Controls.Add(new Label()
            {
                Text = "Title",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = standarFont,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 15),
                AutoSize = true
            }, 0, 0);

            booksTablePanel.Controls.Add(new Label()
            {
                Text = "Author",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = standarFont,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 15),
                AutoSize = true
            }, 1, 0);

            booksTablePanel.Controls.Add(new Label()
            {
                Text = "Date Added",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = standarFont,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 15),
                AutoSize = true
            }, 2, 0);

            booksTablePanel.Controls.Add(new Label()
            {
                Text = "Publication Date",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = standarFont,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 15),
                AutoSize = true
            }, 3, 0);
        }

        private void LoadBooks()
        {
            try
            {
                List<Book> books = BookController.GetBooks();
                if (books != null)
                {
                    booksTablePanel.RowCount = 1 + books.Count;
                    booksTablePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    InitBooksTableHeaders();
                    int rowIndex = 1;
                    foreach (Book b in books)
                    {
                        booksTablePanel.Controls.Add(new Label()
                        {
                            Text = b.Name,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = standarFont,
                            Dock = DockStyle.Fill,
                            Margin = new Padding(0, 0, 0, 15),
                            AutoSize = true
                        }, 0, rowIndex);

                        booksTablePanel.Controls.Add(new Label()
                        {
                            Text = b.Author,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = standarFont,
                            Dock = DockStyle.Fill,
                            Margin = new Padding(0, 0, 0, 15),
                            AutoSize = true
                        }, 1, rowIndex);

                        booksTablePanel.Controls.Add(new Label()
                        {
                            Text = b.DateAdded?.ToString("yyyy-MM-dd") ?? "",
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = standarFont,
                            Dock = DockStyle.Fill,
                            Margin = new Padding(0, 0, 0, 15),
                            AutoSize = true
                        }, 2, rowIndex);

                        booksTablePanel.Controls.Add(new Label()
                        {
                            Text = b.PublishDate?.ToString("yyyy-MM-dd") ?? "",
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = standarFont,
                            Dock = DockStyle.Fill,
                            Margin = new Padding(0, 0, 0, 15),
                            AutoSize = true
                        }, 3, rowIndex);
                        rowIndex++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void BooksTablePanelPaint(object sender, PaintEventArgs e)
        {

        }
    }
}
