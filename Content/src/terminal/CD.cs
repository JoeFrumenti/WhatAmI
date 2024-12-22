using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatAmI.Content.src.terminal
{
    internal class CD
    {
        private string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WhatAmI");
        internal string getDir() { return dir;}

        internal void parseCommand(string fullCommand) {
            string command = fullCommand.Substring(fullCommand.IndexOf(" ") + 1);
            if(command =="..")
                dir = Path.GetDirectoryName(dir);
            
            else if(Directory.Exists(dir + "\\" + command))
                dir += ("\\" + command);
            else
                Console.WriteLine("Does not exists");
        }
    }
}
