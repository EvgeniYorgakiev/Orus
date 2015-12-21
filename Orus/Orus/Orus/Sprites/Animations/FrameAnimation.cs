﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.GameObjects;
using Orus.GameObjects.Enemies;
using Orus.GameObjects.Player.Characters;

namespace Orus.Sprites.Animations
{
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
            var objectAsAttackObject = animatedObject as AttackableGameObject;
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
                        if ((animatedObject as AttackableGameObject) != null)
                        {
                            if ((animatedObject as AttackableGameObject).Health > 0)
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
