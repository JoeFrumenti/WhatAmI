using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace WhatAmI
{
    
    internal class TextEditor
    {
        TextHandler textHandler;

        internal TextEditor(SpriteFont font)
        {
            textHandler = new TextHandler(font, new Vector2(10, 100));
        }

        internal void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            textHandler.Update(gameTime, spriteBatch);
            textHandler.Draw(spriteBatch);
        }
    }
}
