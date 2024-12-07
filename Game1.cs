using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace WhatAmI
{
    public class Game1 : Game
    {
        string assetPath = "C:\\Users\\joefr\\source\\repos\\WhatAmI\\Content\\assets\\";
        Texture2D ballTexture;
        Player player;
        GraphicsManager graphicsManager;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.IsFullScreen = true;

            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            graphicsManager = new GraphicsManager(_graphics, GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            player = new Player(graphicsManager.generateTexture("green16.png"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.runControls(gameTime, _graphics);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            graphicsManager.setScale(2);
            _spriteBatch.Begin(transformMatrix: graphicsManager.getScale());
            _spriteBatch.Draw(player.getTex(), player.getPos(), Color.White);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
