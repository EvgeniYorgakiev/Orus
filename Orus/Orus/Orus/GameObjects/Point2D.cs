using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.GameObjects
{
    public struct Point2D
    {
        private float x;
        private float y;

        public Point2D(float x, float y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public static Point2D Zero()
        {
            return new Point2D(0, 0);
        }
    }
}
