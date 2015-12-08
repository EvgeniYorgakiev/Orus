using Microsoft.Xna.Framework;

namespace Orus.GameObjects
{
    public abstract class GameObject
    {
        private Point2D position;

        protected GameObject(Point2D position)
        {
            this.Position = position;
        }

        public virtual Point2D Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
    }
}
