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
    public class MainButton : Button
    {
        public MainButton(Texture2D texture, GraphicsDevice graphics) 
            : base(texture, graphics)
        {
            
        }
    }
}
