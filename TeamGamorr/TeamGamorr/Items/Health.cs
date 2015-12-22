using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamGamorr.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TeamGamorr.Items
{
    public class Health : Item
    {
       
        private const int DefenceEffectDefault = 0;
        private const int ExpirienceEffectDefault = 0;
       
        public Health(ContentManager Content, string texture, int healthEffect)
            : base(Content, texture, healthEffect, DefenceEffectDefault, ExpirienceEffectDefault)
        {
            this.HealthEffect = healthEffect;
            
        }  
    }
}

