using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatAmI.Content.src.core;
using WhatAmI.Content.src.entities;
using WhatAmI.Content.src.terminal;
using WhatAmI.Content.src.ui;

namespace WhatAmI.Content.src.structures
{
    internal class ButtonHandler
    {
        private List<Button> buttons;
        
        internal void initializeButtons()
        {
            Button  terminalButton = new Button(Game1.Instance._graphicsManager.generateTexture("assets\\textures\\ui\\TerminalIcon.png"), new Rectangle(10, 10, 100, 100));
            terminalButton.OnClick += () =>
            {
                Terminal terminal = new Terminal();
                Game1.Instance.uds.prepUD(terminal);
            };

            Game1.Instance.uds.addUD(terminalButton);

        

        Button textButton = new Button(Game1.Instance._graphicsManager.generateTexture("assets\\textures\\ui\\TextIcon.png"), new Rectangle(10, 120, 100, 100));
        textButton.OnClick += () =>
            {
                TextEditor te = new TextEditor(Game1.Instance.Content.Load<SpriteFont>("fonts/Courier"));
                Game1.Instance.uds.prepUD(te);
            };
            Game1.Instance.uds.addUD(textButton);
        }
}
}
