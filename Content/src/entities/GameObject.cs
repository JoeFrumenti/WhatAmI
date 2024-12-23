using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatAmI.Content.src.core;

namespace WhatAmI
{
    internal class GameObject : UD
    {
        public Renderer renderer{  get; private set; }
        public Vector2 Position { get; private set; }

        public GameObject() { }
        public GameObject(Texture2D texture, Vector2 position)
        {
            renderer = new Renderer(texture);
            this.Position = position;
        }
        
        internal override void Update()
        {
            Position += new Vector2(1,0);
        }

        internal override void Draw()
        {
            if (Game1.Instance.spriteBatch == null)
                Console.WriteLine("Null, but drawing object with graphics device anyways!");
            else
            {
                renderer.draw(Game1.Instance.spriteBatch, Position);
            }
        }
    }
}
