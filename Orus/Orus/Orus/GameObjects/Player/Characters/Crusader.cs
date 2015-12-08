using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Orus.Animations;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;

namespace Orus.GameObjects.Player.Characters
{
    public class Crusader : Character
    {
        public Crusader(Point2D position, ContentManager Content) 
            : base(position, 
                  new Rectangle((int)position.X - Constant.CrusaderWidth / 2, (int)position.Y - Constant.DefaultHeighForEverything / 2,
                      Constant.CrusaderWidth , Constant.DefaultHeighForEverything), Constant.CrusaderDefaultMoveSpeed,
                  Constant.CrusaderDefaultHealth, Constant.CrusaderDefaultArmor, Constant.CrusaderDefaultFireResistance,
                  Constant.CrusaderDefaultLightingResistance, Constant.CrusaderDefaultArcaneResistance, Constant.CrusaderDefaultIceResistance,
                  Constant.CrusaderDefaultAttackDamage, Constant.CrusaderAttackRange)
        {
            this.IddleAnimationPath = "Sprites\\Crusader\\Crusader iddle";
            this.MoveAnimationPath = "Sprites\\Crusader\\Crusader move";
            this.AttackAnimationPath = "Sprites\\Crusader\\Crusader attack";
            this.DeathAnimationPath = "Sprites\\Crusader\\Crusader death";
            this.IddleAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(this.IddleAnimationPath),
                 Constant.CrusaderIddleFramesNumber,
                 this);
            this.IddleAnimation.IsActive = true;
            this.MoveAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(this.MoveAnimationPath),
                 Constant.CrusaderMoveFramesNumber,
                 this);
            this.AttackAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(this.AttackAnimationPath),
                 Constant.CrusaderAttackFramesNumber,
                 this);
            this.AttackAnimation.IsLoop = false;
            this.DeathAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(this.DeathAnimationPath),
                 Constant.CrusaderDeathFramesNumber,
                 this);
            this.DeathAnimation.IsLoop = false;
        }
    }
}
