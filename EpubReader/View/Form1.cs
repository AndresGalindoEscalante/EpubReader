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
        }
        private void BooksTablePanelPaint(object sender, PaintEventArgs e)
        {

        }
    }
}
