using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ReportToExcelParser.Methods
{
    public class Unwrapper
    {
        #region Sync

        public static T UnWrapSync<T>(string path)
        {
            XmlSerializer ser = new(typeof(T));
            using (XmlReader reader = XmlReader.Create(path))
            {
                
                return (T)ser.Deserialize(reader);
            }
        }

        public static List<T> UnWrapFiles<T>(FileInfo[] files)
        {
            var Reports = new List<T>();
            foreach (FileInfo item in files)
            {
                try
                {
                    Reports.Add(UnWrapSync<T>(item.FullName));
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }

            return Reports;
        }

        public static List<T> UnWrapFiles<T>(string path)
        {
            List<FileInfo> fileInfos = new();
            Directory.GetFiles(path).ToList().ForEach(x => fileInfos.Add(new FileInfo(x)));

            return UnWrapFiles<T>(fileInfos.ToArray());
        }

        #endregion Sync

        #region Async

        public static async Task<T> UnWrapAsync<T>(string path)
        {
            return await Task.Run(() =>
            {
                XmlSerializer deserializer = new(typeof(T));

                using (StreamReader reader = new StreamReader(path,System.Text.Encoding.UTF8))
                {
                    string content = File.ReadAllText(path);
                    var encoding = GetXmlEncoding(content);
                    return (T)deserializer.Deserialize(reader);
                }
            });
        }

        public static async Task<T[]> UnWrapFilesAsync<T>(FileInfo[] files)
        {
            return await Task.WhenAll(files.Select(i => UnWrapAsync<T>(i.FullName))).ConfigureAwait(false);
        }
        public static async Task<T[]> UnWrapFilesAsync<T>(List<FileInfo> files)
        {
            return await Task.WhenAll(files.Select(i => UnWrapAsync<T>(i.FullName))).ConfigureAwait(false);
        }
        public static async Task<T[]> UnWrapFilesAsync<T>(string path)
        {
            List<FileInfo> fileInfos = new();
            Directory.GetFiles(path).ToList().ForEach(x => fileInfos.Add(new FileInfo(x)));
            return await UnWrapFilesAsync<T>(fileInfos.ToArray());
        }
        #endregion Async


        private static string GetXmlEncoding(string xmlString)
        {
            using (StringReader stringReader = new StringReader(xmlString))
            {
                var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };

                var reader = XmlReader.Create(stringReader, settings);
                reader.Read();

                var encoding = reader.GetAttribute("encoding");

                return encoding;
            }
        }
    }
}