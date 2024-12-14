
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Numerics;
using System;

namespace WhatAmI
{
    internal class GraphicsManager
    {
        string assetPath = "C:\\Users\\joefr\\source\\repos\\WhatAmI\\Content\\assets\\";
        
        Matrix scale = Matrix.CreateScale(1, 1, 1);
        private Game1 game;
        private SpriteBatch spriteBatch;
        internal Player player;
        private GameTime gameTime;

        internal GraphicsManager(Game1 game)
        {
            this.game = game;
            this.spriteBatch = game.spriteBatch;
        }
        internal void setPlayer()
        {

            player = new Player(generateTexture("green16.png"));
        }
        internal void setGametime(GameTime gametime)
        {
            this.gameTime = gametime;
        }
        internal void setScale(float s)
        {
            scale = Matrix.CreateScale(s, s, 1f);
        }
        internal Matrix getScale()
        {
            return scale;
        }

        internal void init() {
            game.graphics = new GraphicsDeviceManager(game);
            game.Content.RootDirectory = "Content";
            game.IsMouseVisible = true;

            game.graphics.IsFullScreen = true;

            game.graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            game.graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        internal void draw()
        {

            player.runControls(gameTime, game.graphics);

            setScale(2);
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            spriteBatch.Begin(transformMatrix: getScale());
            spriteBatch.Draw(player.getTex(), player.getPos(), Color.White);
            spriteBatch.End();
        }
        internal Texture2D generateTexture(string filePath)
        {
            Texture2D tempTex = null;
            SpriteBatch _spriteBatch = new SpriteBatch(game.GraphicsDevice);

            // TODO: use this.Content to load your game content here
            using (var stream = File.OpenRead(assetPath + "green16.png"))
            {
                tempTex = Texture2D.FromStream(game.GraphicsDevice, stream);
            }
            return tempTex;
        }

    }
}
