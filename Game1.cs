using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace WhatAmI
{
    public class Game1 : Game
    {
        string assetPath = "C:\\Users\\joefr\\source\\repos\\WhatAmI\\Content\\assets\\";
        
        internal GraphicsManager graphicsManager;
        GameObject gameObject =  new GameObject();

        internal GraphicsDeviceManager graphics;
        internal SpriteBatch spriteBatch;

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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            gameObject.renderer.draw();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            graphicsManager.setGametime(gameTime);
            graphicsManager.setScale(2);
            graphicsManager.draw();


            base.Draw(gameTime);
        }
    }
}
