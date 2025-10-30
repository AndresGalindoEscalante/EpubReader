using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpubReader.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? FilePath { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
