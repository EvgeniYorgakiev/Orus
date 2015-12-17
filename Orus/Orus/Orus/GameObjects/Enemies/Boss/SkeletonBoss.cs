using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.Sprites.Animations;

namespace Orus.GameObjects.Enemies.Boss
{
    class  SkeletonBoss : Enemy
    {
        public  SkeletonBoss(Point2D position, ContentManager Content)
            : this(Constant. SkeletonBossDefaultName, position, Content)
        {

        }

        public  SkeletonBoss(string name, Point2D position, ContentManager Content)
            : base(name, position,
                  new Rectangle((int)position.X + Constant. SkeletonBossWidth / 2, (int)position.Y,
                      Constant. SkeletonBossWidth, Constant.DefaultHeighForEverything), Constant. SkeletonBossDefaultMoveSpeed,
                  Constant. SkeletonBossDefaultHealth, Constant. SkeletonBossDefaultArmor, Constant. SkeletonBossDefaultFireResistance,
                  Constant. SkeletonBossDefaultLightingResistance, Constant. SkeletonBossDefaultArcaneResistance, Constant. SkeletonBossDefaultIceResistance,
                  Constant. SkeletonBossDefaultAttackDamage, Constant. SkeletonBossAttackRange,
                  Constant. SkeletonBossAttackFrame * Constant.TimeForFrameInMilliSeconds * Constant. SkeletonBossDeathFramesNumber)
        {
            this.IddleAnimation = new FrameAnimation(
                Content.Load<Texture2D>(Constant. SkeletonBossIddleAnimationPath),
                Constant. SkeletonBossIddleFramesNumber,
                this);
            this.IddleAnimation.IsActive = true;
            this.MoveAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(Constant. SkeletonBossMoveAnimationPath),
                 Constant. SkeletonBossMoveFramesNumber,
                 this);
            this.AttackAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(Constant. SkeletonBossAttackAnimationPath),
                 Constant. SkeletonBossAttackFramesNumber,
                 this);
            this.AttackAnimation.IsLoop = false;
            this.DeathAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(Constant. SkeletonBossDeathAnimationPath),
                 Constant. SkeletonBossDeathFramesNumber,
                 this);
            this.DeathAnimation.IsLoop = false;
            this.AnimationSpeed = 0.3f;
        }
    }
}
