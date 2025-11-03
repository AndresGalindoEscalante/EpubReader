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
        public required string UniqueId { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? FilePath { get; set; }
        public string? CoverPath { get; set; }
        public DateTime? DateAdded { get; set; }
        public String? PublishDate { get; set; }
    }
}
