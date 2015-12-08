using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Orus.Animations;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;

namespace Orus.GameObjects.Enemies.NormalEnemies
{
    class Zombie : Enemy
    {
        public Zombie(Point2D position, ContentManager Content)
            : base(position,
                  new Rectangle((int)position.X - Constant.ZombieWidth / 2, (int)position.Y - Constant.DefaultHeighForEverything / 2,
                      Constant.ZombieWidth, Constant.DefaultHeighForEverything), Constant.ZombieDefaultMoveSpeed, 
                  Constant.ZombieDefaultHealth, Constant.ZombieDefaultArmor, Constant.ZombieDefaultFireResistance,
                  Constant.ZombieDefaultLightingResistance, Constant.ZombieDefaultArcaneResistance, Constant.ZombieDefaultIceResistance,
                  Constant.ZombieDefaultAttackDamage, Constant.ZombieAttackRange)
        {
            this.IddleAnimationPath = "Sprites\\Zombie\\Zombie iddle";
            this.MoveAnimationPath = "Sprites\\Zombie\\Zombie move";
            this.AttackAnimationPath = "Sprites\\Zombie\\Zombie attack";
            this.DeathAnimationPath = "Sprites\\Zombie\\Zombie death";
            this.IddleAnimation = new FrameAnimation(
                Content.Load<Texture2D>(this.IddleAnimationPath),
                Constant.ZombieIddleFramesNumber,
                this);
            this.IddleAnimation.IsActive = true;
            this.MoveAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(this.MoveAnimationPath),
                 Constant.ZombieMoveFramesNumber,
                 this);
            this.AttackAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(this.AttackAnimationPath),
                 Constant.ZombieAttackFramesNumber,
                 this);
            this.AttackAnimation.IsLoop = false;
            this.DeathAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(this.DeathAnimationPath),
                 Constant.ZombieDeathFramesNumber,
                 this);
            this.DeathAnimation.IsLoop = false;
        }
    }
}
