using EpubReader.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EpubReader.Controller
{
    public class FileController
    {
        private static ZipArchive? UnzipFile(string filepath)
        {
            ZipArchive? archive = null;
            try
            {
                archive = ZipFile.OpenRead(filepath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return archive;
        }

        private static string? FindOpfRoute(ZipArchiveEntry metaFile)
        {
            string? opfRoute = null;
            try
            {
                using Stream metaData = metaFile.Open();
                XmlDocument xmlDoc = new();
                xmlDoc.Load(metaData);
                opfRoute = xmlDoc.SelectSingleNode("//@full-path")?.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return opfRoute;
        }

        private static OpfFile? ReadOpfFile(ZipArchiveEntry opfFile)
        {
            OpfFile? opfFileData = null;
            try
            {
                using Stream opfData = opfFile.Open();
                XmlSerializer serializer = new(typeof(OpfFile));
                opfFileData = (OpfFile?)serializer?.Deserialize(opfData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return opfFileData;
        }

        public static Book? ObtainBookData(string bookPath)
        {
            ZipArchive? archive = UnzipFile(bookPath);
            if (archive == null)
            {
                Console.WriteLine("Error unzipping epub file");
                return null;
            }

            ZipArchiveEntry? metaFile = archive.GetEntry("META-INF/container.xml");
            if (metaFile == null)
            {
                Console.WriteLine("Error finding meta file");
                return null;
            }

            string? opfRoute = FindOpfRoute(metaFile);
            if (opfRoute == null)
            {                 
                Console.WriteLine("Error finding opf file route");
                return null;
            }

            ZipArchiveEntry? opfArchive = archive?.GetEntry(opfRoute);
            if (opfArchive == null)
            {
                Console.WriteLine("Error finding opf file in archive");
                return null;
            }

            OpfFile? opfFile = ReadOpfFile(opfArchive);
            if (opfFile == null)
            {
                Console.WriteLine("Error reading opf file");
                return null;
            }
            string filePathNew = $@"{ConfigurationManager.AppSettings["BookFolder"]}\{bookPath}";

            Book book = new()
            {
                Name = opfFile.Metadata.Title != null ? opfFile.Metadata.Title.Value : "Unknown Title",
                Author = opfFile.Metadata.Creator != null && opfFile.Metadata.Creator.Count > 0 ?
                    string.Join(", ", opfFile.Metadata.Creator.Select(c => c.Value)) : "Unknown Author",
                DateAdded = DateTime.Now,
                FilePath = filePathNew,
                PublishDate = opfFile.Metadata.Date != null && opfFile.Metadata.Date.Count > 0 ? 
                    DateTime.TryParse(opfFile.Metadata.Date[0].Value, out DateTime pubDate) ? pubDate : null : null
            };

            return book;
        }
    }
}
