using Orus.GameObjects.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.Interfaces
{
    interface ILife
    {
        int Health { get; set; }
        Sprite Bar { get; set; }
        int Armor { get; set; }
        double ArmorAsPercentage { get;}
        double FireResistance { get; set; }
        double LightingResistance { get; set; }
        double ArcaneResistance { get; set; }
        double IceResistance { get; set; }
    }
}
