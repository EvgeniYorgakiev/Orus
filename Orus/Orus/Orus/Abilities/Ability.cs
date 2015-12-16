using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.GameObjects;
using Orus.GameObjects.Player.Characters;
using Orus.Interfaces;
using Orus.Sprites.Animations;

namespace Orus.Abilities
{
    public abstract class Ability
    {
        private FrameAnimation animation;
        private int damage;
        private float cooldownTime;
        private float timeSinceUse;
        private bool isOnCooldown;
        private bool isPlayerUsable;
        private bool isEnemyUsable;
        private DamageType damageType;

        public Ability(int damage, float cooldown, string pathForAnimation, int animationFrames)
        {
            this.Damage = damage;
            this.Animation = new FrameAnimation(
                Orus.Instance.Content.Load<Texture2D>(pathForAnimation),
                animationFrames);
            this.Animation.IsLoop = false;
            this.CooldownTime = cooldown;
            this.TimeSinceUse = 0;
        }

        public FrameAnimation Animation
        {
            get
            {
                return this.animation;
            }

            set
            {
                this.animation = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                this.damage = value;
            }
        }

        public float CooldownTime
        {
            get
            {
                return this.cooldownTime;
            }

            set
            {
                this.cooldownTime = value;
            }
        }

        public float TimeSinceUse
        {
            get
            {
                return this.timeSinceUse;
            }

            set
            {
                this.timeSinceUse = value;
            }
        }

        public bool IsOnCooldown
        {
            get
            {
                return this.isOnCooldown;
            }

            set
            {
                this.isOnCooldown = value;
            }
        }

        public bool IsPlayerUsable
        {
            get
            {
                return this.isPlayerUsable;
            }

            set
            {
                this.isPlayerUsable = value;
            }
        }

        public bool IsEnemyUsable
        {
            get
            {
                return this.isEnemyUsable;
            }

            set
            {
                this.isEnemyUsable = value;
            }
        }

        public DamageType DamageType
        {
            get
            {
                return this.damageType;
            }

            set
            {
                this.damageType = value;
            }
        }

        public virtual void Update(GameTime gameTime, AttackableGameObject objectUsingAbility)
        {
            if (this.IsOnCooldown)
            {
                if (!this.Animation.IsActive)
                {
                    objectUsingAbility.IsUsingAbility = false;
                }
                this.TimeSinceUse += gameTime.ElapsedGameTime.Milliseconds / 1000;
                if (this.TimeSinceUse >= this.CooldownTime)
                {
                    this.IsOnCooldown = false;
                }
                this.Animation.Animate(gameTime, objectUsingAbility);
            }
        }

        public virtual void Action(Character character)
        {
            this.Animation.IsActive = true;
            this.TimeSinceUse = 0;
            this.IsOnCooldown = true;
            character.IddleAnimation.IsActive = false;
            character.IsUsingAbility = true;
        }
    }
}
