﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MFarooqiFinalProject
{
    public class StartScene : GameScene
    {

        private MenuComponent menu;
        private SpriteBatch spriteBatch;
        string[] menuItems = {"Start Game",
        "Help",
        "High Score",
        "About",
        "Quit"};

        public StartScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;

            SpriteFont regularFont = g.Content.Load<SpriteFont>("Fonts/RegularFont");
            SpriteFont hilightFont = game.Content.Load<SpriteFont>("Fonts/HilightFont");

            menu = new MenuComponent(game, spriteBatch, regularFont, hilightFont, menuItems);
            this.Components.Add(menu);

        }

        public MenuComponent Menu { get => menu; set => menu = value; }
    }
}
