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
    public interface IButton
    {
        Vector2 Position { get; set; }
        Rectangle Rectangle { get; set; }
        void Update(MouseState mouse);
        void SetPosition(Vector2 newPosition);
        void Draw(SpriteBatch spriteBatch);

    }
}
