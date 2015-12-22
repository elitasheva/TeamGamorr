using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using TeamGamorr.Interfaces;

namespace TeamGamorr.Buttons
{
    public class FemaleButton : Button
    {
        public FemaleButton(Texture2D texture, GraphicsDevice graphics) 
            : base(texture, graphics)
        {
            this.Size = new Vector2(graphics.Viewport.Width / 10, graphics.Viewport.Height / 7.5f);
        }
    }
}
