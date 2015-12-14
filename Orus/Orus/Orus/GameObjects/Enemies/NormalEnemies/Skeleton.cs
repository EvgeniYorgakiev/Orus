using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.Sprites.Animations;

namespace Orus.GameObjects.Enemies.NormalEnemies
{
    class Skeleton : Enemy
    {
        public Skeleton(Point2D position, ContentManager Content)
            : this(Constant.SkeletonDefaultName, position, Content)
        {

        }

        public Skeleton(string name, Point2D position, ContentManager Content)
            : base(name, position,
                  new Rectangle((int)position.X - Constant.SkeletonWidth / 2, (int)position.Y - Constant.DefaultHeighForEverything / 2,
                      Constant.SkeletonWidth, Constant.DefaultHeighForEverything), Constant.SkeletonDefaultMoveSpeed, 
                  Constant.SkeletonDefaultHealth, Constant.SkeletonDefaultArmor, Constant.SkeletonDefaultFireResistance,
                  Constant.SkeletonDefaultLightingResistance, Constant.SkeletonDefaultArcaneResistance, Constant.SkeletonDefaultIceResistance,
                  Constant.SkeletonDefaultAttackDamage, Constant.SkeletonAttackRange,
                  Constant.SkeletonAttackFrame * Constant.TimeForFrameInMilliSeconds * Constant.SkeletonDeathFramesNumber)
        {
            this.IddleAnimationPath = "Sprites\\Enemies\\Skeleton\\Skeleton iddle";
            this.MoveAnimationPath = "Sprites\\Enemies\\Skeleton\\Skeleton move";
            this.AttackAnimationPath = "Sprites\\Enemies\\Skeleton\\Skeleton attack";
            this.DeathAnimationPath = "Sprites\\Enemies\\Skeleton\\Skeleton death";
            this.IddleAnimation = new FrameAnimation(
                Content.Load<Texture2D>(this.IddleAnimationPath),
                Constant.SkeletonIddleFramesNumber,
                this);
            this.IddleAnimation.IsActive = true;
            this.MoveAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(this.MoveAnimationPath),
                 Constant.SkeletonMoveFramesNumber,
                 this);
            this.AttackAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(this.AttackAnimationPath),
                 Constant.SkeletonAttackFramesNumber,
                 this);
            this.AttackAnimation.IsLoop = false;
            this.DeathAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(this.DeathAnimationPath),
                 Constant.SkeletonDeathFramesNumber,
                 this);
            this.DeathAnimation.IsLoop = false;
            this.AnimationSpeed = 0.3f;
        }
    }
}
