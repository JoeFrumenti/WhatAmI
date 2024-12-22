using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatAmI.Content.src.scenes
{
    public class GamePlayScene : Scene
    {
        private Texture2D _sprite;
        private Vector2 _position;

        public override void LoadContent()
        {
            _sprite = Game1.Instance._graphicsManager.generateTexture("env\\green16.png"); 
            _position = new Vector2(200, 200);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _position.X += 5f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _position.X -= 5f;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_sprite, _position, Color.White);
            
        }

        public override void UnloadContent()
        {
            // No cleanup needed for this example
        }
    }

}
