using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.Sprites.Animations;

namespace Orus.GameObjects.Player.Characters
{
    public class Crusader : Character
    {
        public Crusader(Point2D position, ContentManager Content)
            : this(Constant.CrusaderDefaultName, position, Content)
        {

        }

        public Crusader(string name, Point2D position, ContentManager Content) 
            : base(name, position, 
                  new Rectangle((int)position.X + Constant.CrusaderWidth / 2, (int)position.Y,
                      Constant.CrusaderWidth , Constant.DefaultHeighForEverything), 
                  Constant.CrusaderDefaultMoveSpeed,
                  Constant.CrusaderDefaultHealth, Constant.CrusaderDefaultArmor, Constant.CrusaderDefaultFireResistance,
                  Constant.CrusaderDefaultLightingResistance, Constant.CrusaderDefaultArcaneResistance, Constant.CrusaderDefaultIceResistance,
                  Constant.CrusaderDefaultAttackDamage, Constant.CrusaderAttackRange, 
                  Constant.CrusaderAttackFrame * Constant.TimeForFrameInMilliSeconds * Constant.CrusaderDeathFramesNumber)
        {
            this.IddleAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(Constant.CrusaderIddleAnimationPath),
                 Constant.CrusaderIddleFramesNumber,
                 this);
            this.IddleAnimation.IsActive = true;
            this.MoveAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(Constant.CrusaderMoveAnimationPath),
                 Constant.CrusaderMoveFramesNumber,
                 this);
            this.AttackAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(Constant.CrusaderAttackAnimationPath),
                 Constant.CrusaderAttackFramesNumber,
                 this);
            this.AttackAnimation.IsLoop = false;
            this.DeathAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(Constant.CrusaderDeathAnimationPath),
                 Constant.CrusaderDeathFramesNumber,
                 this);
            this.DeathAnimation.IsLoop = false;
        }
    }
}
