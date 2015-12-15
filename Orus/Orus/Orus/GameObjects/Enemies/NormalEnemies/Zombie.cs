using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.Sprites.Animations;

namespace Orus.GameObjects.Enemies.NormalEnemies
{
    class Zombie : Enemy
    {
        public Zombie(Point2D position, ContentManager Content)
            : this(Constant.ZombieDefaultName, position, Content)
        {

        }

        public Zombie(string name, Point2D position, ContentManager Content)
            : base(name, position,
                  new Rectangle((int)position.X + Constant.ZombieWidth / 2, (int)position.Y,
                      Constant.ZombieWidth, Constant.DefaultHeighForEverything), Constant.ZombieDefaultMoveSpeed, 
                  Constant.ZombieDefaultHealth, Constant.ZombieDefaultArmor, Constant.ZombieDefaultFireResistance,
                  Constant.ZombieDefaultLightingResistance, Constant.ZombieDefaultArcaneResistance, Constant.ZombieDefaultIceResistance,
                  Constant.ZombieDefaultAttackDamage, Constant.ZombieAttackRange,
                  Constant.ZombieAttackFrame * Constant.TimeForFrameInMilliSeconds * Constant.ZombieDeathFramesNumber)
        {
            this.IddleAnimationPath = "Sprites\\Enemies\\Zombie\\Zombie iddle";
            this.MoveAnimationPath = "Sprites\\Enemies\\Zombie\\Zombie move";
            this.AttackAnimationPath = "Sprites\\Enemies\\Zombie\\Zombie attack";
            this.DeathAnimationPath = "Sprites\\Enemies\\Zombie\\Zombie death";
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
