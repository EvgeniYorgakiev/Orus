﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Abilities;
using Orus.Constants;
using Orus.GameObjects.Sprites;
using Orus.GameObjects.Sprites.Animations;

namespace Orus.GameObjects.Player.Characters
{
    public class Crusader : Character
    {
        private DoubleStrike doubleStrike;
        private Slash slash;

        public Crusader()
        {

        }

        public Crusader(Point2D position, ContentManager Content)
            : this(Constant.CrusaderDefaultName, position, Content)
        {

        }

        public Crusader(string name, Point2D position, ContentManager Content) 
            : base(name, position, 
                  new Rectangle2D((int)position.X + Constant.CrusaderWidth / 2, (int)position.Y,
                      Constant.CrusaderWidth , Constant.DefaultHeighForEverything), 
                  Constant.CrusaderDefaultMoveSpeed,
                  Constant.CrusaderDefaultHealth,
                  Constant.CrusaderDefaultArmor,
                  Constant.CrusaderDefaultFireResistance,
                  Constant.CrusaderDefaultLightingResistance,
                  Constant.CrusaderDefaultArcaneResistance,
                  Constant.CrusaderDefaultIceResistance,
                  Constant.CrusaderDefaultAttackDamage, 
                  Constant.CrusaderAttackRange,
                  Constant.CrusaderAttackSpeed,
                  Constant.CrusaderAttackFrame *
                  Constant.TimeForFrameInMilliSeconds * 
                  Constant.CrusaderAttackFramesNumber /
                  Constant.CrusaderAttackSpeed,
                  Constant.CrusaderHealthOnLevelUp,
                  Constant.CrusaderDamageOnLevelUp)
        {
            this.IddleAnimation = new FrameAnimation(
                 Constant.CrusaderIddleAnimationPath,
                 Constant.CrusaderIddleFramesNumber,
                 this);
            this.IddleAnimation.IsActive = true;
            this.MoveAnimation = new FrameAnimation(
                 Constant.CrusaderMoveAnimationPath,
                 Constant.CrusaderMoveFramesNumber,
                 this);
            this.AttackAnimation = new FrameAnimation(
                 Constant.CrusaderAttackAnimationPath,
                 Constant.CrusaderAttackFramesNumber,
                 this);
            this.AttackAnimation.IsLoop = false;
            this.DeathAnimation = new FrameAnimation(
                 Constant.CrusaderDeathAnimationPath,
                 Constant.CrusaderDeathFramesNumber,
                 this);
            this.DeathAnimation.IsLoop = false;
            this.DoubleStrike = new DoubleStrike((int)(this.AttackDamage * Constant.DoubleStrikeDamageModifier), 
                Constant.CrusaderDoubleAttackAnimationPath, 
                Constant.CrusaderDoubleAttackFramesNumber);
            this.Slash = new Slash((int)(this.AttackDamage * Constant.SlashStrikeDamageModifier),
                Constant.CrusaderDoubleAttackAnimationPath,
                Constant.CrusaderDoubleAttackFramesNumber);
        }

        public DoubleStrike DoubleStrike
        {
            get
            {
                return this.doubleStrike;
            }
            set
            {
                this.doubleStrike = value;
            }
        }

        public Slash Slash
        {
            get
            {
                return this.slash;
            }
            set
            {
                this.slash = value;
            }
        }

        public override void FlipImages(bool isFlipped)
        {
            base.FlipImages(isFlipped);
            if (this.DoubleStrike != null)
            {
                if (isFlipped)
                {
                    this.DoubleStrike.Animation.SpriteEffect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    this.DoubleStrike.Animation.SpriteEffect = SpriteEffects.None;
                }
            }
        }

        public override void Die()
        {
            base.Die();
            this.DoubleStrike.Animation.IsActive = false;
        }

        protected override void UpdateAbilityDamage()
        {
            this.DoubleStrike.Damage = (int)(this.AttackDamage * Constant.DoubleStrikeDamageModifier);
            this.Slash.Damage = (int)(this.AttackDamage * Constant.SlashStrikeDamageModifier);
        }
    }
}
