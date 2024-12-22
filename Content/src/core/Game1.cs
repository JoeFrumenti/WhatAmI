using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using WhatAmI.Content.src.core;
using WhatAmI.Content.src.terminal;

namespace WhatAmI
{
    public class Game1 : Game
    {
        //Singleton
        private static Game1 _instance;
        public static Game1 Instance => _instance;
        internal KeyHandler kh;


        //graphics
        internal GraphicsManager _graphicsManager;
        internal GraphicsDeviceManager _graphics;
        internal SpriteBatch spriteBatch;

        //objects
        private List<UD> uds = new List<UD>();


        //terminal
        Terminal terminal;

        public Game1()
        {
            _instance = this;
            _graphicsManager = new GraphicsManager(this);
            _graphicsManager.init();
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            base.Initialize();
            kh = new KeyHandler();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //Terminal 
            terminal = new Terminal();
            uds.Add(terminal);
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState state = Keyboard.GetState();
           
            foreach (UD ud in uds)
            {
                ud.Update();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //inital stuff
            var keyboardState = Keyboard.GetState();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();


            foreach (UD ud in uds)
            {
                ud.Draw();
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
