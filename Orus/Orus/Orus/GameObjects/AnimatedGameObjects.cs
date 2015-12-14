using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.Interfaces;
using System.Collections.Generic;
using System;
using Orus.Sprites.Animations;
using Orus.Sprites;

namespace Orus.GameObjects
{
    public abstract class AnimatedGameObject : GameObject, IIddle, IMove, ICollide, ILife
    {
        private FrameAnimation iddleAnimation;
        private FrameAnimation moveAnimation;
        private string iddleAnimationPath;
        private string moveAnimationPath;
        private Rectangle boundingBox;
        private int maxHealth;
        private int health;
        private Sprite healthBar;
        private int armor;
        private int fireResistance;
        private int lightingResistance;
        private int arcaneResistance;
        private int iceResistance;
        private float moveSpeed;
        private float animationSpeed;

        protected AnimatedGameObject(string name, Point2D position, Rectangle boundingBox, float moveSpeed,
            int health, int armor, int fireResistance, int lightingResistance, int arcaneResistance, int iceResistance) : base(name, position)
        {
            this.BoundingBox = boundingBox;
            this.MoveSpeed = moveSpeed;
            this.MaxHealth = health;
            this.Health = health;
            this.Armor = armor;
            this.FireResistance = fireResistance;
            this.LightingResistance = lightingResistance;
            this.ArcaneResistance = arcaneResistance;
            this.IceResistance = iceResistance;
            this.HealthBar = new Sprite(Orus.Instance.Content.Load<Texture2D>("Sprites\\Health\\HealthBarBorder"), this.Position);
            this.HealthBar.IsActive = true;
            this.AnimationSpeed = Constant.DefaultAnimationSpeed;
        }

        public FrameAnimation IddleAnimation
        {
            get
            {
                return this.iddleAnimation;
            }
            set
            {
                this.iddleAnimation = value;
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
        public string IddleAnimationPath
        {
            get
            {
                return this.iddleAnimationPath;
            }
            set
            {
                this.iddleAnimationPath = value;
            }
        }
        public string MoveAnimationPath
        {
            get
            {
                return this.moveAnimationPath;
            }
            set
            {
                this.moveAnimationPath = value;
            }
        }
        public Rectangle BoundingBox
        {
            get
            {
                return this.boundingBox;
            }
            set
            {
                this.boundingBox = value;
            }
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

        public float AnimationSpeed
        {
            get
            {
                return this.animationSpeed;
            }

            set
            {
                this.animationSpeed = value;
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
                if (this.IddleAnimation != null)
                {
                    this.IddleAnimation.Position = value;
                }
                if (this.MoveAnimation != null)
                {
                    this.MoveAnimation.Position = value;
                }
                if(this.HealthBar != null)
                {
                    this.HealthBar.Position = value;
                }
                base.Position = value;
            }
        }

        public void Move(GameTime gameTime, bool directionIsRight, bool collides)
        {
            this.MoveAnimation.IsActive = true;
            this.IddleAnimation.IsActive = false;
            if (directionIsRight)
            {
                FlipImages(false);
                if(!collides)
                {
                    this.Position = new Point2D(this.Position.X + ((gameTime.ElapsedGameTime.Milliseconds) / Constant.Velocity) * this.MoveSpeed,
                                                this.Position.Y);
                }
            }
            else
            {
                FlipImages(true);
                if (!collides)
                {
                    this.Position = new Point2D(this.Position.X - ((gameTime.ElapsedGameTime.Milliseconds) / Constant.Velocity) * this.MoveSpeed,
                                            this.Position.Y);
                }
            }
        }

        public bool CollidesWithObjects(List<ICollide> colliders, bool moveRight, int additionalXOffset = 0)
        {
            foreach (var collider in colliders)
            {
                if (collider.Collides(this, moveRight, additionalXOffset))
                {
                    return true;
                }
            }

            return false;
        }

        public void StopMovement()
        {
            this.MoveAnimation.IsActive = false;
            this.IddleAnimation.IsActive = true;
        }

        public virtual void FlipImages(bool isFlipped)
        {
            if (isFlipped)
            {
                if (this.MoveAnimation != null)
                {
                    this.MoveAnimation.SpriteEffect = SpriteEffects.FlipHorizontally;
                }
                this.IddleAnimation.SpriteEffect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                if (this.MoveAnimation != null)
                {
                    this.MoveAnimation.SpriteEffect = SpriteEffects.None;
                }
                this.IddleAnimation.SpriteEffect = SpriteEffects.None;
            }
        }

        public virtual void Animate(GameTime gameTime)
        {
            this.IddleAnimation.Animate(gameTime);
            if(this.MoveAnimation != null)
            {
                this.MoveAnimation.Animate(gameTime);
            }
        }

        public virtual void DrawAnimations(SpriteBatch spriteBatch)
        {
            this.IddleAnimation.Draw(spriteBatch);
            if(this.Health > 0)
            {
                this.DrawHealthBar(spriteBatch);
            }
            if (this.MoveAnimation != null)
            {
                this.MoveAnimation.Draw(spriteBatch);
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
                 new Rectangle(0, 12, this.HealthBar.Texture.Width, 44), Color.Red);

            //The border
            spriteBatch.Draw(this.HealthBar.Texture,
               new Vector2(this.HealthBar.Position.X + Constant.HealthBarOffsetX, this.HealthBar.Position.Y + Constant.HealthBarOffsetY),
               new Rectangle(0, 0, this.HealthBar.Texture.Width, 11), Color.White);
        }

        public bool Collides(AnimatedGameObject collider, bool isMovingRight, int additionalXOffset = 0)
        {
            if(this.Health == 0 || this == collider)
            {
                return false;
            }
            if(isMovingRight)
            {
                if(collider.Position.X + collider.BoundingBox.Width / 2 >
                this.Position.X - collider.BoundingBox.Width / 2 - additionalXOffset && 
                    collider.Position.X < this.Position.X)
                {
                    return true;
                }
                if (collider.Position.X + collider.BoundingBox.Width / 2 <
                this.Position.X - collider.BoundingBox.Width / 2 - additionalXOffset &&
                    collider.Position.X > this.Position.X)
                {
                    return true;
                }
            }
            else
            {
                if (collider.Position.X - collider.BoundingBox.Width / 2 >
                this.Position.X + collider.BoundingBox.Width / 2 + additionalXOffset &&
                    collider.Position.X < this.Position.X)
                {
                    return true;
                }
                if (collider.Position.X - collider.BoundingBox.Width / 2 <
                this.Position.X + collider.BoundingBox.Width / 2 + additionalXOffset &&
                    collider.Position.X > this.Position.X)
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void Die()
        {
            this.IddleAnimation.IsActive = false;
            this.MoveAnimation.IsActive = false;
        }
    }
}
