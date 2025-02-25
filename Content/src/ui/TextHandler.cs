﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using WhatAmI.Content.src.entities;

namespace WhatAmI;
internal class TextHandler : UD
{
    private SpriteFont font;
    private List<string> lines = new List<string>{""};
    private KeyboardState previousKeyboardState;
    private List<string> prefixes = new List<string>{""};
    private string prefix = "";
    private Color color;

    //
    private int yOffset = 0;   //vertical position
    private int xOffset = 0;   // Horizontal position in the line
    private int textHeight = 20;

   
    
    private double cursorBlinkTimer = 0;
    private bool showCursor = true;
    private float textWidth;


    private Vector2 anchor;

    internal void setYOffset(int y) {  this.yOffset = y; }
    internal int getYOffset() { return this.yOffset; }
    internal void setPrefix(string prefix) { this.prefix = prefix; }
    internal void setPrefixAtIndex(int index, string  prefix) { this.prefixes[index] = prefix; }
    internal int getTextHeight() {  return textHeight; }
    internal void moveAnchor(Vector2 anchor)
    {
        this.anchor += anchor;
    }
    internal void setXOffset(int offset)
    {
        xOffset = offset;
    }
    internal List<string> getLines()
    {
        return lines;
    }
    internal void setLines(List<string> newLines)
    {
        this.lines = newLines;
    }
    internal string getCurrentLine()
    {
        return lines[yOffset];
    }
    internal void addPrefix(string newLine, bool move)
    {
        lines.Add("");
        prefixes.Add(newLine);
        setXOffset(0);
        setYOffset(getYOffset() + 1);

        if (move)
        {
            moveAnchor(new Vector2(0, -1 * textHeight));
        }

        //yOffset++;
    }

    internal void addLine(string newLine, bool move)
    {
        lines.Add(newLine);
        prefixes.Add("");
        setXOffset(0);
        setYOffset(getYOffset() + 1);

        if (move)
        {
            moveAnchor(new Vector2(0, -1 * textHeight));
        }

        //yOffset++;
    }

    public TextHandler(SpriteFont font, Vector2 anch, Color color)
    {
        this.font = font;
        this.anchor = anch;
        this.color = color;
    }

    

    internal override void Update()
    {
        KeyboardState state = Keyboard.GetState();

        foreach (var key in state.GetPressedKeys())
        {
            if (previousKeyboardState.IsKeyDown(key)) continue;
            string character = ReadKey(key, state);

            if (!string.IsNullOrEmpty(character))
            {
                lines[yOffset] = lines[yOffset].Insert(xOffset, character);
                xOffset ++;
            }
        }
        previousKeyboardState = state;

        
    }

    internal void setOffsets(int x, int y)
    {
        xOffset = x;
        yOffset = y;
    }

    private void moveCursor(int x, int y)
    {
        yOffset += y;
        yOffset = Math.Clamp(yOffset, 0, lines.Count - 1);
        xOffset += x;
        xOffset = Math.Clamp(xOffset, 0, lines[yOffset].Length);

    }

    private void handleBackspace()
    {
        //top left, do nothing
        if (yOffset == 0 &&  xOffset == 0) return;
        //far left, delete line break
        else if(xOffset == 0)
        {
            if (prefix.Length == 0) { 
                xOffset = lines[yOffset - 1].Length;
                lines[yOffset - 1] += lines[yOffset];
                lines.RemoveAt(yOffset);
                yOffset --;
            }
        }
        //otherwise
        else 
        {
            lines[yOffset] = lines[yOffset].Remove(xOffset - 1, 1);
            xOffset--;
        }
    }

    internal void handleEnter()
    {
        lines.Insert(yOffset + 1,lines[yOffset].Substring(xOffset));
        prefixes.Add(prefix);

        lines[yOffset] = lines[yOffset].Substring(0, xOffset);
        xOffset = 0;
    }
   
    private string ReadKey(Keys key, KeyboardState keyboardState)
    {
        bool isShiftDown = keyboardState.IsKeyDown(Keys.LeftShift) || keyboardState.IsKeyDown(Keys.RightShift);

        switch (key)
        {
            

            case Keys.Up:
                moveCursor(0,-1);
                return null;
            case Keys.Down:
                moveCursor(0,1);
                return null;
            case Keys.Left:
                moveCursor(-1, 0);
                return null;
            case Keys.Right:
                moveCursor(1, 0);
                return null;
            case Keys.Back:
                handleBackspace();
                return null;
                
            case Keys.Space: return " ";

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
    internal override void Draw()
    {
        DrawCursor(Game1.Instance.spriteBatch);
        for(int i = 0; i < lines.Count; i++)
        {
            Game1.Instance.spriteBatch.DrawString(font, prefixes[i] + lines[i], anchor + new Vector2(0,textHeight * i), color);
        }
    }

    public void DrawCursor(SpriteBatch spriteBatch)
    {
        
        cursorBlinkTimer += 0.02; // Adjust for blink speed

        if (cursorBlinkTimer >= 1.0)
        {
            showCursor = !showCursor; // Toggle cursor visibility
            cursorBlinkTimer = 0;
        }

        if (showCursor)
        {

            // Draw cursor (a simple rectangle)
            Texture2D cursorTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            cursorTexture.SetData(new[] { color });

            textWidth = font.MeasureString(lines[yOffset].Substring(0, xOffset) + prefixes[yOffset]).X;

            spriteBatch.Draw(cursorTexture, new Rectangle((int)anchor.X + (int)textWidth, (int)anchor.Y + yOffset * textHeight, 2, font.LineSpacing), color);
        }
    }
}
