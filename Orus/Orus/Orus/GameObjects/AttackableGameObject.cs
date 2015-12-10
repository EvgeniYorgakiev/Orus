using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Animations;
using System.Collections.Generic;

namespace Orus.GameObjects
{
    public class AttackableGameObject : AnimatedGameObject
    {
        private FrameAnimation attackAnimation;
        private FrameAnimation deathAnimation;
        private string attackAnimationPath;
        private string deathAnimationPath;
        private int attackDamage;
        private int attackRange;
        private float timeUntilDamageSinceAttack;
        private bool isAttacking = false;
        private float timeAttacking = 0.0f;
        private AnimatedGameObject objectAttacked;

        protected AttackableGameObject(string name, Point2D position, Rectangle boundingBox, float moveSpeed,
            int health, int armor, int fireResistance, int lightingResistance, int arcaneResistance, int iceResistance,
            int attackDamage, int attackRange, float timeUntilDamageSinceAttack)
            : base(name, position, boundingBox, moveSpeed, health, armor, fireResistance, lightingResistance, arcaneResistance, iceResistance)
        {
            this.AttackDamage = attackDamage;
            this.AttackRange = attackRange;
            this.TimeUntilDamageSinceAttack = timeUntilDamageSinceAttack;
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

        public float TimeUntilDamageSinceAttack
        {
            get
            {
                return this.timeUntilDamageSinceAttack;
            }
            set
            {
                this.timeUntilDamageSinceAttack = value;
            }
        }
        
        public bool IsAttacking
        {
            get
            {
                return this.isAttacking;
            }
            set
            {
                this.isAttacking = value;
            }
        }

        public float TimeAttacking
        {
            get
            {
                return this.timeAttacking;
            }
            set
            {
                this.timeAttacking = value;
            }
        }

        public AnimatedGameObject ObjectAttacked
        {
            get
            {
                return this.objectAttacked;
            }
            set
            {
                this.objectAttacked = value;
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
                if (gameObject.Collides(this, !this.MoveAnimation.SpriteEffect.HasFlag(SpriteEffects.FlipHorizontally), this.AttackRange))
                {
                    this.ObjectAttacked = gameObject;
                    this.IsAttacking = true;
                    return;
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

        public override void Animate(GameTime gameTime)
        {
            base.Animate(gameTime);
            if (this.IsAttacking)
            {
                this.TimeAttacking += gameTime.ElapsedGameTime.Milliseconds;
                if(this.TimeAttacking > this.TimeUntilDamageSinceAttack)
                {
                    this.IsAttacking = false;
                    this.TimeAttacking = 0.0f;
                    if(this.ObjectAttacked.Collides(
                        this, !this.MoveAnimation.SpriteEffect.HasFlag(SpriteEffects.FlipHorizontally), this.AttackRange) && this.Health > 0)
                    {
                        this.ObjectAttacked.Health -= (int)(this.AttackDamage - (this.AttackDamage * ((float)this.ObjectAttacked.Armor / 100)));
                    }
                }
            }
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
                if (this.Health > 0)
                {
                    spriteBatch.DrawString(Orus.Instance.HealthFont, this.Health.ToString(),
                   new Vector2(this.Position.X + this.BoundingBox.Width / 1.5f, this.Position.Y), Color.White);
                }
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
