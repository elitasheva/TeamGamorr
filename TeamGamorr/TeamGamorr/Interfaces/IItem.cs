using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamGamorr.Interfaces
{
    public interface IItem
    {

        int HealthEffect { get; set; }

        int DefenseEffect { get; set; }

        int ExpirienceEffect { get; set; }

        Rectangle Collision { get; set; }



    }
}
