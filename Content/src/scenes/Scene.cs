using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatAmI
{
    public abstract class Scene
    {
        // Called when the scene is loaded
        public abstract void LoadContent();

        // Called every frame to update scene logic
        public abstract void Update(GameTime gameTime);

        // Called every frame to render the scene
        public abstract void Draw(SpriteBatch spriteBatch);

        // Called when switching away from this scene to clean up resources
        public abstract void UnloadContent();
    }
}
