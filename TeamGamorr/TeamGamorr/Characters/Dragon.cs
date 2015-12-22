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
    public class Dragon:EvilCharacter
    {
        private const string NameDefault = "Dragon";
        private const int healthDefault = 200;
        private const int DefaultXCoordinate = 1130;
        private const int DefaultYCoordinate = 150;
        private const int DefaultSizeOfRectangle = 50;

        public Dragon(ContentManager Content, string rightWalk, string leftWalk,
            string upWalk, string downWalk, float frameSpeed, int numOfFrames, bool looping)
            :base(NameDefault, healthDefault, Content, rightWalk, leftWalk, upWalk, downWalk, frameSpeed, numOfFrames, looping)
        {
            this.Collision = new Rectangle(DefaultXCoordinate, DefaultYCoordinate, 
                DefaultSizeOfRectangle, DefaultSizeOfRectangle);
            this.Position = new Vector2(DefaultXCoordinate, DefaultYCoordinate);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.leftWalk, this.Position, this.SourceRect, 
                Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);

        }
    }
}
