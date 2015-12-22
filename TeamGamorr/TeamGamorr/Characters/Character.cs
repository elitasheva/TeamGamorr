using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace TeamGamorr.Characters
{
    using Interfaces;

    public abstract class Character : IDrawable,ICollidable
    {
        private string name;
        private int health;

        private Rectangle sourceRect;
        protected Vector2 position;
        protected Rectangle collision;
        protected Rectangle collBoxLR;
        protected Rectangle collBoxUD;

        private float elapsed;
        private float frameTime;
        private int numOfFrames;
        private int currentFrame;
        protected int frameWidth;
        protected int frameHeight;
        protected bool looping;
        protected Texture2D rightWalk;
        protected Texture2D leftWalk;
        protected Texture2D upWalk;
        protected Texture2D downWalk;
        protected Texture2D currentAnim;
        private bool isDead;
               
        protected Character(string name, int health, ContentManager Content, string rightWalk, string leftWalk,
            string upWalk, string downWalk, float frameSpeed, int numOfFrames, bool looping)
        {
            this.Name = name;
            this.Health = health;
            this.frameTime = frameSpeed;
            this.numOfFrames = numOfFrames;
            this.looping = looping;
            this.rightWalk = Content.Load<Texture2D>(rightWalk);
            this.leftWalk = Content.Load<Texture2D>(leftWalk);
            this.upWalk = Content.Load<Texture2D>(upWalk);
            this.downWalk = Content.Load<Texture2D>(downWalk);
            this.frameWidth = (this.rightWalk.Width / numOfFrames);
            this.frameHeight = this.rightWalk.Height;
            this.currentAnim = this.rightWalk;
            this.Position = position;
            this.position.X = 100;
            this.position.Y = 300;

        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name cannot be empty.");
                }
                this.name = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                if (value<0)
                {
                    this.health = 0;
                }
                else if (value>350)
                {
                    this.health = 350;
                }
                else
                {
                    this.health = value;
                }
                
            }
        }
        public bool IsDead { get; set; }
        public Rectangle SourceRect { get; set; }
        public Rectangle Collision
        {
            get
            {
                return this.collision;
            }
            set
            {
                this.collision = value;
            }

        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if (value.X < 0 || value.Y < 0)
                {
                    throw new ArgumentOutOfRangeException("Position cannot be with negative parameters.");
                }
                this.position = value;
            }
        }

        public Rectangle CollBoxLR
        {
            get { return this.collBoxLR; }
            set { this.collBoxLR = value; }
        }

        public Rectangle CollBoxUD
        {
            get { return this.collBoxUD; }
            set { this.collBoxUD = value; }
        }
       


        public virtual void PlayAnimation(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            this.SourceRect = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);

            if (elapsed >= frameTime)
            {
                if (currentFrame >= numOfFrames - 1)
                {
                    if (looping)
                    {
                        currentFrame = 0;
                    }
                }
                else
                {
                    currentFrame++;
                }
                elapsed = 0;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.currentAnim, this.Position, this.SourceRect,
                Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);

        }

        public abstract void RespondToCollision(Character type);
       
    }
}
