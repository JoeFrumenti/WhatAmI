using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatAmI
{
    internal class GameObject
    {
        public Renderer renderer{  get; set; }
        public GameObject()
        {
            renderer = new Renderer();
        }
    }
}
