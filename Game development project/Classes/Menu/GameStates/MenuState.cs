﻿using Game_development_project.Classes.Menu.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Game_development_project.Classes.GameStates
{
    internal abstract class MenuState : GameState
    {
        #region Private variables

        private List<MenuComponent> buttonList;

        #endregion

        #region Get/Setters

        public List<MenuComponent> ButtonList
        {
            get { return buttonList; }
            set { buttonList = value; }
        }

        public Texture2D ButtonTexture { get; private set; }
        public SpriteFont ButtonFont { get; private set; }
        public Texture2D BackgroundImage { get; set; }
        public Texture2D MainText { get; set; }

        #endregion


        #region Methods

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        { 
            LoadContent(content);
            InitializeContent();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(BackgroundImage, new Vector2(0, 0), Color.White);
            spriteBatch.End();

            spriteBatch.Begin();

            if (ButtonList != null)
            {
                foreach (var button in ButtonList)
                    button.Draw(gameTime, spriteBatch);
            }
           
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if (ButtonList != null)
            {
                foreach (var button in ButtonList)
                    button.Update(gameTime);
            }
            
        }

        protected void QuitGameButton_Click(object sender, EventArgs e)
        {
            Game.Exit();
        }

        public override void LoadContent(ContentManager content)
        {
            ButtonTexture = content.Load<Texture2D>("Textures/Menu/Button");
            ButtonFont = content.Load<SpriteFont>("Fonts/ButtonFont");
            BackgroundImage = content.Load<Texture2D>("Textures/Backgrounds/MainMenuBackground");
        }

        #endregion


    }
}

