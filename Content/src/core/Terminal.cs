using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Numerics;
using Vector2 = System.Numerics.Vector2;

namespace WhatAmI.Content.src.core
{
    internal class Terminal : UD
    {
        TextHandler th;
        internal Terminal() { 
            th = new TextHandler(Game1.Instance.Content.Load<SpriteFont>("fonts/Courier"), new Vector2(100,1000));
        }

        internal override void Update()
        {
            if (Game1.Instance.kh.keyPressed(Keys.Enter))
            {
                th.moveAnchor(new Vector2(0, -1 *th.getTextHeight()));
                parseCommand(th.getCurrentLine());
            }
            th.Update();

        }
        internal override void Draw()
        {
            Game1.Instance.GraphicsDevice.Clear(Color.Black);
            th.Draw();
        }
        
        private void parseCommand(string command)
        {
            if(command == "hello")
            {
                Console.WriteLine("Hello, world!");
            }
            else
                Console.WriteLine("Command not recognzied: " + command);
        }

    }
}
