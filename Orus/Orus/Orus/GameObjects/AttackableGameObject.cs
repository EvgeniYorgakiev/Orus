using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.Interfaces;
using Orus.Menu;
using Orus.Sprites;
using Orus.Sprites.Animations;
using System.Collections.Generic;
using Orus.GameObjects.Enemies.NormalEnemies;
using Orus.GameObjects.Items;
using Orus.GameObjects.Player.Characters;

namespace Orus.GameObjects
{
    public class AttackableGameObject : AnimatedGameObject, IMove, ILife, IAttack, IDeath
    {
        private int maxHealth;
        private int health;
        private Sprite healthBar;
        private int armor;
        private int fireResistance;
        private int lightingResistance;
        private int arcaneResistance;
        private int iceResistance;
        private float moveSpeed;
        private FrameAnimation moveAnimation;
        private FrameAnimation attackAnimation;
        private FrameAnimation deathAnimation;
        private int attackDamage;
        private int attackRange;
        private float timeUntilDamageSinceAttack;
        private bool isAttacking = false;
        private bool isUsingAbility = false;
        private float timeAttacking = 0.0f;
        private AttackableGameObject objectAttacked;

        protected AttackableGameObject(string name, Point2D position, Rectangle boundingBox, float moveSpeed,
             int health, int armor, int fireResistance, int lightingResistance, int arcaneResistance, int iceResistance,
             int attackDamage, int attackRange, float timeUntilDamageSinceAttack)
             : base(name, position, boundingBox)
        {
            this.AttackDamage = attackDamage;
            this.AttackRange = attackRange;
            this.TimeUntilDamageSinceAttack = timeUntilDamageSinceAttack;
            this.MaxHealth = health;
            this.Health = health;
            this.Armor = armor;
            this.FireResistance = fireResistance;
            this.LightingResistance = lightingResistance;
            this.ArcaneResistance = arcaneResistance;
            this.IceResistance = iceResistance;
            this.HealthBar = new Sprite(Orus.Instance.Content.Load<Texture2D>("Sprites\\Health\\HealthBarBorder"), this.Position);
            this.HealthBar.IsActive = true;
            this.MoveSpeed = moveSpeed;
        }

        public int Armor
        {
            get
            {
                return this.armor;
            }
            set
            {
                this.armor = value;
            }
        }

        public double ArmorAsPercentage
        {
            get
            {
                return (float)((this.Armor) * Constant.ConstantForArmorFormula) /
                            (1 + Constant.ConstantForArmorFormula * (this.Armor));
            }
        }

        public int FireResistance
        {
            get
            {
                return this.fireResistance;
            }
            set
            {
                this.fireResistance = value;
            }
        }

        public int LightingResistance
        {
            get
            {
                return this.lightingResistance;
            }
            set
            {
                this.lightingResistance = value;
            }
        }

        public int ArcaneResistance
        {
            get
            {
                return this.arcaneResistance;
            }
            set
            {
                this.arcaneResistance = value;
            }
        }

        public int IceResistance
        {
            get
            {
                return this.iceResistance;
            }
            set
            {
                this.iceResistance = value;
            }
        }

        public int MaxHealth
        {
            get
            {
                return this.maxHealth;
            }
            set
            {
                this.maxHealth = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value <= 0)
                {
                    this.health = 0;
                    this.Die();
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public Sprite HealthBar
        {
            get
            {
                return this.healthBar;
            }
            set
            {
                this.healthBar = value;
            }
        }

        public float MoveSpeed
        {
            get
            {
                return this.moveSpeed;
            }

            set
            {
                this.moveSpeed = value;
            }
        }

        public FrameAnimation MoveAnimation
        {
            get
            {
                return this.moveAnimation;
            }
            set
            {
                this.moveAnimation = value;
            }
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

        public bool IsUsingAbility
        {
            get
            {
                return this.isUsingAbility;
            }
            set
            {
                this.isUsingAbility = value;
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

        public AttackableGameObject ObjectAttacked
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
                if (this.MoveAnimation != null)
                {
                    this.MoveAnimation.Position = value;
                }
                if (this.AttackAnimation != null)
                {
                    this.AttackAnimation.Position = value;
                }
                if (this.DeathAnimation != null)
                {
                    this.DeathAnimation.Position = value;
                }
                if (this.HealthBar != null)
                {
                    this.HealthBar.Position = value;
                }
                base.Position = value;
            }
        }

        public void Attack(List<AttackableGameObject> gameObjects)
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

        public void Move(GameTime gameTime, bool directionIsRight, bool collides)
        {
            this.MoveAnimation.IsActive = true;
            this.IddleAnimation.IsActive = false;
            if (directionIsRight)
            {
                FlipImages(false);
                if (!collides)
                {
                    this.Position = new Point2D(this.Position.X + ((gameTime.ElapsedGameTime.Milliseconds) / Constant.Velocity) * this.MoveSpeed, this.Position.Y);
                }
            }
            else
            {
                FlipImages(true);
                if (!collides)
                {
                    this.Position = new Point2D(this.Position.X - ((gameTime.ElapsedGameTime.Milliseconds) / Constant.Velocity) * this.MoveSpeed, this.Position.Y);
                }
            }
        }

        public void StopMovement()
        {
            this.MoveAnimation.IsActive = false;
            this.IddleAnimation.IsActive = true;
        }

        public override void FlipImages(bool isFlipped)
        {
            base.FlipImages(isFlipped);
            if (this.MoveAnimation != null)
            {
                if (isFlipped)
                {
                    this.MoveAnimation.SpriteEffect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    this.MoveAnimation.SpriteEffect = SpriteEffects.None;
                }
            }
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
            if (this.MoveAnimation != null)
            {
                this.MoveAnimation.Animate(gameTime);
            }
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
                        this.ObjectAttacked.Health -= (int)(this.AttackDamage - (this.AttackDamage * (this.ArmorAsPercentage / 100)));
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
            if (this.Health > 0 && !GameMenu.CharacterSelectionInProgress)
            {
                this.DrawHealthBar(spriteBatch);
            }
            if(this.MoveAnimation != null)
            {
                this.MoveAnimation.Draw(spriteBatch);
            }
            if (this.AttackAnimation != null)
            {
                this.AttackAnimation.Draw(spriteBatch);
            }
            if (this.DeathAnimation != null)
            {
                this.DeathAnimation.Draw(spriteBatch);
            }
        }

        private void DrawHealthBar(SpriteBatch spriteBatch)
        {
            //The gray part 

            spriteBatch.Draw(this.HealthBar.Texture,
                new Vector2(this.HealthBar.Position.X + Constant.HealthBarOffsetX, this.HealthBar.Position.Y + Constant.HealthBarOffsetY),
                new Rectangle(0, 12, this.HealthBar.Texture.Width, 8), Color.Gray);
            //The red health

            double healthInPercentage = ((double)this.Health / this.MaxHealth) * 100;
            spriteBatch.Draw(this.HealthBar.Texture,
                new Rectangle((int)(this.HealthBar.Position.X + Constant.HealthBarOffsetX),
                (int)(this.HealthBar.Position.Y + Constant.HealthBarOffsetY),
                (int)(this.HealthBar.Texture.Width * (healthInPercentage / 100)), 8),
                 new Rectangle(0, 12, this.HealthBar.Texture.Width, 11), Color.Red);

            //The border
            spriteBatch.Draw(this.HealthBar.Texture,
               new Vector2(this.HealthBar.Position.X + Constant.HealthBarOffsetX, this.HealthBar.Position.Y + Constant.HealthBarOffsetY),
               new Rectangle(0, 0, this.HealthBar.Texture.Width, 11), Color.White);
        }

        public override void Die()
        {
            base.Die();
            this.AttackAnimation.IsActive = false;
            this.DeathAnimation.IsActive = true;

            GenerateItem();

        }

        private void GenerateItem()
        {
            Point2D itemPosition = new Point2D(this.DeathAnimation.Position.X, this.DeathAnimation.Position.Y + 50);

            if (this is Zombie)
            {
                Stomper.ItemAppear(itemPosition);
            }
            else if (this is Skeleton)
            {
                GiantArmour.ItemAppear(itemPosition);
            }
        }
    }
}
