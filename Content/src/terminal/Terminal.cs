using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using WhatAmI.Content.src.entities;
using WhatAmI.Content.src.orb;
using WhatAmI.Content.src.ui;

namespace WhatAmI.Content.src.terminal
{
    internal class Terminal : UD
    {
        TextHandler th;
        CD cd;
        Orb orb;
        Window window;
        private Dictionary<string, Action<string[]>> commands;
        internal Terminal()
        {
            window = new Window(new Vector2(.1f,.1f), new Vector2(0.5f,0.5f),Color.Black);
            th = new TextHandler(Game1.Instance.Content.Load<SpriteFont>("fonts/Courier"), window.getBottomLeft(new Vector2(0,0)));
            orb = new Orb();
            cd = new CD();
            th.setPrefixAtIndex(0, cd.getDir() + ">");
            th.setXOffset(th.getCurrentLine().Length);
            name = "terminal";

            commands = new Dictionary<string, Action<string[]>>
            {
                { "hello", HelloWorld},
                {"cd", CD },
                { "text", text },
                {"ls", ls },
                {"exit", exit },
                {"touch", touch },
                {"makePlayer", makePlayer },
                {"getArgs", getArgs },
                {"run", runFile },
                {"orb", orbHello },
                {"orbtest", orbTest },
                {"ORB", orbPlayer },
                {"fireball", firstSorcery }
            };

        }
        private void firstSorcery(string[] args)
        {
            Game1.Instance.uds.prepUD((UD)orb.castSorcery(cd.getDir() + "\\scripts\\uds\\scream.sor", Game1.Instance._graphicsManager.generateTexture("assets\\textures\\env\\green16.png")));
        }
        private void orbPlayer(string[] args)
        {
            Game1.Instance.uds.prepUD((UD)orb.makePlayer(Game1.Instance._graphicsManager.generateTexture("assets\\textures\\env\\green16.png")));
        }
        private void orbTest(string[] args) { orb.testHello(); }
        private void orbHello(string[] args) { th.addPrefix((string)orb.hello(), true); }
        private void runFile(string[] args)
        {
            string filePath = cd.getDir() + "\\" + args[0];
            if (File.Exists(filePath))
            {
                // Read all lines into a list of strings
                List<string> lines = new List<string>(File.ReadAllLines(filePath));

                foreach (string s in lines)
                {
                    ExecuteCommand(s);
                }

            }
            else
            {
                th.addPrefix("File does not exist.",true);
            }
        }
        private void getArgs(string[] args)
        {
            foreach(string s in args)
            {
                th.addPrefix(s,true);
            }
        }
        private void makePlayer(string[] args)
        {
            
            Player player = new Player(Game1.Instance._graphicsManager.generateTexture("assets\\textures\\env\\green16.png"), new Microsoft.Xna.Framework.Vector2(int.Parse(args[1]), int.Parse(args[2])));
            if (args.Length > 0)
                Game1.Instance.uds.prepUD(player);
            else
                Game1.Instance.uds.prepUD(player);
        }
        private void touch(string[] args)
        {
            if(args.Length == 0)
            {
                th.addPrefix("No filename given", true);
                return;
            }
            string filepath = cd.getDir() + "//" + args[0];
            using (FileStream fs = File.Create(filepath))
            {
                // File is created and automatically closed by the 'using' block
            }

        }
        private void CD(string[] args)
        {
            if(args.Length == 0)
            {
                th.addPrefix("",true);
                th.addPrefix("Error: no directory given", true);
                th.addPrefix("", true);
                return;
            }
            cd.parseCommand(args[0]);
        }
        private void text(string[] args)
        {
            TextEditor te = new TextEditor(Game1.Instance.Content.Load<SpriteFont>("fonts/Courier"));
            if(args.Length > 0)
            {
                te.loadFile(cd.getDir() + "\\" + args[0]);

            }
            Game1.Instance.uds.prepUD(te);
            exit([""]);
        }
        private void ls(string[] args)
        {
            th.addPrefix("", true);
            string[] entries = Directory.GetFileSystemEntries(cd.getDir());
            foreach (string file in entries)
            {
                th.addPrefix(Path.GetFileName(file), true);
            }
            th.addPrefix("", true);
        }
        private void HelloWorld(string[] args)
        {
            th.addPrefix("Hello, world!", true);
        }
        private void exit(string[] args)
        {
            Game1.Instance.uds.removeUD("terminal");
        }
        internal override void Update()
        {
            if (Game1.Instance.kh.keyPressed(Keys.Enter))
            {
                //move cursor to bottom
                th.setYOffset(th.getLines().Count - 1);
                
                //run command
                ExecuteCommand(th.getCurrentLine());

                //add a new line
                th.addPrefix(cd.getDir() + ">",true);
                th.Update();
                
            }

            else
                th.Update();

        }
        internal override void Draw()
        {
            window.Draw();
            th.Draw();
        }

        private void ExecuteCommand(string input)
        {
            string[] parts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return;

            string command = parts[0];
            string[] args = parts.Length > 1 ? parts[1..] : Array.Empty<string>();
            if (commands.TryGetValue(command, out Action<string[]> action))
            {
                action(args); // Execute the corresponding action with arguments
            }
            else
            {
                th.addPrefix($"Unknown command: {command}",true);
            }
        }

       
        
    }
}
