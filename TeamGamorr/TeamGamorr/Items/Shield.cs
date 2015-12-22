using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TeamGamorr.Items
{
    public class Shield : Item
    {
        
        private const int DefenceEffectDefault = 0;
        private const int HealthEffectDefault = 0;
      
        public Shield(ContentManager Content, string texture, int defenseEffect) 
            : base(Content, texture, HealthEffectDefault, defenseEffect, DefenceEffectDefault)
        {
            this.DefenseEffect = defenseEffect; 
        }  
    }
}
