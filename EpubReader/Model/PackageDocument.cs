using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EpubReader.Model
{
    [XmlRoot("package", Namespace = "http://www.idpf.org/2007/opf")]
    public class PackageDocument
    {

        [XmlAttribute("version")]
        public required string Version { get; set; }

        [XmlAttribute("unique-identifier")]
        public required string UniqueIdentifier { get; set; }

        [XmlAttribute("dir")]
        public required string Dir { get; set; }

        [XmlAttribute("id")]
        public required string Id { get; set; }

        [XmlAttribute("prefix")]
        public required string Prefix { get; set; }

        [XmlAttribute("xml:lang")]
        public required string XmlLang { get; set; }

        [XmlElement("metadata")]
        public required Metadata Metadata { get; set; }

        [XmlElement("manifest")]
        public required Manifest Manifest { get; set; }

        [XmlElement("spine")]
        public required Spine Spine { get; set; }

        [XmlElement("guide")]
        public Guide? Guide { get; set; }

        [XmlElement("collection")]
        public List<Collection>? Collection { get; set; }

    }
    public class Metadata
    {
        [XmlElement("identifier", Namespace = "http://purl.org/dc/elements/1.1/")]
        public required List<DcTerm> Identifier { get; set; }

        [XmlElement("title", Namespace = "http://purl.org/dc/elements/1.1/")]
        public required DcTerm Title { get; set; }

        [XmlElement("language", Namespace = "http://purl.org/dc/elements/1.1/")]
        public required List<DcTerm> Language { get; set; }

        [XmlElement("contributor", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<DcTerm>? Contributor { get; set; }

        [XmlElement("coverage", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<DcTerm>? Coverage { get; set; }

        [XmlElement("creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<DcTerm>? Creator { get; set; }

        [XmlElement("date", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<DcTerm>? Date { get; set; }

        [XmlElement("description", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<DcTerm>? Description { get; set; }

        [XmlElement("format", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<DcTerm>? Format { get; set; }

        [XmlElement("publisher", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<DcTerm>? Publisher { get; set; }

        [XmlElement("relation", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<DcTerm>? Relation { get; set; }

        [XmlElement("rights", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<DcTerm>? Rights { get; set; }
        [XmlElement("source", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<DcTerm>? Source { get; set; }

        [XmlElement("subject", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<DcTerm>? Subject { get; set; }

        [XmlElement("type", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<DcTerm>? Type { get; set; }

        [XmlElement("meta")]
        public List<Meta>? Meta { get; set; }
    }
    public class DcTerm
    {
        [XmlText]
        public required string Value { get; set; }
        [XmlAttribute("id")]
        public string? Id { get; set; }
        [XmlAttribute("dir")]
        public string? Dir { get; set; }
        [XmlAttribute("xml:lang")]
        public string? XmlLang { get; set; }
    }
    public class Meta
    {
        [XmlAttribute("name")]
        public required string Name { get; set; }
        [XmlAttribute("content")]
        public required string Content { get; set; }
        [XmlAttribute("property")]
        public string? Property { get; set; }
        [XmlAttribute("refines")]
        public string? Refines { get; set; }
        [XmlText]
        public string? Value { get; set; }
    }
    public class Manifest
    {
        [XmlElement("item")]
        public required List<Item> Items { get; set; }
    }
    public class Item
    {
        [XmlAttribute("href")]
        public required string Href { get; set; }

        [XmlAttribute("media-type")]
        public required string MediaType { get; set; }

        [XmlAttribute("id")]
        public required string Id { get; set; }

        [XmlAttribute("media-overlay")]
        public string? MediaOverlay { get; set; }

        [XmlAttribute("properties")]
        public string? Properties { get; set; }

        [XmlAttribute("fallback")]
        public string? Fallback { get; set; }
    }
    public class Spine
    {
        [XmlAttribute("id")]
        public string? Id { get; set; }

        [XmlAttribute("toc")]
        public string? Toc { get; set; }

        [XmlAttribute("page-progression-direction")]
        public string? PageProgressionDirection { get; set; }

        [XmlElement("itemref")]
        public required List<ItemRef> ItemRefs { get; set; }
    }
    public class ItemRef
    {
        [XmlAttribute("idref")]
        public required string IdRef { get; set; }

        [XmlAttribute("properties")]
        public string? Properties { get; set; }

        [XmlAttribute("id")]
        public string? Id { get; set; }

        [XmlAttribute("linear")]
        public string? Linear { get; set; }
    }
    public class Guide
    {
        [XmlElement("reference")]
        public List<Reference>? References { get; set; }
    }
    public class Reference
    {
        [XmlAttribute("type")]
        public required string Type { get; set; }

        [XmlAttribute("href")]
        public required string Href { get; set; }

        [XmlAttribute("title")]
        public string? Title { get; set; }
    }
    public class Collection
    {
        [XmlAttribute("role")]
        public required string Role { get; set; }

        [XmlAttribute("dir")]
        public string? Dir { get; set; }

        [XmlAttribute("id")]
        public string? Id { get; set; }

        [XmlAttribute("xml:lang")]
        public string? XmlLang { get; set; }

        [XmlElement("collection")]
        public List<Collection>? SubCollection { get; set; }

        [XmlElement("link")]
        public List<ItemRef>? Links { get; set; }
    }
    public class Link
    {
        [XmlAttribute("href")]
        public required string Href { get; set; }
    }
}
