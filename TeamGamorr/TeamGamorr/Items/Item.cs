using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using TeamGamorr.Interfaces;

namespace TeamGamorr.Items
{
    public abstract class Item : IItem
    {
        private const int DefaultSizeOfRectangle = 30;
        private const int RandomChangeXZone1Start = 50;
        private const int RandomChangeXZone1End = 500;
        private const int RandomChangeYZone1Start = 50;
        private const int RandomChangeYZone1End = 400;
        private const int RandomChangeXZone2Start = 500;
        private const int RandomChangeXZone2End = 900;
        private const int RandomChangeYZone2Start = 400;
        private const int RandomChangeYZone2End = 700;
        private int x;
        private int y;
        protected Texture2D texture;
        private Rectangle rectangle;
        private Vector2 position;
        private Rectangle collision;
        private static readonly Random rnd = new Random();
        private int counter;

        protected Item(ContentManager Content, string texture, int healthEffect, int defenseEffect, int expirienceEffect)
        {
            this.HealthEffect = healthEffect;
            this.DefenseEffect = defenseEffect;
            this.ExpirienceEffect = expirienceEffect;
            this.texture = Content.Load<Texture2D>(texture);
            this.x = rnd.Next(RandomChangeXZone1Start, RandomChangeXZone1End);
            this.y = rnd.Next(RandomChangeYZone1Start, RandomChangeYZone1End);
            this.Rectangle = new Rectangle(x, y, DefaultSizeOfRectangle, DefaultSizeOfRectangle);
            this.Position = new Vector2(x, y);
            this.Collision = new Rectangle(x, y, DefaultSizeOfRectangle, DefaultSizeOfRectangle);

        }

        public int HealthEffect { get; set; }
        public int DefenseEffect { get; set; }
        public int ExpirienceEffect { get; set; }
        public bool IsInvisible { get; set; }
        public bool IsItemOnTile { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return this.rectangle;
            }
            set
            {
                this.rectangle = value;
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
                this.position = value;
            }
        }

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

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Rectangle, Color.White);

        }

        public void ChangePositionItem()
        {

            if (!this.IsItemOnTile)
            {
                counter++;


            }
            else
            {
                this.IsItemOnTile = false;
            }

            if (counter < 3)
            {
                int x = rnd.Next(RandomChangeXZone1Start, RandomChangeXZone1End);
                int y = rnd.Next(RandomChangeYZone1Start, RandomChangeYZone1End);
                this.Position = new Vector2(x, y);
                this.Rectangle = new Rectangle(x, y, DefaultSizeOfRectangle, DefaultSizeOfRectangle);
                this.Collision = new Rectangle(x, y, DefaultSizeOfRectangle, DefaultSizeOfRectangle);

            }

            else if (counter > 3 && counter < 6)
            {
                int x = rnd.Next(RandomChangeXZone2Start, RandomChangeXZone2End);
                int y = rnd.Next(RandomChangeYZone2Start, RandomChangeYZone2End);
                this.Position = new Vector2(x, y);
                this.Rectangle = new Rectangle(x, y, DefaultSizeOfRectangle, DefaultSizeOfRectangle);
                this.Collision = new Rectangle(x, y, DefaultSizeOfRectangle, DefaultSizeOfRectangle);

            }
            else
            {
                this.Rectangle = Rectangle.Empty;
                this.IsInvisible = true;

            }



        }
    }
}
