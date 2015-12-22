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
    class Grass : Tile, IDrawableObject
    {
        public Grass(int x, int y)
            :base(x,y)
        {
            
        }

        public override void loadContent(GraphicsDevice gd)
        {
            this.texture = GameState.grassTile;
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
        public override void draw(SpriteBatch sb)
        {
            sb.Draw(this.texture, this.position, Color.White);
            
        }
    }
}
