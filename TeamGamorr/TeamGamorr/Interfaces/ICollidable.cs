using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TeamGamorr.Characters;

namespace TeamGamorr.Interfaces
{
    public interface ICollidable
    {
        Rectangle Collision { get; set; }
        void RespondToCollision(Character type);
        
    }
}
