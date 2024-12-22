using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Numerics;
using WhatAmI.Content.src.core;
using Vector2 = System.Numerics.Vector2;

namespace WhatAmI.Content.src.terminal
{
    internal class Terminal : UD
    {
        TextHandler th;
        CD cd;
        internal Terminal()
        {
            th = new TextHandler(Game1.Instance.Content.Load<SpriteFont>("fonts/Courier"), new Vector2(100, 1000));
            
            cd = new CD();
            th.setBottomLine(cd.getDir() + ">");
            th.setXOffset(th.getCurrentLine().Length);
        }

        internal override void Update()
        {
            if (Game1.Instance.kh.keyPressed(Keys.Enter))
            {
                parseCommand(th.getCurrentLine());
                th.Update();
                th.moveAnchor(new Vector2(0, -1 * th.getTextHeight()));
                th.setBottomLine(cd.getDir() + ">");
                th.setXOffset(th.getCurrentLine().Length);
            }


            th.Update();

        }
        internal override void Draw()
        {
            Game1.Instance.GraphicsDevice.Clear(Color.Black);
            th.Draw();
        }

        private void parseCommand(string input)
        {
            string dir = input.Substring(0,input.IndexOf(">"));
            string command  = input.Substring(input.IndexOf(">") + 1);

            if (command == "hello")
            {
                Console.WriteLine("Hello, world!");
            }
            else if(command.Length >=3 && command.Substring(0,3) == "cd ")
                cd.parseCommand(command);
            else
                Console.WriteLine("Command not recognzied: " + command);
        }

    }
}
