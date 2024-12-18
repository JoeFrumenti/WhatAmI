using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WhatAmI.Content.src.scenes;

namespace WhatAmI
{
    public class Game1 : Game
    {
        //Singleton
        private static Game1 _instance;
        public static Game1 Instance => _instance;

        //assets
        string assetPath = "C:\\Users\\joefr\\source\\repos\\WhatAmI\\Content\\assets\\";
        private Texture2D _mySprite;
        private Texture2D grass;
        

        //graphics
        internal GraphicsManager _graphicsManager;
        internal GraphicsDeviceManager _graphics;

        //objects
        private List<GameObject> gameObjects;
        internal SpriteBatch spriteBatch;
        internal GameObject player;

        //text
        private KeyboardState previousKeyBoardState;
        private StringBuilder textInput = new StringBuilder();
        private string userInput = "";
        private TextHandler textHandler;

        //scenes
        private SceneManager _sceneManager;

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
            _sceneManager = new SceneManager();
            _sceneManager.AddScene("MainMenu", new MainMenuScene());
            _sceneManager.AddScene("GamePlay", new GamePlayScene());
            _sceneManager.SetActiveScene("MainMenu");

        }

        protected override void LoadContent()
        {
            _graphicsManager.setPlayer();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _mySprite = _graphicsManager.generateTexture("env\\green16.png");
            player = new GameObject(_mySprite, new Vector2(200, 200));
            gameObjects = new List<GameObject>();
            gameObjects.Add(player);
            textHandler = new TextHandler(Content.Load<SpriteFont>("fonts/Courier"), new Vector2(100,100));
            Texture2D blankTexture= new Texture2D(GraphicsDevice, 1, 1);
            blankTexture.SetData(new[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState state = Keyboard.GetState();
            foreach(Keys key in state.GetPressedKeys())
            {
                if(key == Keys.Back && textInput.Length > 0) 
                    textInput.Remove(textInput.Length - 1, 1);
                else 
                    textInput.Append(key.ToString());

            }

            textHandler.Update(gameTime, spriteBatch);
            _sceneManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //inital stuff
           var keyboardState = Keyboard.GetState();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _sceneManager.Draw(spriteBatch);

            spriteBatch.Begin();


            //scene


            //text
            textHandler.Update(gameTime, spriteBatch);

            textHandler.Draw(spriteBatch, Color.White);
            textHandler.DrawCursor(spriteBatch);

            //gameobjects
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
                gameObject.Draw(spriteBatch);
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
