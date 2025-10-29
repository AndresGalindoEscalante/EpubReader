using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpubReader.Model
{
    public class OpfFile
    {
        public required List<Metadata> Metadata { get; set; }
        public required List<Manifest> Manifest { get; set; }
        public required List<Spine> Spine { get; set; }
        public required List<Guide> Guide { get; set; }

    }
    public class Metadata
    {
        public required List<DcTerm> Identifier { get; set; }
        public required DcTerm Title { get; set; }
        public required List<DcTerm> Language { get; set; }

        public List<DcTerm>? Contributor { get; set; }
        public List<DcTerm>? Coverage { get; set; }
        public List<DcTerm>? Creator { get; set; }
        public List<DcTerm>? Date { get; set; }
        public List<DcTerm>? Description { get; set; }
        public List<DcTerm>? Format { get; set; }
        public List<DcTerm>? Publisher { get; set; }
        public List<DcTerm>? Relation { get; set; }
        public List<DcTerm>? Rights { get; set; }
        public List<DcTerm>? Source { get; set; }
        public List<DcTerm>? Subject { get; set; }
        public List<DcTerm>? Type { get; set; }
    }

    public class DcTerm
    {
        public required string Value { get; set; }
        public string? Id { get; set; }
        public string? Dir { get; set; }
        public string? XmlLang { get; set; }
    }

    public class Manifest
    {
    }
    public class Spine
    {
    }
    public class Guide
    {
    }

}
