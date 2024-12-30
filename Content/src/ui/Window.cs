using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatAmI.Content.src.entities;
using WhatAmI.Content.src.structures;
using static System.Net.Mime.MediaTypeNames;

namespace WhatAmI.Content.src.ui
{
    internal class Window : UD
    {
        internal Vector2 anchor;
        internal Vector2 size;
        internal Color color;


        private Texture2D closeButtonTex;
        private Button closeButton;

        public Window(Vector2 anch, Vector2 s, Color c) 
        {
            this.anchor = anch;
            this.size = s;
            this.color = c;

            closeButtonTex = Game1.Instance._graphicsManager.generateTexture("assets\\textures\\ui\\CloseIcon.png");


            closeButton = new Button(closeButtonTex, new Rectangle(1,1,40,40));

        }

        internal void xClicked()
        {
            
        }

        internal Vector2 getTopRight(Vector2 offset)
        {
            int screenWidth = Game1.Instance.GraphicsDevice.Viewport.Width;
            int screenHeight = Game1.Instance.GraphicsDevice.Viewport.Height;

            float top = anchor.Y * screenHeight;
            top += offset.Y * screenHeight * size.Y;

            float right = anchor.X * screenWidth + screenWidth * size.X;
            right -= offset.X * screenWidth * size.X;
            return this.anchor + new Vector2(right, top);
        }
        

        internal Vector2 getBottomLeft(Vector2 offset)
        {
            int screenWidth = Game1.Instance.GraphicsDevice.Viewport.Width;
            int screenHeight = Game1.Instance.GraphicsDevice.Viewport.Height;

            float bottom = anchor.Y * screenHeight + size.Y * screenHeight;
            bottom -= offset.Y * screenHeight * size.Y;

            float left = anchor.X * screenWidth;
            left += offset.X * screenWidth * size.X;
            return this.anchor + new Vector2(left,bottom);
        }

        internal override void Update() {
            closeButton.Update();
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

            Game1.Instance.spriteBatch.Draw(windowTexture, new Rectangle(screenX, screenY, windowWidth, windowHeight), color);
            windowTexture.SetData(new[] {Color.White });
            Game1.Instance.spriteBatch.Draw(windowTexture, new Rectangle(screenX, screenY-40, windowWidth, 40), Color.White);

            closeButton.Draw();
        
        }
    }
}
