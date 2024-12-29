
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Numerics;
using System;
using Microsoft.Xna.Framework.Content;
using WhatAmI.Content.src.entities;
using Vector2 = System.Numerics.Vector2;

namespace WhatAmI.Content.src.core
{
    internal class GraphicsManager
    {
        string assetPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WhatAmI");
       

        Matrix scale = Matrix.CreateScale(1, 1, 1);
        private Game1 game;
        private SpriteBatch spriteBatch;
        internal Player player;
        private GameTime gameTime;

        internal GraphicsManager(Game1 game)
        {
            this.game = game;
            this.spriteBatch = game.spriteBatch;
            Console.WriteLine(assetPath);
        }
        internal void setPlayer()
        {

            player = new Player(generateTexture("env\\green16.png"), new Vector2(100,100));
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
            game._graphics = new GraphicsDeviceManager(game);
            game.Content.RootDirectory = "Content";
            game.IsMouseVisible = true;

            game._graphics.IsFullScreen = true;

            game._graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            game._graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        internal void draw()
        {

            player.runControls(gameTime, game._graphics);

            setScale(2);
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            spriteBatch.Begin(transformMatrix: getScale());
            spriteBatch.Draw(player.getTex(), player.getPos(), Color.White);
            spriteBatch.End();
        }
        internal Texture2D generateTexture(string filePath)
        {
            try { 
                Texture2D tempTex = null;
                SpriteBatch _spriteBatch = new SpriteBatch(game.GraphicsDevice);
                //C:\Users\joefr\Desktop\Gamedev\WhatAmI\Content\assets\textures\env\green16.png
                // TODO: use this.Content to load your game content here
                using var stream = File.OpenRead(Path.Combine(assetPath, filePath));
                {
                    tempTex = Texture2D.FromStream(game.GraphicsDevice, stream);
                }
                return tempTex;
        
            }
        catch (FileNotFoundException){ 
                Console.WriteLine($"Error: Unable to load texture at 'Textures/{filePath}'. Returning a default texture");
                return generateFallbackTexture();
            }
        }

        private Texture2D generateFallbackTexture() {
            Texture2D tempTex = null;
            SpriteBatch _spriteBatch = new SpriteBatch(game.GraphicsDevice);

            // TODO: use this.Content to load your game content here
            using (var stream = File.OpenRead(assetPath + "\\assets\\textures\\general\\fallback.png"))
            {
                tempTex = Texture2D.FromStream(game.GraphicsDevice, stream);
            }
            return tempTex;
        }
    }
}
