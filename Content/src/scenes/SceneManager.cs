using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace WhatAmI
{
    internal class SceneManager
    {
        private static SceneManager _instance;
        public static SceneManager Instance => _instance;

        private Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();
        private Scene activeScene;

        internal SceneManager() { 
            _instance = this;
        }

        

        public void AddScene(string key, Scene scene)
        {
            scenes[key] = scene;
        }

        public void SetActiveScene(string key)
        {
            if (scenes.ContainsKey(key))
            {
                activeScene?.UnloadContent(); // Unload current scene, if any
                activeScene = scenes[key]; // Switch to the new scene
                activeScene.LoadContent(); // Load new scene
            }
            else
            {
                throw new Exception($"Scene with key '{key}' not found.");
            }
        }

        public void Update(GameTime gameTime)
        {
            activeScene?.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            activeScene?.Draw(spriteBatch);
        }
        internal void LoadContent()
        {

        }
      
        internal void UnloadContent()
        {

        }
    }
}
