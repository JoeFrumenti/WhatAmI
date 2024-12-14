using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace WhatAmI
{
    public class Game1 : Game
    {
        string assetPath = "C:\\Users\\joefr\\source\\repos\\WhatAmI\\Content\\assets\\";
        private Texture2D _mySprite;
        
        internal GraphicsManager graphicsManager;

        internal GraphicsDeviceManager graphics;
        internal SpriteBatch spriteBatch;
        internal GameObject gameObject;

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
            _mySprite = Content.Load<Texture2D>("assets/green16");
            gameObject = new GameObject(_mySprite, new Vector2(200,200));
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
            spriteBatch.Draw(_mySprite, new Vector2(100,100), Color.White);

            gameObject.draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
