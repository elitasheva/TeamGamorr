using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TeamGamorr.Items
{
    public class Expirience : Item
    {
       
        private const int DefenceEffectDefault = 0;
        private const int HealthEffectDefault = 0;  

        public Expirience(ContentManager Content, string texture, int expirienceEffect) 
            : base(Content, texture, HealthEffectDefault, DefenceEffectDefault, expirienceEffect)
        {
            this.ExpirienceEffect = expirienceEffect; 
        }
      
    }
}
