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
        internal int height;
        internal int width;

        public Window(Vector2 anch, int h, int w) 
        {
            this.anchor = anch;
            this.height = h;
            this.width = w;
        }

        internal override void Update() {
        }

        internal override void Draw()
        {
            Texture2D windowTexture = new Texture2D(Game1.Instance.spriteBatch.GraphicsDevice, 1, 1);
            windowTexture.SetData(new[] { Color.White });

           
            Game1.Instance.spriteBatch.Draw(windowTexture, new Rectangle((int)anchor.X,(int)anchor.Y, width,height), Color.White);
        }
    }
}
