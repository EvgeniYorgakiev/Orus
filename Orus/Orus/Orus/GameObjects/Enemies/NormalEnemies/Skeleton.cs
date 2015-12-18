using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.Sprites;
using Orus.Sprites.Animations;

namespace Orus.GameObjects.Enemies.NormalEnemies
{
    class Skeleton : Enemy
    {
        public Skeleton()
        {

        }

        public Skeleton(Point2D position, ContentManager Content)
            : this(Constant.SkeletonDefaultName, position, Content)
        {

        }

        public Skeleton(string name, Point2D position, ContentManager Content)
            : base(name, position,
                  new Rectangle2D((int)position.X + Constant.SkeletonWidth / 2, (int)position.Y,
                      Constant.SkeletonWidth, Constant.DefaultHeighForEverything), Constant.SkeletonDefaultMoveSpeed, 
                  Constant.SkeletonDefaultHealth, Constant.SkeletonDefaultArmor, Constant.SkeletonDefaultFireResistance,
                  Constant.SkeletonDefaultLightingResistance, Constant.SkeletonDefaultArcaneResistance, Constant.SkeletonDefaultIceResistance,
                  Constant.SkeletonDefaultAttackDamage, Constant.SkeletonAttackRange,
                  Constant.SkeletonAttackFrame * Constant.TimeForFrameInMilliSeconds * Constant.SkeletonDeathFramesNumber)
        {
            this.IddleAnimation = new FrameAnimation(
                Constant.SkeletonIddleAnimationPath,
                Constant.SkeletonIddleFramesNumber,
                this);
            this.IddleAnimation.IsActive = true;
            this.MoveAnimation = new FrameAnimation(
                 Constant.SkeletonMoveAnimationPath,
                 Constant.SkeletonMoveFramesNumber,
                 this);
            this.AttackAnimation = new FrameAnimation(
                 Constant.SkeletonAttackAnimationPath,
                 Constant.SkeletonAttackFramesNumber,
                 this);
            this.AttackAnimation.IsLoop = false;
            this.DeathAnimation = new FrameAnimation(
                 Constant.SkeletonDeathAnimationPath,
                 Constant.SkeletonDeathFramesNumber,
                 this);
            this.DeathAnimation.IsLoop = false;
            this.AnimationSpeed = 0.3f;
        }
    }
}
