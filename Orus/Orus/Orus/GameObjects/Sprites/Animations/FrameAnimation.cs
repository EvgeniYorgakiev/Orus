namespace Orus.GameObjects.Sprites.Animations
{
    using Microsoft.Xna.Framework;
    using Orus.Constants;

    public class FrameAnimation : Sprite
    {
        private float time = 0f;

        public float Time { get { return time; } set { time = value; } }

        public FrameAnimation()
        {

        }

        public FrameAnimation(string path, int frames, AnimatedGameObject animatedGameObject)
            : base(path, frames, animatedGameObject)
        {

        }

        public FrameAnimation(string path, int frames)
            : base(path, frames)
        {

        }

        public void Animate(GameTime gameTime)
        {
            this.Time += gameTime.ElapsedGameTime.Milliseconds;
            if (this.Time > Constant.TimeForFrameInMilliSeconds * this.Rectangles.Length)
            {
                this.Time = 0f;
                this.FrameIndex++;
                if(this.FrameIndex == this.Rectangles.Length)
                {
                    this.FrameIndex = 0;
                }
            }
        }

        public void Animate(GameTime gameTime, AnimatedGameObject animatedObject)
        {
            if(!this.IsActive)
            {
                return;
            }
            this.Time += gameTime.ElapsedGameTime.Milliseconds;
            var speed = animatedObject.AnimationSpeed;
            var objectAsAttackObject = animatedObject as AttackingGameObject;
            if(objectAsAttackObject != null)
            {
                if(objectAsAttackObject.AttackAnimation == this && this.IsActive)
                {
                    speed = objectAsAttackObject.AttackSpeed;
                }
            }
            if (this.Time > (Constant.TimeForFrameInMilliSeconds * this.Rectangles.Length) / speed)
            {
                this.Time = 0f;
                this.FrameIndex++;
                if (this.FrameIndex == this.Rectangles.Length)
                {
                    this.FrameIndex = 0;
                    if(!this.IsLoop)
                    {
                        this.IsActive = false;
                        if ((animatedObject as AttackingGameObject) != null)
                        {
                            if ((animatedObject as AttackingGameObject).Health > 0)
                            {
                                animatedObject.IddleAnimation.IsActive = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
