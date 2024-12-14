using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatAmI
{
    internal class GameObject
    {
        public Renderer renderer{  get; private set; }
        public Vector2 position { get; private set; }
        public GameObject(Texture2D texture, Vector2 position)
        {
            renderer = new Renderer(texture);
            this.position = position;
        }
        


        internal void draw(SpriteBatch sb)
        {
            if (sb == null)
                Console.WriteLine("Null, but drawing object with graphics device anyways!");
            else
            {
                renderer.draw(sb, position);
            }
        }
    }
}
