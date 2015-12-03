using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Orus.Animations;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;

namespace Orus.GameObjects.Enemies.NormalEnemies
{
    class Zombie : Enemy
    {
        public Zombie(Vector2 position, ContentManager Content)
            : base(position,
                  new Rectangle((int)position.X - Constant.ZombieWidth / 2, (int)position.Y - Constant.DefaultHeighForEverything / 2,
                      Constant.ZombieWidth, Constant.DefaultHeighForEverything),
                  Constant.ZombieDefaultHealth, Constant.ZombieDefaultArmor, Constant.ZombieDefaultFireResistance,
                  Constant.ZombieDefaultLightingResistance, Constant.ZombieDefaultArcaneResistance, Constant.ZombieDefaultIceResistance,
                  Constant.ZombieDefaultAttackDamage)
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
