using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace TeamGamorr.Bars
{
    public class ExpirienceBar : Bars
    {
        private const int DefaultPositionX = 90;
        private const int DefaultPositionY = 80;
        private const int DefaultSize = 20;

        public ExpirienceBar(ContentManager Content, string texture) 
            : base(Content, texture)
        {
        }

        
        public override void Update(int value)
        {
            this.Rectangle = new Rectangle(DefaultPositionX, DefaultPositionY, value, DefaultSize);
        }
    }
}
