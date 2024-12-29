using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatAmI.Content.src.entities
{
    internal abstract class UD
    {
        internal string name;
        internal abstract void Update();
        internal abstract void Draw();

        internal string getName() {  
            if(name != null) 
                return name; 
            else
            {
                Console.WriteLine("ERROR: Name not defined.");
                return null; 
            }
        }
        
    }
}
