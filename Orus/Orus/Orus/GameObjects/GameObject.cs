using Microsoft.Xna.Framework;

namespace Orus.GameObjects
{
    public abstract class GameObject
    {
        private Vector2 position;

        protected GameObject(Vector2 position)
        {
            this.Position = position;
        }

        public virtual Vector2 Position
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
