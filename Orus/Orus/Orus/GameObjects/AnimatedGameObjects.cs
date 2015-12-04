using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Animations;
using Orus.Constants;
using Orus.Interfaces;
using System.Collections.Generic;

namespace Orus.GameObjects
{
    public abstract class AnimatedGameObject : GameObject, IIddle, IMove, ICollide, ILife
    {
        private FrameAnimation iddleAnimation;
        private FrameAnimation moveAnimation;
        private string iddleAnimationPath;
        private string moveAnimationPath;
        private Rectangle boundingBox;
        private int health;
        private int armor;
        private int fireResistance;
        private int lightingResistance;
        private int arcaneResistance;
        private int iceResistance;

        protected AnimatedGameObject(Vector2 position, Rectangle boundingBox,
            int health, int armor, int fireResistance, int lightingResistance, int arcaneResistance, int iceResistance) : base(position)
        {
            this.BoundingBox = boundingBox;
            this.Health = health;
            this.Armor = armor;
            this.FireResistance = fireResistance;
            this.LightingResistance = lightingResistance;
            this.ArcaneResistance = arcaneResistance;
            this.IceResistance = iceResistance;
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

        public override Vector2 Position
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
                    this.Position = new Vector2(this.Position.X + (gameTime.ElapsedGameTime.Milliseconds) / Constant.Velocity,
                                                this.Position.Y);
                }
            }
            else
            {
                FlipImages(true);
                if (!collides)
                {
                    this.Position = new Vector2(this.Position.X - (gameTime.ElapsedGameTime.Milliseconds) / Constant.Velocity,
                                            this.Position.Y);
                }
            }
        }

        public bool CollidesWith(List<ICollide> colliders, bool moveRight)
        {
            foreach (var collider in colliders)
            {
                if (collider.Collides(this, moveRight))
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
            if (this.MoveAnimation != null)
            {
                this.MoveAnimation.Draw(spriteBatch);
            }
        }

        public bool Collides(AnimatedGameObject collider, bool isMovingRight)
        {
            if(collider.Position.X + collider.BoundingBox.Width / 2 > this.Position.X - collider.BoundingBox.Width / 2 && isMovingRight)
            {
                return true;
            }
            if (collider.Position.X - collider.BoundingBox.Width / 2 > this.Position.X + collider.BoundingBox.Width / 2 && !isMovingRight)
            {
                return true;
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
