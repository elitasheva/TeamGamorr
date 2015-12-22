using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using WindowsGame1;
using WindowsGame1.Interfaces;
using WindowsGame1.Tiles;
using Microsoft.Xna.Framework;
using TeamGamorr.Characters;
using TeamGamorr.Bars;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TeamGamorr.Interfaces;
using TeamGamorr.Items;

namespace TeamGamorr
{
    class GameState : IState
    {
        private const int DefaultSizeOfRectangle = 20;
        private const int DefaultHealth = 50;
        private const int DefaultShield = 50;
        private const int DefaultExpirience = 50;
        private const int FontPositionX = 5;
        private const int FontPositionHealthY = 19;
        private const int FontPositionShieldY = 49;
        private const int FontPositionExpirienceY = 79;

        private FemaleCharacter sariandi;
        private MaleCharacter aias;
        private Death death;
        private Luggage luggage;
        private Dragon dragon;
        private HealthBar healthBar;
        private ShieldBar shieldBar;
        private ExpirienceBar expirienceBar;
        private Health health;
        private Shield shield;
        private Expirience expirience;
        private readonly Random rnd = new Random();
        private List<GoodCharacter> goodCharacters = new List<GoodCharacter>();
        private List<EvilCharacter> evilCharacters = new List<EvilCharacter>();
        private List<Item> items = new List<Item>();
        public static Texture2D SideWall;
        public static Texture2D grassTile;
        public static Texture2D dirtTile;
        public static Texture2D UpDownWall;
        private Map map;
        private PlayerCamera camera;
        private EmptyCollisionBox emptyCollisionBox;
        private SpriteFont spriteFont;
       
        public GameState()
        {
            map = new Map();
        }

        public bool IsFemaleActive { get; set; }
        public bool IsMaleActive { get; set; }
        public bool IsCharacterDead { get; set; }
        public bool IsWin { get; set; }
       

        public void Initialize(Game1 g)
        {
            camera = new PlayerCamera(g.GraphicsDevice.Viewport);
        }


        public void LoadContent(Game1 g)
        {
            spriteFont = g.Content.Load<SpriteFont>("SpriteFont");
            LoadTextures(g);

            sariandi = new FemaleCharacter(g.Content, "GoodCharacter\\femaleRight", "GoodCharacter\\femaleLeft",
            "GoodCharacter\\femaleUp", "GoodCharacter\\femaleDown", 200f, 4, true);
            aias = new MaleCharacter(g.Content, "GoodCharacter\\maleRight", "GoodCharacter\\maleLeft",
                "GoodCharacter\\maleUp", "GoodCharacter\\maleDown", 200f, 4, true);

            health = new Health(g.Content, "Items\\Health", DefaultHealth);

            death = new Death(g.Content, "EvilCharacter\\deathRight", "EvilCharacter\\deathLeft",
                "EvilCharacter\\deathUp", "EvilCharacter\\deathDown", 200f, 4, true);
            luggage = new Luggage(g.Content, "EvilCharacter\\luggageRight", "EvilCharacter\\luggageLeft",
                "EvilCharacter\\luggageUp", "EvilCharacter\\luggageDown", 200f, 4, true);
            dragon = new Dragon(g.Content, "EvilCharacter\\dragonRight", "EvilCharacter\\dragonLeft",
                "EvilCharacter\\dragonUp", "EvilCharacter\\dragonDown", 200f, 4, true);
            emptyCollisionBox = new EmptyCollisionBox();

            goodCharacters.Add(aias);
            goodCharacters.Add(sariandi);

            shield = new Shield(g.Content, "Items\\Shield", DefaultShield);

            evilCharacters.Add(death);
            evilCharacters.Add(luggage);
            evilCharacters.Add(dragon);

            healthBar = new HealthBar(g.Content, "Bars\\bloodbar");
            shieldBar = new ShieldBar(g.Content, "Bars\\shieldbar");
            expirienceBar = new ExpirienceBar(g.Content, "Bars\\expiriencebar");

            expirience = new Expirience(g.Content, "Items\\Axe", DefaultExpirience);
            
            items.Add(health);
            items.Add(shield);
            items.Add(expirience);
            map.loadContent(g.GraphicsDevice);
           
        }

        public void UnloadContent()
        {
            map.unloadContent();
        }

        public void Update(Game1 g, GameTime gameTime)
        {
          
            if (IsFemaleActive)
            {
                sariandi.IsActive = true;
            }
            if (IsMaleActive)
            {
                aias.IsActive = true;
            }
           
            var activeCharacter = goodCharacters.FirstOrDefault(a => a.IsActive);
            activeCharacter.Collision = new Rectangle((int)activeCharacter.Position.X, (int)activeCharacter.Position.Y,
               DefaultSizeOfRectangle, DefaultSizeOfRectangle);

            healthBar.Update(activeCharacter.Health);
            shieldBar.Update(activeCharacter.Shield);
            expirienceBar.Update(activeCharacter.Expirience);

            if (death.IsDead)
            {
                death.Collision = Rectangle.Empty;
            }

            if (dragon.IsDead)
            {
                dragon.Collision = Rectangle.Empty;
            }

            if (emptyCollisionBox.Collision.Intersects(activeCharacter.Collision))
            {
                this.IsWin= true;
            }


            foreach (EvilCharacter evil in evilCharacters)
            {
                if (evil.Collision.Intersects(activeCharacter.Collision))
                {
                    if (evil is Luggage)
                    {
                        evil.RespondToCollision(activeCharacter);
                    }
                    else
                    {
                        while (!activeCharacter.IsDead && !evil.IsDead)
                        {
                            activeCharacter.RespondToCollision(evil);
                            evil.RespondToCollision(activeCharacter);
                        }
                        if (activeCharacter.IsDead)
                        {
                            this.IsCharacterDead = true;
                           
                        }

                        if (evil.IsDead)
                        {
                            activeCharacter.ChangeExpirience(DefaultExpirience);
                        }
                    }

                }

            }

            foreach (Item item in this.items)
            {
                if (item.Collision.Intersects(activeCharacter.Collision))
                {
                    activeCharacter.AddToInventory(item);
                    item.ChangePositionItem();

                }
            }

            foreach (Item item in this.items)
            {
                foreach (Tile tile in map.LisTiles)
                {
                    if (item.Collision.Intersects(tile.collisionBox))
                    {
                         item.IsItemOnTile = true;
                         item.ChangePositionItem();
                    } 
                }
            }

            foreach (Tile tile in map.LisTiles)
            {
                if (luggage.Collision.Intersects(tile.collisionBox))
                {
                    luggage.ChangePositionLuggage();
                }
            }



            if (activeCharacter.IsActive)
            {
                camera.update(gameTime, activeCharacter);
            }


            activeCharacter.Move(gameTime);
            death.PlayAnimation(gameTime);
            luggage.PlayAnimation(gameTime);
            dragon.PlayAnimation(gameTime);
           
        }

        public void Draw(Game1 g, SpriteBatch sb)
        {
            
            sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);
            map.draw(sb);
           
            if (!sariandi.IsDead && sariandi.IsActive)
            {
                sariandi.Draw(sb);
            }
                                                             
            if (!aias.IsDead && aias.IsActive)
            {
                aias.Draw(sb);
            }

            if (!death.IsDead)
            {
                death.Draw(sb);
            }

            if (!luggage.IsDead)
            {
                luggage.Draw(sb);
            }
            if (!dragon.IsDead)
            {
                dragon.Draw(sb);
            }

            if (!health.IsInvisible)
            {
                health.Draw(sb);
            }

            if (!shield.IsInvisible)
            {
                shield.Draw(sb);
            }

            if (!expirience.IsInvisible)
            {
                expirience.Draw(sb);
            }
              
            sb.End();

            sb.Begin();
            sb.DrawString(spriteFont, "Health", new Vector2(FontPositionX, FontPositionHealthY), Color.DarkBlue,0f, 
                new Vector2(0, 0), 0.75f, SpriteEffects.None, 1f);
            healthBar.Draw(sb);
            sb.DrawString(spriteFont, "Shield", new Vector2(FontPositionX, FontPositionShieldY), Color.DarkBlue,0f, 
                new Vector2(0, 0), 0.75f, SpriteEffects.None, 1f);
            shieldBar.Draw(sb);
            sb.DrawString(spriteFont,"Expirience",new Vector2(FontPositionX, FontPositionExpirienceY),Color.DarkBlue,0f,
                new Vector2(0,0),0.75f,SpriteEffects.None, 1f);
            expirienceBar.Draw(sb);
            sb.End();
        }

        private void LoadTextures(Game1 g)
        {
            SideWall = g.Content.Load<Texture2D>("Tiles\\wall");
            grassTile = g.Content.Load<Texture2D>("Tiles\\floor");
            UpDownWall = g.Content.Load<Texture2D>("Tiles\\wallDown");

        }

        private void UnloadTextures()
        {
            SideWall.Dispose();
            grassTile.Dispose();
            dirtTile.Dispose();
        }
    }
}
