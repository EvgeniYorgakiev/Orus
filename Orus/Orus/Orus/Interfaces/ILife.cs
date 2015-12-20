using Orus.Sprites;
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
        int FireResistance { get; set; }
        int LightingResistance { get; set; }
        int ArcaneResistance { get; set; }
        int IceResistance { get; set; }
    }
}
