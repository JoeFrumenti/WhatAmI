using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatAmI.Content.src.core
{
    internal class KeyHandler
    {
        KeyboardState previousKeyboardState;
        public KeyHandler() { }
        internal bool keyPressed(Keys k)
        {
            KeyboardState state = Keyboard.GetState();

            foreach (var key in state.GetPressedKeys())
            {
                if (k == key)
                    return true;
            }
            return false;

        }
    }
}
