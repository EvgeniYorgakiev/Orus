using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.GameObjects;
using Orus.GameObjects.Player.Characters;

namespace Orus.Animations
{
    public class FrameAnimation : Sprite
    {
        private float time = 0f;

        public float Time { get { return time; } set { time = value; } }

        public FrameAnimation(Texture2D Texture, int frames, AnimatedGameObject animatedGameObject)
            : base(Texture, frames, animatedGameObject)
        {
        }

        public FrameAnimation(Texture2D Texture, int frames)
            : base(Texture, frames)
        {
        }

        public void Animate(GameTime gameTime)
        {
            this.Time += gameTime.ElapsedGameTime.Milliseconds;
            if (this.Time > Constant.TimeForFrameInMilliSeconds * this.Rectangles.Length)
            {
                time = 0f;
                this.FrameIndex++;
                if(this.FrameIndex == this.Rectangles.Length)
                {
                    this.FrameIndex = 0;
                }
            }
        }

        public void Animate(GameTime gameTime, AnimatedGameObject animateObject)
        {
            if(!this.IsActive)
            {
                return;
            }
            this.Time += gameTime.ElapsedGameTime.Milliseconds;
            if (this.Time > Constant.TimeForFrameInMilliSeconds * this.Rectangles.Length)
            {
                time = 0f;
                this.FrameIndex++;
                if (this.FrameIndex == this.Rectangles.Length)
                {
                    this.FrameIndex = 0;
                    if(!this.IsLoop)
                    {
                        this.IsActive = false;
                        animateObject.IddleAnimation.IsActive = true;
                    }
                }
            }
        }
    }
}
