using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Animations;
using Orus.Interfaces;

namespace Orus.GameObjects.Player.Characters
{
    public abstract class Character : AnimatedGameObject, IAttack, IDeath
    {
        private FrameAnimation attackAnimation;
        private FrameAnimation deathAnimation;
        private string attackAnimationPath;
        private string deathAnimationPath;

        protected Character(Vector2 position, Rectangle boundingBox) : base(position, boundingBox)
        {

        }

        public void Attack()
        {
            this.AttackAnimation.IsActive = true;
            this.MoveAnimation.IsActive = false;
            this.IddleAnimation.IsActive = false;
        }

        public override void FlipImages(bool isFlipped)
        {
            base.FlipImages(isFlipped);
            if (this.AttackAnimation != null)
            {
                if(isFlipped)
                {
                    this.AttackAnimation.SpriteEffect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    this.AttackAnimation.SpriteEffect = SpriteEffects.None;
                }
            }
            if (this.DeathAnimation != null)
            {
                if (isFlipped)
                {
                    this.DeathAnimation.SpriteEffect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    this.DeathAnimation.SpriteEffect = SpriteEffects.None;
                }
            }
        }

        public override void Animate(GameTime gameTime)
        {
            base.Animate(gameTime);
            if (this.AttackAnimation != null)
            {
                this.AttackAnimation.Animate(gameTime, this);
            }
            if (this.DeathAnimation != null)
            {
                this.DeathAnimation.Animate(gameTime);
            }
        }

        public override void DrawAnimations(SpriteBatch spriteBatch)
        {
            base.DrawAnimations(spriteBatch);
            if (this.AttackAnimation != null)
            {
                this.AttackAnimation.Draw(spriteBatch);
            }
            if (this.DeathAnimation != null)
            {
                this.DeathAnimation.Draw(spriteBatch);
            }
        }

        public FrameAnimation AttackAnimation
        {
            get { return this.attackAnimation; }
            set { this.attackAnimation = value; }
        }

        public FrameAnimation DeathAnimation
        {
            get { return this.deathAnimation; }
            set { this.deathAnimation = value; }
        }

        public string AttackAnimationPath
        {
            get { return this.attackAnimationPath; }
            set { this.attackAnimationPath = value; }
        }

        public string DeathAnimationPath
        {
            get { return this.deathAnimationPath; }
            set { this.deathAnimationPath = value; }
        }

        public override Vector2 Position
        {
            get
            {
                return base.Position;
            }

            set
            {
                if (this.AttackAnimation != null)
                {
                    this.AttackAnimation.Position = value;
                }
                if (this.DeathAnimation != null)
                {
                    this.DeathAnimation.Position = value;
                }
                base.Position = value;
            }
        }
    }
}
