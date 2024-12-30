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
        internal Button closeButton;

        public Window(Vector2 anch, Vector2 s, Color c, string name) 
        {
            this.anchor = anch;
            this.size = s;
            this.color = c;

            closeButtonTex = Game1.Instance._graphicsManager.generateTexture("assets\\textures\\ui\\CloseIcon.png");

            Vector2 closeAnchor = getTopRight(new Vector2(0,0)) + new Vector2(-40,-40);

            closeButton = new Button(closeButtonTex, new Rectangle((int)closeAnchor.X,(int)closeAnchor.Y,40,40));

            closeButton.OnClick += () =>
            {
                Game1.Instance.uds.removeUD(name);
            };
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
            windowTexture.SetData(new[] { Color.White});

            int screenWidth = Game1.Instance.GraphicsDevice.Viewport.Width;
            int screenHeight = Game1.Instance.GraphicsDevice.Viewport.Height;

            int screenX = (int)(anchor.X * screenWidth);
            int screenY = (int)(anchor.Y * screenHeight);

            

            int windowHeight = (int)(size.Y * screenHeight);
            int windowWidth = (int)(size.X * screenWidth);

            if (screenY < 40)
            {
                screenY = 40;
                closeButton.setBounds(new Rectangle(screenX + windowWidth - 40,screenY - 40,40,40));
            }

            Game1.Instance.spriteBatch.Draw(windowTexture, new Rectangle(screenX, screenY, windowWidth, windowHeight), color);
            Game1.Instance.spriteBatch.Draw(windowTexture, new Rectangle(screenX, screenY-40, windowWidth, 40), Color.Gray);

            
            closeButton.Draw();
        
        }
    }
}
