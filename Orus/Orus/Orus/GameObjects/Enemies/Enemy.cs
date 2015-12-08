using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Animations;
using Orus.Interfaces;
using Orus.Constants;

namespace Orus.GameObjects.Enemies
{
    public class Enemy : AnimatedGameObject, IAttack, IDeath
    {
        private FrameAnimation attackAnimation;
        private FrameAnimation deathAnimation;
        private string attackAnimationPath;
        private string deathAnimationPath;
        private int attackDamage;
        private int attackRange;

        protected Enemy(Point2D position, Rectangle boundingBox, float moveSpeed,
            int health, int armor, int fireResistance, int lightingResistance, int arcaneResistance, int iceResistance, int attackDamage, int attackRange)
            : base(position, boundingBox, moveSpeed, health, armor, fireResistance, lightingResistance, arcaneResistance, iceResistance)
        {
            this.AttackDamage = attackDamage;
            this.AttackRange = attackRange;
        }

        public FrameAnimation AttackAnimation
        {
            get
            {
                return this.attackAnimation;
            }
            set
            {
                this.attackAnimation = value;
            }
        }

        public FrameAnimation DeathAnimation
        {
            get
            {
                return this.deathAnimation;
            }
            set
            {
                this.deathAnimation = value;
            }
        }

        public string AttackAnimationPath
        {
            get
            {
                return this.attackAnimationPath;
            }
            set
            {
                this.attackAnimationPath = value;
            }
        }

        public string DeathAnimationPath
        {
            get
            {
                return this.deathAnimationPath;
            }
            set
            {
                this.deathAnimationPath = value;
            }
        }

        public int AttackDamage
        {
            get
            {
                return this.attackDamage;
            }
            set
            {
                this.attackDamage = value;
            }
        }
        public int AttackRange
        {
            get
            {
                return this.attackRange;
            }
            set
            {
                this.attackRange = value;
            }
        }

        public override Point2D Position
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

        public void Attack(List<AnimatedGameObject> gameObjects)
        {
            this.AttackAnimation.IsActive = true;
            this.MoveAnimation.IsActive = false;
            this.IddleAnimation.IsActive = false;
            foreach (var gameObject in gameObjects)
            {
                if (gameObject.Collides(this, this.MoveAnimation.SpriteEffect.HasFlag(SpriteEffects.FlipHorizontally)))
                {
                    gameObject.Health -= this.AttackDamage;
                }
            }
        }

        public override void FlipImages(bool isFlipped)
        {
            base.FlipImages(isFlipped);
            if (this.AttackAnimation != null)
            {
                if (isFlipped)
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

        public void Update(GameTime gameTime)
        {
            if (!this.AttackAnimation.IsActive && this.Health > 0)
            {
                bool movesRight = this.Position.X < Orus.Instance.Character.Position.X;
                if (this.CollidesWithObjects(new List<ICollide>() { Orus.Instance.Character }, movesRight, this.AttackRange))
                {
                    this.AttackAnimation.IsActive = true;
                    this.MoveAnimation.IsActive = false;
                    this.IddleAnimation.IsActive = false;
                    Orus.Instance.Character.Health -= (int)(this.AttackDamage - (this.AttackDamage * ((float)Orus.Instance.Character.Armor / 100)));
                }
                else
                {
                    bool collides = this.CollidesWithObjects(
                        Orus.Instance.Enemies.ConvertAll<ICollide>(enemy => enemy), movesRight, this.AttackRange);
                    this.Move(gameTime, movesRight, collides);
                }
            }
            this.Animate(gameTime);
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
                this.DeathAnimation.Animate(gameTime, this);
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

        public override void Die()
        {
            base.Die();
            this.AttackAnimation.IsActive = false;
            this.DeathAnimation.IsActive = true;
        }
    }
}
