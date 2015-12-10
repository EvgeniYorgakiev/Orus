using Microsoft.Xna.Framework;

namespace Orus.GameObjects
{
    public abstract class GameObject
    {
        private string name;
        private Point2D position;

        protected GameObject(string name, Point2D position)
        {
            this.Name = name;
            this.Position = position;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public virtual Point2D Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }
    }
}
