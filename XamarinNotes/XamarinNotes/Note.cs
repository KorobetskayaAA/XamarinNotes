using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace XamarinNotes
{
    public class Note
    {
        public string FileName { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }

        public Note()
        {
            CreationDate = DateTime.Now;
            FileName = FileManager.RandomFileName;
        }

        public override string ToString()
        {
            return $"{CreationDate}\n{Text}";
        }

        public void FromString(string text)
        {
            string[] lines = text.Split('\n');
            Text = string.Join("\n", lines.Skip(1));
            try
            {
                CreationDate = DateTime.Parse(lines[0]);
            }
            catch
            {
                CreationDate = DateTime.Now;
            }
        }
    }

}
