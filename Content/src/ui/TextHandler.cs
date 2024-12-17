﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WhatAmI;
public class TextHandler
{
    private SpriteFont font;
    private string text = "";
    private KeyboardState previousKeyboardState;

    public TextHandler(SpriteFont font)
    {
        this.font = font;
    }

    public void Update(GameTime gameTime)
    {
        var currentKeyboardState = Keyboard.GetState();

        foreach (var key in currentKeyboardState.GetPressedKeys())
        {
            if (previousKeyboardState.IsKeyDown(key)) continue;


            // Check if the key is a letter, number, or punctuation

            string character = GetCharacterFromKey(key, currentKeyboardState);

            if (!string.IsNullOrEmpty(character))
            {
                text += character;  // Add the character to your text
            }

            
            
            //    else if (key == Keys.Space)
            //    {
            //        text += " "; // Add a space
            //    }
            //    else if (key >= Keys.A && key <= Keys.Z)
            //    {
            //        text += key.ToString(); // Add the pressed letter
            //    }
            //    else if (key >= Keys.D0 && key <= Keys.D9)
            //    {
            //        // Add numbers
            //        text += key.ToString().Replace("D", ""); // Remove "D" prefix from number keys
            //    }
            //    else if (key >= Keys.NumPad0 && key <= Keys.NumPad9)
            //    {
            //        // Add numbers from NumPad
            //        text += ((int)(key - Keys.NumPad0)).ToString();
            //    }

        }
        previousKeyboardState = currentKeyboardState;


    }
    private string GetCharacterFromKey(Keys key, KeyboardState keyboardState)
    {
        bool isShiftDown = keyboardState.IsKeyDown(Keys.LeftShift) || keyboardState.IsKeyDown(Keys.RightShift);

        switch (key)
        { 

            case Keys.Back: {if (text.Length > 0) text = text[..^1]; return null;}
            case Keys.Space: return " ";
            //case Keys.Comma: return isShiftDown ? "<" : ",";
            //case Keys.Period: return isShiftDown ? ">" : ".";
            //case Keys.Semicolon: return isShiftDown ? ":" : ";";
            //case Keys.Quote: return isShiftDown ? "\"" : "'";

            // Handling numbers with Shift
            case Keys.D0: return isShiftDown ? ")" : "0";
            case Keys.D1: return isShiftDown ? "!" : "1";
            case Keys.D2: return isShiftDown ? "@" : "2";
            case Keys.D3: return isShiftDown ? "#" : "3";
            case Keys.D4: return isShiftDown ? "$" : "4";
            case Keys.D5: return isShiftDown ? "%" : "5";
            case Keys.D6: return isShiftDown ? "^" : "6";
            case Keys.D7: return isShiftDown ? "&" : "7";
            case Keys.D8: return isShiftDown ? "*" : "8";
            case Keys.D9: return isShiftDown ? "(" : "9";

            // Letters (handle uppercase and lowercase based on Shift)
            case Keys.A: return isShiftDown ? "A" : "a";
            case Keys.B: return isShiftDown ? "B" : "b";
            case Keys.C: return isShiftDown ? "C" : "c";
            case Keys.D: return isShiftDown ? "D" : "d";
            case Keys.E: return isShiftDown ? "E" : "e";
            case Keys.F: return isShiftDown ? "F" : "f";
            case Keys.G: return isShiftDown ? "G" : "g";
            case Keys.H: return isShiftDown ? "H" : "h";
            case Keys.I: return isShiftDown ? "I" : "i";
            case Keys.J: return isShiftDown ? "J" : "j";
            case Keys.K: return isShiftDown ? "K" : "k";
            case Keys.L: return isShiftDown ? "L" : "l";
            case Keys.M: return isShiftDown ? "M" : "m";
            case Keys.N: return isShiftDown ? "N" : "n";
            case Keys.O: return isShiftDown ? "O" : "o";
            case Keys.P: return isShiftDown ? "P" : "p";
            case Keys.Q: return isShiftDown ? "Q" : "q";
            case Keys.R: return isShiftDown ? "R" : "r";
            case Keys.S: return isShiftDown ? "S" : "s";
            case Keys.T: return isShiftDown ? "T" : "t";
            case Keys.U: return isShiftDown ? "U" : "u";
            case Keys.V: return isShiftDown ? "V" : "v";
            case Keys.W: return isShiftDown ? "W" : "w";
            case Keys.X: return isShiftDown ? "X" : "x";
            case Keys.Y: return isShiftDown ? "Y" : "y";
            case Keys.Z: return isShiftDown ? "Z" : "z";

            // Handle other punctuation with Shift (e.g., `@`, `$`, etc.)
            case Keys.OemOpenBrackets: return isShiftDown ? "{" : "[";
            case Keys.OemCloseBrackets: return isShiftDown ? "}" : "]";

            // Backslash
            case Keys.OemPipe: return isShiftDown ? "|" : "\\";

            // Slash
            case Keys.OemQuestion: return isShiftDown ? "?" : "/";

            // Equals
            case Keys.OemPlus: return isShiftDown ? "+" : "=";

            // Hyphen
            case Keys.OemMinus: return isShiftDown ? "_" : "-";
            case Keys.OemComma: return isShiftDown ? "<" : ",";
            case Keys.OemPeriod: return isShiftDown ? ">" : ".";
            case Keys.OemSemicolon: return isShiftDown ? ":" : ";";
            case Keys.OemTilde: return isShiftDown ? "~" : "`";
            case Keys.OemQuotes: return isShiftDown ? "\"" : "'";
            default: return null;  // Ignore any other keys
        }
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
    {
        spriteBatch.DrawString(font, text, position, color);
    }
}
