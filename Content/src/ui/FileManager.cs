using System;
using System.Collections.Generic;
using System.IO;

namespace WhatAmI
{
    internal class FileManager
    {
        private string filePath;
        internal void generateFile(string filename, List<string> lines)
        {
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WhatAmI/Gameobject/");
            if(!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            filePath = Path.Combine(dir, filename);
            File.WriteAllLines(filePath, lines);
        }
    }
}
