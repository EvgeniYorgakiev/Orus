using Microsoft.Xna.Framework;
using Orus.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.Interfaces
{
    public interface ICollide
    {
        Rectangle BoundingBox { get; set; }

        bool Collides(AnimatedGameObject colliders, bool isMovingRight);
    }
}
