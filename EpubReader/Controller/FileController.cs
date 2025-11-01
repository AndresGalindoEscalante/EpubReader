using EpubReader.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
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

        private static string? FindPackageRoute(ZipArchiveEntry metaFile)
        {
            string? PackageRoute = null;
            try
            {
                using Stream metaData = metaFile.Open();
                XmlDocument xmlDoc = new();
                xmlDoc.Load(metaData);
                PackageRoute = xmlDoc.SelectSingleNode("//@full-path")?.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return PackageRoute;
        }

        private static PackageDocument? ReadPackageFile(ZipArchiveEntry opfFile)
        {
            PackageDocument? packageFileData = null;
            try
            {
                using Stream packageData = opfFile.Open();
                XmlSerializer serializer = new(typeof(PackageDocument));
                packageFileData = (PackageDocument?)serializer?.Deserialize(packageData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return packageFileData;
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

            string? packageRoute = FindPackageRoute(metaFile);
            if (packageRoute == null)
            {
                Console.WriteLine("Error finding package file route");
                return null;
            }

            ZipArchiveEntry? packageArchive = archive?.GetEntry(packageRoute);
            if (packageArchive == null)
            {
                Console.WriteLine("Error finding package file in archive");
                return null;
            }

            PackageDocument? packageFile = ReadPackageFile(packageArchive);
            if (packageFile == null)
            {
                Console.WriteLine("Error reading package file");
                return null;
            }

            if (ValidatePackage(packageFile) == false)
            {
                Console.WriteLine("Invalid package file");
                return null;
            }



            string filePathNew = $@"{ConfigurationManager.AppSettings["BookFolder"]}\{bookPath}";
            Book book = new()
            {
                UniqueId = int.TryParse(packageFile.Metadata.Identifier.First().Value, out int id) ? id : 0,
                Name = packageFile.Metadata.Title != null ? packageFile.Metadata.Title.Value : "Unknown Title",
                Author = packageFile.Metadata?.Creator?.Count > 0 ?
                    string.Join(", ", packageFile.Metadata.Creator.Select(c => c.Value)) : "Unknown Author",
                DateAdded = DateTime.Now,
                FilePath = filePathNew,
                PublishDate = FindDate(packageFile) ?? "Unknown Publish Date"
            };
            return book;
        }

        private static string? FindDate(PackageDocument packageFile)
        {
            string? date = packageFile?.Metadata?.Date?.FirstOrDefault()?.Value;
            if (date != null)
                    return date;
            date = packageFile?.Metadata?.Meta?.Find(m => string.Equals(m.Property, "dcterms:date"))?.Value;
                    return date;
        }

        private static bool ValidatePackage(PackageDocument archive)
        {

            return !string.IsNullOrEmpty(archive.Version)
                && archive.Metadata != null
                && archive.Manifest != null
                && archive.Spine != null;
        }

        private static bool ValidateMetadata(Metadata metadata)
        {
            return metadata.Identifier != null
                && metadata.Title != null
                && metadata.Language != null
                && metadata.Meta != null;
        }
    }
}
