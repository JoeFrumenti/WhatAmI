﻿using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace WhatAmI
{
    public class Player
    {
        float speed;
        Vector2 pos;
        Texture2D texture;
        internal Player(Texture2D tex)
        {
            speed = 100f;
            pos = new Vector2(0,0);
            texture = tex;
        }
        internal Texture2D getTex()
        { return texture; }
        internal Vector2 getPos() {  return pos; }

        internal void runControls(GameTime gameTime, GraphicsDeviceManager _graphics)
        {

            // The time since Update was called last.
            float updatedSpeed = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                pos.Y -= updatedSpeed;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                pos.Y += updatedSpeed;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                pos.X -= updatedSpeed;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                pos.X += updatedSpeed;
            }


            if (pos.X > _graphics.PreferredBackBufferWidth - texture.Width / 2)
            {
                pos.X = _graphics.PreferredBackBufferWidth - texture.Width / 2;
            }
            else if (pos.X < texture.Width / 2)
            {
                pos.X = texture.Width / 2;
            }

            if (pos.Y > _graphics.PreferredBackBufferHeight - texture.Height / 2)
            {
                pos.Y = _graphics.PreferredBackBufferHeight - texture.Height / 2;
            }
            else if (pos.Y < texture.Height / 2)
            {
                pos.Y = texture.Height / 2;
            }
        }
    }
}
