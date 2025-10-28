using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using EpubReader.Model;
using System.IO;
using System.Xml;

namespace EpubReader.Controller
{
    internal class FileController
    {
        private static ZipArchive UnzipFile(string filepath)
        {
            ZipArchive archive = null;
            try
            {
                string zipPath = @".\Epubs\[gotrek & felix 01] - trollslayer_-, william king.epub";

                archive = ZipFile.OpenRead(filepath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return archive;
        }

        //public static void ReadEpubFile(ZipArchive archive)
        //{
        //    try
        //    {
        //        foreach (var entry in archive.Entries)
        //        {
        //            Console.WriteLine(entry.FullName);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}
        private string FindOpfRoute(ZipArchiveEntry metaFile)
        {
            string opfRoute = "";
            try
            {
                using (Stream metaData = metaFile.Open())
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(metaData);
                    opfRoute = xmlDoc.SelectSingleNode("//@full-path")?.Value;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return opfRoute;
        }

        public static Book ObtainBookData(string bookPath)
        {
            Book book = new Book();
            try
            {
                ZipArchive archive = UnzipFile(bookPath);
                ZipArchiveEntry metaFile = archive.GetEntry("META-INF/container.xml");
                string opfRoute = new FileController().FindOpfRoute(metaFile);
                ZipArchiveEntry opfFile = archive.GetEntry(opfRoute);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return book;
        }
    }
}
