using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WindowsGame1.Interfaces;
using System.Text;
using TeamGamorr;

namespace WindowsGame1.Tiles
{
    class Dirt : Tile, IDrawableObject
    {
        
        public Dirt(int x, int y)
            :base(x,y)
        {
        }
        public override void draw(SpriteBatch sb)
        {
            sb.Draw(this.texture, this.position, Color.White);
        }

        public override void loadContent(GraphicsDevice gd)
        {
            this.texture = GameState.dirtTile;
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
