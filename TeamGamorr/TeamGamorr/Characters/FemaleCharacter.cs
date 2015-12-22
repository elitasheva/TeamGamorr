using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TeamGamorr.Characters
{
    public class FemaleCharacter:GoodCharacter
    {
        private const string NameFemaleCharacter = "Sariandi";
        private const int DefaultHeathFemaleCharacter = 150;
        private const string GenderFemaleCharacter = "female";
        private const int DefaultMoneyFemaleCharacter = 500;
        private const int DefaultExpirienceFemaleCharacter = 100;
        private const int DefaultShieldFemaleCharacter = 150;

        public FemaleCharacter(ContentManager Content, string rightWalk, string leftWalk,
            string upWalk, string downWalk, float frameSpeed, int numOfFrames, bool looping)
            :base(NameFemaleCharacter, DefaultHeathFemaleCharacter,GenderFemaleCharacter, 
                 DefaultMoneyFemaleCharacter, DefaultExpirienceFemaleCharacter, DefaultShieldFemaleCharacter,Content, rightWalk,leftWalk,upWalk,downWalk,
                 frameSpeed,numOfFrames,looping)
        {
            
        }

       
    }
}



