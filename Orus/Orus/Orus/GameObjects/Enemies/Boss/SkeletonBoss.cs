using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.GameObjects.Sprites;
using Orus.GameObjects.Sprites.Animations;

namespace Orus.GameObjects.Enemies.Boss
{
    class  SkeletonBoss : Enemy
    {
        public SkeletonBoss()
        {

        }

        public  SkeletonBoss(Point2D position, ContentManager Content)
            : this(Constant.SkeletonBossDefaultName, position, Content)
        {

        }

        public  SkeletonBoss(string name, Point2D position, ContentManager Content)
            : base(name, position,
                  new Rectangle2D((int)position.X + Constant. SkeletonBossWidth / 2, (int)position.Y,
                      (int)(Constant.SkeletonBossWidth * Constant.SkeletonBossScale),
                      (int)(Constant.DefaultHeighForEverything * Constant.SkeletonBossScale)), 
                  Constant.SkeletonBossDefaultMoveSpeed,
                  Constant.SkeletonBossDefaultHealth,
                  Constant.SkeletonBossDefaultArmor, 
                  Constant.SkeletonBossDefaultFireResistance,
                  Constant.SkeletonBossDefaultLightingResistance,
                  Constant.SkeletonBossDefaultArcaneResistance,
                  Constant.SkeletonBossDefaultIceResistance,
                  Constant.SkeletonBossDefaultAttackDamage, 
                  Constant.SkeletonBossAttackRange,
                  Constant.SkeletonBossAttackSpeed,
                  Constant.SkeletonBossAttackFrame * 
                  Constant.TimeForFrameInMilliSeconds * 
                  Constant.SkeletonBossAttackFramesNumber / 
                  Constant.SkeletonBossAttackSpeed,
                  Constant.SkeletonBossExperience)
        {
            this.IddleAnimation = new FrameAnimation(
                Constant. SkeletonBossIddleAnimationPath,
                Constant. SkeletonBossIddleFramesNumber,
                this);
            this.IddleAnimation.Scale = Constant.SkeletonBossScale;
            this.IddleAnimation.IsActive = true;
            this.MoveAnimation = new FrameAnimation(
                 Constant. SkeletonBossMoveAnimationPath,
                 Constant. SkeletonBossMoveFramesNumber,
                 this);
            this.MoveAnimation.Scale = Constant.SkeletonBossScale;
            this.AttackAnimation = new FrameAnimation(
                 Constant. SkeletonBossAttackAnimationPath,
                 Constant. SkeletonBossAttackFramesNumber,
                 this);
            this.AttackAnimation.Scale = Constant.SkeletonBossScale;
            this.AttackAnimation.IsLoop = false;
            this.DeathAnimation = new FrameAnimation(
                 Constant. SkeletonBossDeathAnimationPath,
                 Constant. SkeletonBossDeathFramesNumber,
                 this);
            this.DeathAnimation.Scale = Constant.SkeletonBossScale;
            this.DeathAnimation.IsLoop = false;
        }
    }
}
