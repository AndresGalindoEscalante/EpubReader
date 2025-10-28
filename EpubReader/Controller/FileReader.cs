using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace EpubReader.Controller
{
    internal class FileReader
    {
        public static void UnzipFile(string filename)
        {
            try
            {
                string zipPath = @".\Epubs\[gotrek & felix 01] - trollslayer_-, william king.epub";
                //string extractPath = @".\extract";

                //ZipFile.CreateFromDirectory(filename, zipPath);

                var a = ZipFile.OpenRead(zipPath);

                //ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
