using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Animations;
using Orus.Interfaces;
using Orus.Constants;

namespace Orus.GameObjects.Enemies
{
    public class Enemy : AttackableGameObject
    {
        protected Enemy(Point2D position, Rectangle boundingBox, float moveSpeed,
            int health, int armor, int fireResistance, int lightingResistance, int arcaneResistance, int iceResistance, int attackDamage, int attackRange)
            : base(position, boundingBox, moveSpeed, health, armor, fireResistance, lightingResistance, arcaneResistance, iceResistance,
                  attackDamage, attackRange)
        {

        }

        public void Update(GameTime gameTime)
        {
            if (!this.AttackAnimation.IsActive && this.Health > 0)
            {
                bool movesRight = this.Position.X < Orus.Instance.Character.Position.X;
                if (this.CollidesWithObjects(new List<ICollide>() { Orus.Instance.Character }, movesRight, this.AttackRange))
                {
                    this.AttackAnimation.IsActive = true;
                    this.MoveAnimation.IsActive = false;
                    this.IddleAnimation.IsActive = false;
                    Orus.Instance.Character.Health -= (int)(this.AttackDamage - (this.AttackDamage * ((float)Orus.Instance.Character.Armor / 100)));
                }
                else
                {
                    bool collides = this.CollidesWithObjects(
                        Orus.Instance.Enemies.ConvertAll<ICollide>(enemy => enemy), movesRight, this.AttackRange);
                    this.Move(gameTime, movesRight, collides);
                }
            }
            this.Animate(gameTime);
        }
    }
}
