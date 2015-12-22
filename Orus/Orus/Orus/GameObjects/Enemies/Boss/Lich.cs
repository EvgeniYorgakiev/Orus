using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.GameObjects.Sprites;
using Orus.GameObjects.Sprites.Animations;

namespace Orus.GameObjects.Enemies.Boss
{
    class  LichBoss : Enemy
    {
        public LichBoss()
        {

        }

        public  LichBoss(Point2D position, ContentManager Content)
            : this(Constant.LichBossDefaultName, position, Content)
        {

        }

        public  LichBoss(string name, Point2D position, ContentManager Content)
            : base(name, position,
                  new Rectangle2D((int)position.X + Constant. LichBossWidth / 2, (int)position.Y,
                      Constant.LichBossWidth, Constant.DefaultHeighForEverything), 
                  Constant.LichBossDefaultMoveSpeed,
                  Constant.LichBossDefaultHealth,
                  Constant.LichBossDefaultArmor, 
                  Constant.LichBossDefaultFireResistance,
                  Constant.LichBossDefaultLightingResistance,
                  Constant.LichBossDefaultArcaneResistance,
                  Constant.LichBossDefaultIceResistance,
                  Constant.LichBossDefaultAttackDamage, 
                  Constant.LichBossAttackRange,
                  Constant.LichBossAttackSpeed,
                  Constant.LichBossAttackFrame * 
                  Constant.TimeForFrameInMilliSeconds * 
                  Constant.LichBossAttackFramesNumber / 
                  Constant.LichBossAttackSpeed,
                  Constant.LichBossExperience)
        {
            this.IddleAnimation = new FrameAnimation(
                Constant. LichBossIddleAnimationPath,
                Constant. LichBossIddleFramesNumber,
                this);
            this.IddleAnimation.Scale = Constant.LichBossScale;
            this.IddleAnimation.IsActive = true;
            this.MoveAnimation = new FrameAnimation(
                 Constant. LichBossMoveAnimationPath,
                 Constant. LichBossMoveFramesNumber,
                 this);
            this.MoveAnimation.Scale = Constant.LichBossScale;
            this.AttackAnimation = new FrameAnimation(
                 Constant. LichBossAttackAnimationPath,
                 Constant. LichBossAttackFramesNumber,
                 this);
            this.AttackAnimation.Scale = Constant.LichBossScale;
            this.AttackAnimation.IsLoop = false;
            this.DeathAnimation = new FrameAnimation(
                 Constant. LichBossDeathAnimationPath,
                 Constant. LichBossDeathFramesNumber,
                 this);
            this.DeathAnimation.Scale = Constant.LichBossScale;
            this.DeathAnimation.IsLoop = false;
        }
    }
}
