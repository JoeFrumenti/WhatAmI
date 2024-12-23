using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
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
            th.setPrefixAtIndex(0, cd.getDir() + ">");
            th.setXOffset(th.getCurrentLine().Length);
        }

        internal override void Update()
        {
            if (Game1.Instance.kh.keyPressed(Keys.Enter))
            {
                parseCommand(th.getCurrentLine());

                th.setPrefix(cd.getDir() + ">");
                th.Update();
                th.handleEnter();
                th.moveAnchor(new Vector2(0, -1 * th.getTextHeight()));
                th.setYOffset(th.getYOffset() + 1);
                th.setXOffset(0);
            }

            else
                th.Update();

        }
        internal override void Draw()
        {
            Game1.Instance.GraphicsDevice.Clear(Color.Black);
            th.Draw();
        }

        private void parseCommand(string input)
        {
            string command  = input;

            if (command == "hello")
            {
                th.addLine("Hello, world!");
            }
            else if(command.Length >=3 && command.Substring(0,3) == "cd ")
                cd.parseCommand(command);
            else if(command == "exit") 
                exit();
            else if(command == "text")
            {
                TextEditor te = new TextEditor(Game1.Instance.Content.Load<SpriteFont>("fonts/Courier"));
                Game1.Instance.prepUD("TextEditor", te);
                exit();


            }
            else if(command == "ls")
            {
                th.addLine("");
                string[] entries = Directory.GetFileSystemEntries(cd.getDir());
                foreach (string file in entries)
                {
                    th.addLine(Path.GetFileName(file));
                    th.moveAnchor(new Vector2(0,-1 * th.getTextHeight()));
                }
                th.addLine("");
                th.moveAnchor(new Vector2(0, -2 * th.getTextHeight()));
            }
            else
                Console.WriteLine("Command not recognzied: " + command);
        }
        private void exit()
        {
            Game1.Instance.removeUD("terminal");
        }
    }
}
