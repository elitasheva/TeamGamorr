using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using TeamGamorr.Interfaces;

namespace TeamGamorr.Bars
{
    public abstract class Bars  : IBars
    {
        protected Texture2D texture;
        private Rectangle rectangle;
        private Vector2 position;

        protected Bars(ContentManager Content,string texture)
        {
            this.texture = Content.Load<Texture2D>(texture);
        }

        public Rectangle Rectangle { get; set; }
        public Vector2 Position { get; set; }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Rectangle, Color.White);
        }  

        public abstract void Update(int value);
    }
}
