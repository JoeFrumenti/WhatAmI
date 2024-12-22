using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using WhatAmI.Content.src.core;
using WhatAmI.Content.src.entities;

namespace WhatAmI
{
    public class Game1 : Game
    {
        //Singleton
        private static Game1 _instance;
        public static Game1 Instance => _instance;
        internal KeyHandler kh;

        //assets
        private Texture2D _mySprite;

        
        

        //graphics
        internal GraphicsManager _graphicsManager;
        internal GraphicsDeviceManager _graphics;

        //objects
        private List<UD> uds = new List<UD>();
        private List<GameObject> gameObjects;
        internal SpriteBatch spriteBatch;
        internal GameObject player;

        //text
        private TextHandler textHandler;
        private TextEditor textEditor;


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
            _mySprite = _graphicsManager.generateTexture("env\\green16.png");
            
            //guy movin right for debugging
            player = new GameObject(_mySprite, new Vector2(200, 200));
            gameObjects = new List<GameObject>();
            uds.Add(player);
            

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
                //Console.WriteLine(ud.GetType());
            }



            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
