using Microsoft.Xna.Framework;
using Orus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.GameObjects
{
    public class ColliderObjects : GameObject, ICollideable
    {
        private Rectangle boundingBox;

        public ColliderObjects(string name, Point2D position)
            : base(name, position)
        {

        }

        public override Point2D Position
        {
            get
            {
                return base.Position;
            }

            set
            {
                this.BoundingBox = new Rectangle((int)value.X, (int)value.Y, this.BoundingBox.Width, this.BoundingBox.Height);
                base.Position = value;
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return this.boundingBox;
            }
            set
            {
                this.boundingBox = value;
            }
        }

        public bool Collides(ICollideable collider, int additionalOffset = 0)
        {
            if (this == collider)
            {
                return false;
            }
            if(this.BoundingBox.X < collider.BoundingBox.X)
            {
                return this.BoundingBox.X + this.BoundingBox.Width + additionalOffset >= collider.BoundingBox.X;
            }
            else
            {
                return collider.BoundingBox.X + collider.BoundingBox.Width + additionalOffset >= this.BoundingBox.X;
            }
        }
    }
}
