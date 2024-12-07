
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace WhatAmI
{
    internal class GraphicsManager
    {
        string assetPath = "C:\\Users\\joefr\\source\\repos\\WhatAmI\\Content\\assets\\";

        private GraphicsDeviceManager _graphics;
        private GraphicsDevice _graphicsDevice;
        private SpriteBatch _spriteBatch;

        internal GraphicsManager(GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice)
        {
            _graphics = graphics;
            _graphicsDevice = graphicsDevice;
        }

        internal Texture2D generateTexture(string filePath)
        {
            Texture2D tempTex = null;
            _spriteBatch = new SpriteBatch(_graphicsDevice);

            // TODO: use this.Content to load your game content here
            using (var stream = File.OpenRead(assetPath + "green16.png"))
            {
                tempTex = Texture2D.FromStream(_graphicsDevice, stream);
            }
            return tempTex;
        }

    }
}
