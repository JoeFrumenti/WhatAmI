using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WhatAmI
{
    internal class Renderer
    {
        private Texture2D _texture;

        public Renderer(Texture2D texture)
        {
            _texture = texture;
        }
        internal void draw(SpriteBatch sb, Vector2 position)
        {
            if (sb == null)
                Console.WriteLine("Null, but drawing object with graphics device anyways!");
            else
            {
                sb.Draw(_texture, position, Color.White);
            }
        }
    }


}
