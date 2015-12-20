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
    public abstract class AnimatedGameObject : ColliderObjects, IIddle
    {
        private FrameAnimation iddleAnimation;
        private float animationSpeed;

        protected AnimatedGameObject()
        {

        }

        protected AnimatedGameObject(string name, Point2D position, Rectangle2D boundingBox) :
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

        public virtual void Update(GameTime gameTime)
        {
            this.IddleAnimation.Animate(gameTime, this);
        }

        public virtual void DrawAnimations(SpriteBatch spriteBatch)
        {
            this.IddleAnimation.Draw(spriteBatch);
        }

        public virtual void Die()
        {
            this.IddleAnimation.IsActive = false;
        }
    }
}
