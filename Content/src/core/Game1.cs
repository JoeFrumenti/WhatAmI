using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using WhatAmI.Content.src.core;
using WhatAmI.Content.src.entities;
using WhatAmI.Content.src.structures;
using WhatAmI.Content.src.terminal;
using WhatAmI.Content.src.ui;

namespace WhatAmI
{
    public class Game1 : Game
    {
        //Singleton
        private static Game1 _instance;
        
        public static Game1 Instance => _instance;
        public GameTime CurrentGameTime { get; set; }
        public MouseState mouseState { get; set; }
        internal KeyHandler kh;


        //graphics
        internal GraphicsManager _graphicsManager;
        internal GraphicsDeviceManager _graphics;
        internal SpriteBatch spriteBatch;
        Texture2D mouseTexture;

        //objects
        internal UDHandler newUds;

        private Button terminalButton;



        Player p;


        //terminal
        Terminal terminal;

       
        public Game1()
        {
            _instance = this;
            _graphicsManager = new GraphicsManager(this);
            _graphicsManager.init();
            IsMouseVisible = true;
            newUds = new UDHandler();
            
        }

        protected override void Initialize()
        {
            base.Initialize();
            kh = new KeyHandler();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //Mouse
            mouseTexture = _graphicsManager.generateTexture("assets\\textures\\ui\\mouse.png");


            p = new Player(_graphicsManager.generateTexture("assets\\textures\\env\\green16.png"), new Vector2(100,100));
            newUds.addUD(p);

            terminalButton = new Button(_graphicsManager.generateTexture("assets\\textures\\ui\\TerminalIcon.png"), new Rectangle(10,10,100,100));
            terminalButton.OnClick += () =>
            {
                Terminal terminal = new Terminal();
                newUds.prepUD(terminal);
            };
            
            newUds.addUD(terminalButton);

        }

        protected override void Update(GameTime gameTime)
        {
            CurrentGameTime = gameTime;
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState state = Keyboard.GetState();
           
           
            newUds.Update();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //inital stuff
            var keyboardState = Keyboard.GetState();
            GraphicsDevice.Clear(Color.CornflowerBlue);




            newUds.Draw();

            spriteBatch.Begin();
            spriteBatch.Draw(mouseTexture, new Vector2(mouseState.X, mouseState.Y), Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
