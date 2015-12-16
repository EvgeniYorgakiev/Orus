using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.Interfaces;
using System.Collections.Generic;
using System;
using Orus.Sprites.Animations;
using Orus.Sprites;
using Orus.Menu;

namespace Orus.GameObjects
{
    public abstract class AnimatedGameObject : GameObject, IIddle, ICollide
    {
        private FrameAnimation iddleAnimation;
        private Rectangle boundingBox;
        private float animationSpeed;

        protected AnimatedGameObject(string name, Point2D position, Rectangle boundingBox) :
            base(name, position)
        {
            this.BoundingBox = boundingBox;
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
                base.Position = value;
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

        public virtual void FlipImages(bool isFlipped)
        {
            if (isFlipped)
            {
                this.IddleAnimation.SpriteEffect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                this.IddleAnimation.SpriteEffect = SpriteEffects.None;
            }
        }

        public virtual void Animate(GameTime gameTime)
        {
            this.IddleAnimation.Animate(gameTime);
        }

        public virtual void DrawAnimations(SpriteBatch spriteBatch)
        {
            this.IddleAnimation.Draw(spriteBatch);
        }

        public bool Collides(AnimatedGameObject collider, bool isMovingRight, int additionalXOffset = 0)
        {
            if((this as AttackableGameObject) != null)
            {
                if((this as AttackableGameObject).Health == 0)
                {
                    return false;
                }
            }
            if(this == collider)
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
        }
    }
}
