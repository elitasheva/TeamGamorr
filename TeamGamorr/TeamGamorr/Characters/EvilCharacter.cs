using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TeamGamorr.Characters
{
    using System;
    using Interfaces;

    public abstract class EvilCharacter :Character
    {

        private readonly Random rnd = new Random();
        private const int ParamExpirience = 100;
        private const int ParamRandomExpirience = 30;
        
        protected EvilCharacter(string name, int health, 
            ContentManager Content, string rightWalk, string leftWalk,
            string upWalk, string downWalk, float frameSpeed, int numOfFrames, bool looping) 
            :base(name,health,Content,rightWalk,leftWalk,upWalk,downWalk,frameSpeed,numOfFrames,looping)
        {
           
        }
         
        public override void RespondToCollision(Character good)
        {
            GoodCharacter goodChar = (GoodCharacter)good;
            if (goodChar.Expirience < ParamExpirience)
            {
                int damage = rnd.Next(ParamRandomExpirience, 2*ParamRandomExpirience);
                if (this.Health-damage <= 0)
                {
                    this.Health = 0;
                    this.IsDead = true;
                }
                this.Health -= damage;
            }
            else if (goodChar.Expirience< 2*ParamExpirience)
            {
                int damage = rnd.Next(2*ParamRandomExpirience, 3*ParamRandomExpirience);
                if (this.Health - damage <= 0)
                {
                    this.Health = 0;
                    this.IsDead = true;
                }
                this.Health -= damage;
            }
            else
            {
                int damage = rnd.Next(3*ParamRandomExpirience, 4*ParamRandomExpirience);
                if (this.Health - damage <= 0)
                {
                    this.Health = 0;
                    this.IsDead = true;
                }
                this.Health -= damage;
            }
        }



    }
}
