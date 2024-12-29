using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatAmI.Content.src.entities;
using static System.Net.Mime.MediaTypeNames;

namespace WhatAmI.Content.src.ui
{
    internal class Window : UD
    {
        internal Vector2 anchor;
        internal Vector2 size;
        internal Color color;

        public Window(Vector2 anch, Vector2 s, Color c) 
        {
            this.anchor = anch;
            this.size = s;
            this.color = c;
        }

        internal override void Update() {
        }

        internal override void Draw()
        {
            Texture2D windowTexture = new Texture2D(Game1.Instance.spriteBatch.GraphicsDevice, 1, 1);
            windowTexture.SetData(new[] { color});

            int screenWidth = Game1.Instance.GraphicsDevice.Viewport.Width;
            int screenHeight = Game1.Instance.GraphicsDevice.Viewport.Height;

            int screenX = (int)(anchor.X * screenWidth);
            int screenY = (int)(anchor.Y * screenHeight);

            int windowHeight = (int)(size.Y * screenHeight);
            int windowWidth = (int)(size.X * screenWidth);
           
            Game1.Instance.spriteBatch.Draw(windowTexture, new Rectangle(screenX,screenY,windowWidth, windowHeight), color);
            Console.WriteLine(windowWidth);
        }
    }
}
