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
    public class EmptyCollisionBox 
    {
        private const int DefaultXCoordinate = 1130;
        private const int DefaultYCoordinate = 80;
        private const int DefaultSizeOfRectangle = 50;
        private Rectangle collision;
        private Vector2 position;
        
        public EmptyCollisionBox() 
            
        {
            this.Collision = new Rectangle(DefaultXCoordinate, DefaultYCoordinate,
                DefaultSizeOfRectangle, DefaultSizeOfRectangle);
            this.Position = new Vector2(DefaultXCoordinate, DefaultYCoordinate);
        }

        public Rectangle Collision { get; set; }
        public Vector2 Position { get; set; }
    }
}
