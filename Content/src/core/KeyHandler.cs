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
        public KeyHandler() { }
        KeyboardState previousKeyboardState;
        
        internal bool keyPressed(Keys keyCheck)
        {
            
            KeyboardState state = Keyboard.GetState();
            foreach (var key in state.GetPressedKeys())
            {
                if (previousKeyboardState.IsKeyDown(keyCheck)) {
                    continue;

                }
                if (key == keyCheck)
                {
                    previousKeyboardState = state;
                    return true;
                }
            }
            previousKeyboardState = state;
            return false;

        }
    }
}
