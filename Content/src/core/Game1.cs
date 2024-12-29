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
        private UDHandler newUds;

        private SortedDictionary<string, UD> uds = new SortedDictionary<string, UD>();
        private Dictionary<string, UD> prepCache = new Dictionary<string, UD>();
        private Button terminalButton;



        Player p;


        //terminal
        Terminal terminal;

        internal void addTerminal()
        {
            terminal = new Terminal();
            prepUD("terminal", terminal);
        }
        internal void moveCache()
        {
            foreach (var kvp in prepCache)
            {
                uds[kvp.Key] = kvp.Value;

            }
            prepCache.Clear();
        }
        internal void removeUD(string name)
        {
            uds.Remove(name);
        }
        internal void prepUD(string name, UD ud)
        {
            prepCache.Add(name, ud);
        }
        internal void addUD(string key, UD ud)
        {
            //Console.WriteLine("ADDING: " + key);
            uds.Add(key, ud);
        }
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
            

            //Mouse
            mouseTexture = _graphicsManager.generateTexture("assets\\textures\\ui\\mouse.png");

            //te = new TextEditor(Content.Load<SpriteFont>("fonts/Courier"));
            //uds.Add("txt", te);

            p = new Player(_graphicsManager.generateTexture("assets\\textures\\env\\green16.png"), new Vector2(100,100));
            uds.Add("p", p);

            terminalButton = new Button(_graphicsManager.generateTexture("assets\\textures\\ui\\TerminalIcon.png"), new Rectangle(10,10,100,100));
            terminalButton.OnClick += () =>
            {
                Terminal terminal = new Terminal();
                prepUD("2",terminal);
            };
            
            uds.Add("1",terminalButton);

        }

        protected override void Update(GameTime gameTime)
        {
            CurrentGameTime = gameTime;
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState state = Keyboard.GetState();
           
            foreach (UD ud in uds.Values)
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



            foreach (UD ud in uds.Values)
            {
                spriteBatch.Begin();
                ud.Draw(); 
                spriteBatch.End();
            }
            spriteBatch.Begin();
            spriteBatch.Draw(mouseTexture, new Vector2(mouseState.X, mouseState.Y), Color.White);
            spriteBatch.End();

            moveCache();

            base.Draw(gameTime);
        }
    }
}
