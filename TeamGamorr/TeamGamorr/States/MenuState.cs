using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using TeamGamorr.Buttons;
using TeamGamorr.Interfaces;

namespace TeamGamorr.States
{
    public class MenuState
    {
        enum GameState
        {
            MainMenu,
            Options,
            Playing,
            GameOver,
            Win
        }

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Song song;
        private MainButton mainButton;
        private int screenW = 800;
        private int screenH = 600;
        private FemaleButton femaleButton;
        private MaleButton maleButton;
        private GameState CurrentGameState;

        public MenuState(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.CurrentGameState = GameState.MainMenu;
        }

        public bool IsFemaleClicked { get; set; }
        public bool IsMaleClicked { get; set; }


        public void LoadContent(Game1 g)
        {
            this.graphics.PreferredBackBufferWidth = this.screenW;
            this.graphics.PreferredBackBufferHeight = this.screenH;
            this.graphics.ApplyChanges();
            g.IsMouseVisible = true;

            mainButton = new MainButton(g.Content.Load<Texture2D>("Buttons\\EnterButtonBlueGlass"), graphics.GraphicsDevice);
            mainButton.SetPosition(new Vector2(100, 400));
            maleButton = new MaleButton(g.Content.Load<Texture2D>("Buttons\\maleButton"), graphics.GraphicsDevice);
            maleButton.SetPosition(new Vector2(330, 150));
            femaleButton = new FemaleButton(g.Content.Load<Texture2D>("Buttons\\femaleButton"), graphics.GraphicsDevice);
            femaleButton.SetPosition(new Vector2(330, 300));

            song = g.Content.Load<Song>("ElfWarsOST");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }

        public void Update(Game1 g, GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            switch (this.CurrentGameState)
            {
                case GameState.MainMenu:
                    if (mainButton.IsClicked == true)
                    {
                        this.CurrentGameState = GameState.Options;
                    }
                    mainButton.Update(mouse);
                    break;
                case GameState.Options:
                    if (femaleButton.IsClicked == true)
                    {
                        this.IsFemaleClicked = true;
                        this.CurrentGameState = GameState.Playing; 
                    }
                    femaleButton.Update(mouse);
                    if (maleButton.IsClicked == true)
                    {
                        this.IsMaleClicked = true;
                        this.CurrentGameState = GameState.Playing;
                    }
                    maleButton.Update(mouse);
                    break;
                   
            }
        }

        public void Draw(Game1 g, SpriteBatch sb)
        {
            sb.Begin();
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    sb.Draw(g.Content.Load<Texture2D>("Buttons\\secondBG"), new Rectangle(0, 0, screenW, screenH), Color.White);
                    mainButton.Draw(sb);
                    break;
                case GameState.Options:
                    sb.Draw(g.Content.Load<Texture2D>("Buttons\\OptionsMenu"), new Rectangle(0, 0, screenW, screenH), Color.White);
                    femaleButton.Draw(sb);
                    maleButton.Draw(sb);
                    break;
                case GameState.GameOver:
                    sb.Draw(g.Content.Load<Texture2D>("youDead"), new Rectangle(0, 0, screenW, screenH), Color.White);
                    break;
                    case GameState.Win:
                    sb.Draw(g.Content.Load<Texture2D>("GameOver"), new Rectangle(0, 0, screenW, screenH), Color.White);
                    break;
                    
            }

            sb.End();
        }

        public void ChangeGameState()
        {
            this.CurrentGameState = GameState.GameOver;
        }

        public void ChangeGameStateWin()
        {
            this.CurrentGameState = GameState.Win;
        }
    }
}
