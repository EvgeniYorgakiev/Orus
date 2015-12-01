using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Animations;
using Orus.Constants;
using Orus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.Player.Characters
{
    public abstract class AnimatedGameObjects : GameObject, IIddleAnimation, IMove
    {
        private FrameAnimation iddleAnimation;
        private FrameAnimation moveAnimation;
        private string iddleAnimationPath;
        private string moveAnimationPath;

        protected AnimatedGameObjects(Vector2 position) : base(position)
        {

        }

        public void Move(GameTime gameTime, bool directionIsRight)
        {
            this.MoveAnimation.IsActive = true;
            this.IddleAnimation.IsActive = false;
            if (directionIsRight)
            {
                FlipImages(false);
                this.Position = new Vector2(this.Position.X + (gameTime.ElapsedGameTime.Milliseconds) / Constant.Velocity,
                                            this.Position.Y);
            }
            else
            {
                FlipImages(true);
                this.Position = new Vector2(this.Position.X - (gameTime.ElapsedGameTime.Milliseconds) / Constant.Velocity,
                                            this.Position.Y);
            }
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
                this.MoveAnimation.SpriteEffect = SpriteEffects.FlipHorizontally;
                this.IddleAnimation.SpriteEffect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                this.MoveAnimation.SpriteEffect = SpriteEffects.None;
                this.IddleAnimation.SpriteEffect = SpriteEffects.None;
            }
        }

        public virtual void Animate(GameTime gameTime)
        {
            this.IddleAnimation.Animate(gameTime);
            this.MoveAnimation.Animate(gameTime);
        }

        public virtual void DrawAnimations(SpriteBatch spriteBatch)
        {
            this.IddleAnimation.Draw(spriteBatch);
            this.MoveAnimation.Draw(spriteBatch);
        }

        public FrameAnimation IddleAnimation
        {
            get { return this.iddleAnimation; }
            set { this.iddleAnimation = value; }
        }

        public FrameAnimation MoveAnimation
        {
            get { return this.moveAnimation; }
            set { this.moveAnimation = value; }
        }

        public string IddleAnimationPath
        {
            get { return this.iddleAnimationPath; }
            set { this.iddleAnimationPath = value; }
        }

        public string MoveAnimationPath
        {
            get { return this.moveAnimationPath; }
            set { this.moveAnimationPath = value; }
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
    }
}
