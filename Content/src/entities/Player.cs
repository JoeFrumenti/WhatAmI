using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;


using WhatAmI.Content.src.core;
using System;

namespace WhatAmI.Content.src.entities;

internal class Player : GameObject
{
    float speed;
    Vector2 pos;
    Texture2D texture;
    internal Player(Texture2D tex, Vector2 pos) : base(tex,pos)
    {
        speed = 100f;
        this.pos = pos;
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


        if (pos.X > _graphics.PreferredBackBufferWidth - texture.Width)
        {
            pos.X = _graphics.PreferredBackBufferWidth - texture.Width;
        }
        else if (pos.X < 0)
        {
            pos.X = 0;
        }

        if (pos.Y > _graphics.PreferredBackBufferHeight - texture.Height)
        {
            pos.Y = _graphics.PreferredBackBufferHeight - texture.Height;
        }
        else if (pos.Y < 0)
        {
            pos.Y = 0;
        }
    }
    internal override void Update()
    {
        pos.X ++;
    }
    internal override void Draw()
    {
        if (Game1.Instance.spriteBatch == null)
            Console.WriteLine("Null, but drawing object with graphics device anyways!");
        else
        {
            renderer.draw(Game1.Instance.spriteBatch, pos);
        }
    }
}
