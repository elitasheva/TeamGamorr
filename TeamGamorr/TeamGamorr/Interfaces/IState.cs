using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamGamorr.Interfaces
{
    public interface IState
    {
        void Initialize(Game1 g);
        void LoadContent(Game1 g);
        void UnloadContent();
        void Update(Game1 g, GameTime gt);
        void Draw(Game1 g, SpriteBatch sb);
       
    }
}
