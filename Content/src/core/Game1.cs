using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using WhatAmI.Content.src.scenes;

namespace WhatAmI
{
    public class Game1 : Game
    {
        //Singleton
        private static Game1 _instance;
        public static Game1 Instance => _instance;

        //assets
        private Texture2D _mySprite;
        

        //graphics
        internal GraphicsManager _graphicsManager;
        internal GraphicsDeviceManager _graphics;

        //objects
        private List<DU> du = new List<DU>();
        private List<GameObject> gameObjects;
        internal SpriteBatch spriteBatch;
        internal GameObject player;

        //text
        private TextHandler textHandler;
        private TextEditor textEditor;

        //scenes
        private SceneManager _sceneManager;

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
            _sceneManager = new SceneManager();
            _sceneManager.AddScene("MainMenu", new MainMenuScene());
            _sceneManager.AddScene("GamePlay", new GamePlayScene());
            _sceneManager.SetActiveScene("MainMenu");
            terminal = new Terminal();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _mySprite = _graphicsManager.generateTexture("env\\green16.png");
            
            //guy movin right for debugging
            player = new GameObject(_mySprite, new Vector2(200, 200));
            gameObjects = new List<GameObject>();
            gameObjects.Add(player);
            
            //Text editor
            textHandler = new TextHandler(Content.Load<SpriteFont>("fonts/Courier"), new Vector2(100,100));
            textEditor = new TextEditor(Content.Load<SpriteFont>("fonts/Courier"));
            du.Add(textEditor);
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState state = Keyboard.GetState();
           

            textHandler.Update();
            _sceneManager.Update(gameTime);
            base.Update(gameTime);


            foreach (DU obj in du)
            {
                obj.Update();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            //inital stuff
           var keyboardState = Keyboard.GetState();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            _sceneManager.Draw(spriteBatch);


            foreach (DU obj in du)
            {
                obj.Draw();
            }


            //text
            textEditor.Update();

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
