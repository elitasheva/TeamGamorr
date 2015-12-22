using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WindowsGame1.Interfaces;

namespace WindowsGame1.Tiles
{
    public abstract class Tile : IDrawableObject
    {
        protected Tile(int x, int y)
        {
            position = new Vector2(x, y);
            this.collisionBox = new Rectangle(x, y, SIZE, SIZE);

        }
        public const int SIZE = 64;
        protected int x;
        protected int y;
        protected Texture2D texture;
        public Rectangle collisionBox;
        public Vector2 position;

        public int X {
            get { return this.x; }
            set { this.x = value; } 
        }
        public int Y {
            get { return this.y; }
            set { this.y = value; }
        }            
        public abstract void loadContent(GraphicsDevice gd);

        public abstract void unloadContent();

        public abstract void update();

        public abstract void draw(SpriteBatch sb);

    }
}
