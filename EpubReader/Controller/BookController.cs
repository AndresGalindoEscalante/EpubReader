using EpubReader.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpubReader.Controller
{
    public class BookController
    {
        public static void AddBook(Book book)
        {
            try
            {
                string? folderPath = ConfigurationManager.AppSettings["BookFolder"];
                using var db = new LiteDatabase($@"{folderPath}\EpubReaderData.db");
                var books = db.GetCollection<Book>("books");
                books.Insert(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<Book> GetBooks()
        {
            List<Book> allBooks = [];
            try
            {
                string? folderPath = ConfigurationManager.AppSettings["BookFolder"];
                using var db = new LiteDatabase($@"{folderPath}\EpubReaderData.db");
                var books = db.GetCollection<Book>("books");
                allBooks = [.. books.FindAll()];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return allBooks;
        }

        public static bool DeleteBooks(int[] idBook)
        {
            bool res = false;
            try
            {
                string? folderPath = ConfigurationManager.AppSettings["BookFolder"];
                using var db = new LiteDatabase($@"{folderPath}\EpubReaderData.db");
                var books = db.GetCollection<Book>("books");
                foreach (int id in idBook)
                {
                    FileController.DeleteFromProgramDirectory(books.FindById(id)?.FilePath!);
                    res = books.Delete(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return res;
        }
    }
}
