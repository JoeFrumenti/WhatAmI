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
            string dir = Path.GetDirectoryName(filename);
            if(!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            File.WriteAllLines(filename, lines);
        }

        internal void openFile(string filename, TextHandler textHandler) 
        {
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WhatAmI/Gameobject/" + filename);
            try { 
            
                List<string > lines = new List<string>(File.ReadAllLines(dir));

                textHandler.setLines(lines);
                textHandler.setOffsets(0,0);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file '{dir}' was not found.");
            }
        }
    }
}
