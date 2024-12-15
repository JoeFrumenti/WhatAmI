using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WhatAmI
{
    public class Game1 : Game
    {
        //assets
        string assetPath = "C:\\Users\\joefr\\source\\repos\\WhatAmI\\Content\\assets\\";
        private Texture2D _mySprite;
        private Texture2D grass;
        

        //graphics
        internal GraphicsManager graphicsManager;
        internal GraphicsDeviceManager graphics;

        //objects
        private List<GameObject> gameObjects;
        internal SpriteBatch spriteBatch;
        internal GameObject player;

        //text
        private SpriteFont font;
        private StringBuilder textInput = new StringBuilder();

        public Game1()
        {
            graphicsManager = new GraphicsManager(this);
            graphicsManager.init();
            
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            graphicsManager.setPlayer();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _mySprite = graphicsManager.generateTexture("env\\green16.png");
            player = new GameObject(_mySprite, new Vector2(200, 200));
            gameObjects = new List<GameObject>();
            gameObjects.Add(player);
            font = Content.Load<SpriteFont>("fonts/Courier");
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
           
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "sup, world!", new Vector2(10, 10), Color.White);

            foreach (var gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
                gameObject.draw(spriteBatch);
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
