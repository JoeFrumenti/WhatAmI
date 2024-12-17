using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WhatAmI
{
    public class MainMenuScene : Scene
    {
        private SpriteFont _font;
        public override void LoadContent()
        {
            // Load the font (ensure it's added to the Content Pipeline first)
            _font = Game1.Instance.Content.Load<SpriteFont>("fonts/Courier");
        }

        public override void Update(GameTime gameTime)
        {
            // Example: Switch scenes when Enter is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                SceneManager.Instance.SetActiveScene("GamePlay");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(_font, "Press Enter to Play", new Vector2(100, 10), Color.White);
            spriteBatch.End();
        }

        public override void UnloadContent()
        {
            // No specific cleanup needed for this example
        }
    }
}
