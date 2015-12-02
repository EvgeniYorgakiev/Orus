using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Orus.Animations;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;

namespace Orus.GameObjects.Enemies.NormalEnemies
{
    class Zombie : Enemy
    {
        public Zombie(Vector2 position, ContentManager Content) : base(position)
        {
            this.IddleAnimationPath = "Sprites\\Zombie\\Zombie iddle";
            this.IddleAnimation = new FrameAnimation(
                Content.Load<Texture2D>(this.IddleAnimationPath),
                Constant.ZombieIddleFramesNumber,
                this);
            this.IddleAnimation.IsActive = true;
        }
    }
}
