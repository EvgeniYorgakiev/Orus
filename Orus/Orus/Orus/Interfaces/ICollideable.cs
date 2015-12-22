using Microsoft.Xna.Framework;
using Orus.GameObjects;
using Orus.GameObjects.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.Interfaces
{
    public interface ICollideable
    {
        Point2D Position { get; set; }

        Rectangle2D BoundingBox { get; set; }

        bool Collides(ICollideable collider, int additionalOffset = 0);
    }
}
