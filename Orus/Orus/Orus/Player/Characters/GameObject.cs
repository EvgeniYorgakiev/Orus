using Microsoft.Xna.Framework;

namespace Orus.Player.Characters
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
            get { return position; }
            set { position = value; }
        }
    }
}
