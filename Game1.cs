using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace WhatAmI
{
    public class Game1 : Game
    {
        string assetPath = "C:\\Users\\joefr\\source\\repos\\WhatAmI\\Content\\assets\\";
        private Texture2D _mySprite;
        private Texture2D grass;
        
        internal GraphicsManager graphicsManager;
        private List<GameObject> gameObjects;

        internal GraphicsDeviceManager graphics;
        internal SpriteBatch spriteBatch;
        internal GameObject player;

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
            _mySprite = graphicsManager.generateTexture("env\\gree16.png");
            player = new GameObject(_mySprite, new Vector2(200, 200));
            gameObjects = new List<GameObject>();
            gameObjects.Add(player);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
           
            spriteBatch.Begin();
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
