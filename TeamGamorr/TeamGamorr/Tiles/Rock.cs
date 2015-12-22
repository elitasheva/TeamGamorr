using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WindowsGame1.Interfaces;
using TeamGamorr;

namespace WindowsGame1.Tiles
{
    class Rock : Tile, IDrawableObject, ITileCollidable
    {
        private string pos;
        public Rock(int x, int y, string pos)
            :base(x, y)
        {
            this.pos = pos;
        }

        public Rectangle CollisionBox
        {
            get
            {
                return this.collisionBox;
            }
            set { this.collisionBox = value; }
        }

        public override void draw(SpriteBatch sb)
        {
            sb.Draw(this.texture, this.position, Color.White);
        }

        public override void loadContent(GraphicsDevice gd)
        {
            if (pos == "SIDE")
            {
                this.texture = GameState.SideWall;
            }
            if (pos == "DOWN")
            {
                this.texture = GameState.UpDownWall;
            }
        }

        public override void unloadContent()
        {
            this.texture.Dispose();
        }

        public override void update()
        {
            this.position.X = collisionBox.X;
            this.position.Y = collisionBox.Y;

        }
    }
}
