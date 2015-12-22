using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace TeamGamorr.Characters
{
    public class MaleCharacter : GoodCharacter
    {
        private const string NameMaleCharacter = "Aias";
        private const int DefaultHeathMaleCharacter = 150;
        private const string GenderMaleCharacter = "male";
        private const int DefaultMoneyMaleCharacter = 500;
        private const int DefaultExpirienceMaleCharacter = 150;
        private const int DefaultShieldMaleCharacter = 100;

        public MaleCharacter(ContentManager Content, string rightWalk, string leftWalk,
            string upWalk, string downWalk, float frameSpeed, int numOfFrames, bool looping)
            :base(NameMaleCharacter, DefaultHeathMaleCharacter, GenderMaleCharacter, DefaultMoneyMaleCharacter, 
                 DefaultExpirienceMaleCharacter, DefaultShieldMaleCharacter,Content, rightWalk,leftWalk,upWalk,downWalk,
                 frameSpeed,numOfFrames,looping)
        {
           
        }

       
    }
}
