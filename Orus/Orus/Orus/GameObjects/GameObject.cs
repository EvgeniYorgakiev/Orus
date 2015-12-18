using Microsoft.Xna.Framework;
using Orus.Constants;
using Orus.Exceptions;

namespace Orus.GameObjects
{
    public abstract class GameObject
    {
        private string name;
        private Point2D position;

        protected GameObject()
        {

        }

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
                if(value.Length < Constant.MinimumNameLength)
                {
                    throw new InvalidName("Invalid username. It must be atleast " + Constant.MinimumNameLength + " letters long");
                }
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
