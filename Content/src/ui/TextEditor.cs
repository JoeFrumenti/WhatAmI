using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using WhatAmI.Content.src.entities;
using WhatAmI.Content.src.ui;

namespace WhatAmI
{

    internal class TextEditor : UD
    {
        TextHandler textHandler;
        FileManager fileManager;

        private KeyboardState pk;
        private string currentFileName = "";

        private Window window;

        internal TextEditor(SpriteFont font)
        {
            textHandler = new TextHandler(font, new Vector2(100, 100),Color.Black);
            fileManager = new FileManager();
            name = "textEditor";

            window = new Window(new Vector2(0.01f,0.01f), new Vector2(0.9f,0.9f), Color.White, name);
            
        }

        internal void loadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                currentFileName = filePath;
                // Read all lines into a list of strings
                textHandler.setLines(new List<string> { });
                List<string> lines = new List<string>(File.ReadAllLines(filePath));

                foreach(string s in lines)
                {
                    textHandler.addLine(s,false);
                }
                if(textHandler.getLines().Count == 0)
                    textHandler.addLine("",false);

                textHandler.setXOffset(0);
                textHandler.setYOffset(0);
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }

        

        internal override void Update()
        {
            window.Update();
            textHandler.Update();
            if (Game1.Instance.kh.keyPressed(Keys.Enter)) { 
                textHandler.handleEnter(); 
                textHandler.setYOffset(textHandler.getYOffset() + 1);
            }
            
        }


        internal override void Draw()
        {
            window.Draw();
            textHandler.Draw();

            KeyboardState state = Keyboard.GetState();


            // Check if F5 is pressed
            if (state.IsKeyDown(Keys.F5) && !pk.IsKeyDown(Keys.F5))
            {
                fileManager.generateFile(currentFileName, textHandler.getLines());
                Console.WriteLine("IT IS WRITTEN");
            }
            else if (state.IsKeyDown(Keys.F4) && !pk.IsKeyDown(Keys.F4))
            {
                fileManager.openFile("poo.txt", textHandler);
            }
            pk = Keyboard.GetState();
        }
    }
}