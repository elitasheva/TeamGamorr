using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TeamGamorr.Characters
{
    public class Luggage : EvilCharacter
    {
        private const string NameDefault = "Luggage";
        private const int healthDefault = 90;
        private const int DefaultXCoordinate = 915;
        private const int DefaultYCoordinate = 260;
        private const int DefaultSizeOfRectangle = 50;
        private readonly Random rnd = new Random();
        private const int RandomExpirienceChange = 50;
        private const int RandomChangePosition = 100;
        private int counter = 0;


        public Luggage(ContentManager Content, string rightWalk, string leftWalk,
            string upWalk, string downWalk, float frameSpeed, int numOfFrames, bool looping)
            :base(NameDefault, healthDefault, Content, rightWalk, leftWalk, upWalk, downWalk, frameSpeed, numOfFrames, looping)
        {
             this.Collision = new Rectangle(DefaultXCoordinate, DefaultYCoordinate, 
                 DefaultSizeOfRectangle, DefaultSizeOfRectangle);
            this.Position = new Vector2(DefaultXCoordinate, DefaultYCoordinate);
        }
            
        public override void RespondToCollision(Character good)
        {

            GoodCharacter goodChar = (GoodCharacter)good;

            if (goodChar.Inventory.Count>0)
            {
                var item = goodChar.Inventory[rnd.Next(0,goodChar.Inventory.Count)];
                goodChar.RemoveFromInventory(item);
            }
            else
            {
                goodChar.ChangeExpirience(-RandomExpirienceChange);
                ChangePositionLuggage();
            }
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.leftWalk, this.Position, this.SourceRect, 
                Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);

        }

        public void ChangePositionLuggage()
        {
            counter++;
            if (counter >= 1 && counter < 4 )
            {
                int x = rnd.Next(RandomChangePosition, 3 * RandomChangePosition);
                int y = rnd.Next(RandomChangePosition, 3 * RandomChangePosition);
                this.Position = new Vector2(x, y);
                this.Collision = new Rectangle(x, y, DefaultSizeOfRectangle, DefaultSizeOfRectangle);
            }
            else
            {
                this.Collision = Rectangle.Empty;
                this.IsDead = true;
            }
          
        }


    }
}
