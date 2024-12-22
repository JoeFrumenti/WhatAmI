using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using WhatAmI.Content.src.core;

namespace WhatAmI
{
    
    internal class TextEditor : UD
    {
        TextHandler textHandler;
        FileManager fileManager;

        private KeyboardState pk;

        internal TextEditor(SpriteFont font)
        {
            textHandler = new TextHandler(font, new Vector2(10, 100));
            fileManager = new FileManager();
        }

        internal override void Update()
        {
            textHandler.Update();
            
        }
        internal override void Draw()
        {
            textHandler.Draw();

            KeyboardState state = Keyboard.GetState();


            // Check if F5 is pressed
            if (state.IsKeyDown(Keys.F5) && !pk.IsKeyDown(Keys.F5))
            {
                fileManager.generateFile("output.txt", textHandler.getLines());
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