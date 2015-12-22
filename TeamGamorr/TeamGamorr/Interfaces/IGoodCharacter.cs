using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using TeamGamorr.Characters;
using TeamGamorr.Items;

namespace TeamGamorr.Interfaces
{
    public interface IGoodCharacter
    {
        string Gender { get;  }
        int Money { get; set; }
        int Expirience { get; set; }
        int Shield { get; set; }
        Rectangle Collision { get; set; }
        bool IsDead { get; set; }
        bool IsActive { get; set; }

        void AddToInventory(IItem item);
        void RemoveFromInventory(IItem item);
        void ChangeExpirience(int expirience);
        void RespondToCollision(Character type);

    }
}
