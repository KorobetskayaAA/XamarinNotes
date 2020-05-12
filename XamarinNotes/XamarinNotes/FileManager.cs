using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace XamarinNotes
{
    public static class FileManager
    {
        const string defaultFileName = "note.txt";
        static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        static string FileFullPath(string fileName = defaultFileName)
        {
            return Path.Combine(filePath, fileName);
        }

        public static string RandomFileName
        {
            get => $"{Path.GetRandomFileName()}.{defaultFileName}";
        }

        static public void SaveText(string text, string fileName = defaultFileName)
        {
            File.WriteAllText(FileFullPath(fileName), text);
        }

        static public string LoadText(string fileName = defaultFileName)
        {
            if (File.Exists(FileFullPath(fileName)))
            {
                return File.ReadAllText(FileFullPath(fileName));
            }
            return string.Empty;
        }

        static public void DeleteFile(string fileName = defaultFileName)
        {
            if (File.Exists(FileFullPath(fileName)))
            {
                File.Delete(FileFullPath(fileName));
            }
        }

        static public IEnumerable<string> AllFiles()
        {
            return Directory.EnumerateFiles(filePath, "*." + defaultFileName);
        }

    }
}
