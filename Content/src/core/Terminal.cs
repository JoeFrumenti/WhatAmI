using Microsoft.Xna.Framework.Graphics;
using System.Numerics;

namespace WhatAmI
{
    internal class Terminal : DU
    {
        TextHandler th;
        internal Terminal() { 
            th = new TextHandler(Game1.Instance.Content.Load<SpriteFont>("fonts/Courier"), new Vector2(100,100));
        }

        internal override void Draw()
        {

        }
        internal override void Update() 
        { 
        
        }


    }
}
