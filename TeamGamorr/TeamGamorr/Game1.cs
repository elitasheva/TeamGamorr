﻿using System;
using System.Collections.Generic;
using System.Linq;
using WindowsGame1;
using Microsoft.Xna.Framework;
using TeamGamorr.Characters;
using TeamGamorr.Bars;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TeamGamorr.Interfaces;
using TeamGamorr.Items;
using TeamGamorr.States;

namespace TeamGamorr
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private GameState gs;
        private MenuState ms;
       
                   


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 650;
            graphics.PreferredBackBufferWidth = 1000;
            Content.RootDirectory = "Content";
            gs = new GameState();
            ms = new MenuState(graphics);

          
           
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            gs.Initialize(this);  
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gs.LoadContent(this);
            ms.LoadContent(this);
            // TODO: use this.Content to load your game content here

            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            gs.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            ms.Update(this, gameTime);

            if (ms.IsMaleClicked)
            {
                gs.IsMaleActive = true;
                gs.Update(this, gameTime);
            }
            if(ms.IsFemaleClicked)
            {
                gs.IsFemaleActive = true;
                gs.Update(this, gameTime);
            }

            if (gs.IsCharacterDead)
            {
               ms.ChangeGameState(); 
            }

            if (gs.IsWin)
            {
                ms.ChangeGameStateWin();
            }

           
            base.Update(gameTime);

         
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            gs.Draw(this, spriteBatch);
            ms.Draw(this,spriteBatch);
          
            base.Draw(gameTime);
        }

    
    }
}
