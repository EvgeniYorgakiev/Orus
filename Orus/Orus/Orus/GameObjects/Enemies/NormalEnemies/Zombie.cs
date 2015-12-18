using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.Sprites;
using Orus.Sprites.Animations;

namespace Orus.GameObjects.Enemies.NormalEnemies
{
    class Zombie : Enemy
    {
        public Zombie()
        {

        }

        public Zombie(Point2D position, ContentManager Content)
            : this(Constant.ZombieDefaultName, position, Content)
        {

        }

        public Zombie(string name, Point2D position, ContentManager Content)
            : base(name, position,
                  new Rectangle2D((int)position.X + Constant.ZombieWidth / 2, (int)position.Y,
                      Constant.ZombieWidth, Constant.DefaultHeighForEverything), Constant.ZombieDefaultMoveSpeed, 
                  Constant.ZombieDefaultHealth, Constant.ZombieDefaultArmor, Constant.ZombieDefaultFireResistance,
                  Constant.ZombieDefaultLightingResistance, Constant.ZombieDefaultArcaneResistance, Constant.ZombieDefaultIceResistance,
                  Constant.ZombieDefaultAttackDamage, Constant.ZombieAttackRange,
                  Constant.ZombieAttackFrame * Constant.TimeForFrameInMilliSeconds * Constant.ZombieDeathFramesNumber)
        {
            this.IddleAnimation = new FrameAnimation(
                Constant.ZombieIddleAnimationPath,
                Constant.ZombieIddleFramesNumber,
                this);
            this.IddleAnimation.IsActive = true;
            this.MoveAnimation = new FrameAnimation(
                 Constant.ZombieMoveAnimationPath,
                 Constant.ZombieMoveFramesNumber,
                 this);
            this.AttackAnimation = new FrameAnimation(
                 Constant.ZombieAttackAnimationPath,
                 Constant.ZombieAttackFramesNumber,
                 this);
            this.AttackAnimation.IsLoop = false;
            this.DeathAnimation = new FrameAnimation(
                 Constant.ZombieDeathAnimationPath,
                 Constant.ZombieDeathFramesNumber,
                 this);
            this.DeathAnimation.IsLoop = false;
        }
    }
}
