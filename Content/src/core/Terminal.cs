using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Numerics;
using Vector2 = System.Numerics.Vector2;

namespace WhatAmI
{
    internal class Terminal : UD
    {
        TextHandler th;
        internal Terminal() { 
            th = new TextHandler(Game1.Instance.Content.Load<SpriteFont>("fonts/Courier"), new Vector2(100,1000));
        }

        internal override void Draw()
        {
            Game1.Instance.GraphicsDevice.Clear(Color.Black);
            th.Draw();
        }
        internal override void Update() 
        { 
            th.Update();
        }


    }
}
