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
using TeamGamorr.Interfaces;
using WindowsGame1.Tiles;
using TeamGamorr.Characters;

namespace WindowsGame1
{
    class Collision
    {
        public void collision(GoodCharacter player)
        {
            collisionRight(player);
            collisionLeft(player);
            collisionUp(player);
            collisionDown(player);
            
        }
        public static void collisionRight(GoodCharacter player)
        {
            foreach (Rock tile in Map.collidables)
            {
                if (player.CollBoxLR.Intersects(tile.CollisionBox) && tile.CollisionBox.X > player.Collision.X) {
                    player.Speed = tile.CollisionBox.X - (player.Collision.X + player.Collision.Width);           
                }
            }
        }
        public static void collisionLeft(GoodCharacter player)
        {
            foreach (Rock tile in Map.collidables)
            {
                if (player.CollBoxLR.Intersects(tile.CollisionBox) && tile.CollisionBox.X < player.Collision.X)
                {
                    //player.Speed =  tile.CollisionBox.X + tile.CollisionBox.Width - player.CollisionBox.X;
                    player.Speed = player.Collision.X - (tile.CollisionBox.X  + tile.CollisionBox.Width);
                }
            }
        }
        public static void collisionUp(GoodCharacter player)
        {
            foreach (Rock tile in Map.collidables)
            {
                if (player.CollBoxUD.Intersects(tile.CollisionBox) && tile.CollisionBox.Y < player.Collision.Y)
                {
                    player.Speed = player.Collision.Y   - (tile.CollisionBox.Y + tile.collisionBox.Height);
                }
            }
        }
        public static void collisionDown(GoodCharacter player)
        {
            foreach (Rock tile in Map.collidables)
            {
                if (player.CollBoxUD.Intersects(tile.CollisionBox) && tile.CollisionBox.Y > player.Collision.Y)
                {
                    //player.Speed =  player.CollisionBox.Y + player.CollisionBox.Height - tile.CollisionBox.Y;
                   // player.Speed = tile.CollisionBox.Y - tile.CollisionBox.Height /2  - player.CollisionBox.Y ;
                    player.Speed = tile.collisionBox.Y - (player.Collision.Y + player.Collision.Height);
                }
            }
        }
    }
}
