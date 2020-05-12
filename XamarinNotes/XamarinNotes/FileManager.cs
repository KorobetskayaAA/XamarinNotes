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

        static string FileFullPath()
        {
            return Path.Combine(filePath, defaultFileName);
        }

        static public void SaveText(string text)
        {
            File.WriteAllText(FileFullPath(), text);
        }

        static public string LoadText()
        {
            if (File.Exists(FileFullPath()))
            {
                return File.ReadAllText(FileFullPath());
            }
            return string.Empty;
        }

        static public void DeleteFile()
        {
            if (File.Exists(FileFullPath()))
            {
                File.Delete(FileFullPath());
            }
        }

    }
}
