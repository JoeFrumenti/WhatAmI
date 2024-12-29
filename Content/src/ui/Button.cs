using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using WhatAmI.Content.src.core;

namespace WhatAmI.Content.src.ui;
internal class Button : UD
{
    private Texture2D texture;
    private Rectangle bounds;
    private SpriteFont font;

    public event Action OnClick;

    private MouseState previousMouseState;

    internal Button(Texture2D texture, Rectangle bounds)
    {
        this.texture = texture;
        this.bounds = bounds;
    }

    internal override void Update()
    {
        if (bounds.Contains(Game1.Instance.mouseState.Position) &&
            Game1.Instance.mouseState.LeftButton == ButtonState.Pressed &&
            previousMouseState.LeftButton == ButtonState.Released)
        {
            OnClick?.Invoke();
        }
        previousMouseState = Game1.Instance.mouseState;
    }



    internal override void Draw()
    {
        Game1.Instance.spriteBatch.Draw(texture, bounds, Color.White);

        
    }
}
