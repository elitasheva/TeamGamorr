using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace TeamGamorr.Interfaces
{
    public interface IBars
    {

        Rectangle Rectangle { get; set; }
        Vector2 Position { get; set; }

        void Draw(SpriteBatch spriteBatch);
        void Update(int value);
    }
}
