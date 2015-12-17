using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Interfaces;
using Orus.Constants;
using Orus.GameObjects.Enemies.NormalEnemies;
using Orus.GameObjects.Items;
using Orus.Quests;
using Orus.Sprites.Animations;

namespace Orus.GameObjects.Enemies
{
    public class Enemy : AttackableGameObject
    {
        protected Enemy(string name, Point2D position, Rectangle boundingBox, float moveSpeed,
            int health, int armor, int fireResistance, int lightingResistance, int arcaneResistance, int iceResistance, int attackDamage, int attackRange, float timeUntilDamageSinceAttack)
            : base(name, position, boundingBox, moveSpeed, health, armor, fireResistance, lightingResistance, arcaneResistance, iceResistance,
                  attackDamage, attackRange, timeUntilDamageSinceAttack)
        {

        }

        public void Update(GameTime gameTime)
        {
            if (!this.AttackAnimation.IsActive && this.Health > 0 && Orus.Instance.Character.Health > 0)
            {
                bool movesRight = this.Position.X < Orus.Instance.Character.Position.X;
                if (this.CollidesWithObjects(new List<ICollide>() { Orus.Instance.Character }, movesRight, this.AttackRange))
                {
                    this.AttackAnimation.IsActive = true;
                    this.MoveAnimation.IsActive = false;
                    this.IddleAnimation.IsActive = false;
                    this.ObjectAttacked = Orus.Instance.Character;
                    this.IsAttacking = true;
                }
                else
                {
                    bool collides = this.CollidesWithObjects(
                        Orus.Instance.Levels[Orus.Instance.CurrentLevelIndex].Enemies.ConvertAll<ICollide>(enemy => enemy), movesRight, this.AttackRange);
                    this.Move(gameTime, movesRight, collides);
                }
            }
            this.Animate(gameTime);
        }

        public bool IsVisible()
        {
            return this.Position.X - Orus.Instance.Camera.Center.X < Constant.WindowWidth;
        }

        public override void Die()
        {
            base.Die();

            GenerateItem();

            foreach (var questGiver in Orus.Instance.QuestGivers)
            {
                if(questGiver.Quest is SlayQuest)
                {
                    SlayQuest currentQuest = questGiver.Quest as SlayQuest;
                    if (currentQuest.NameOfEnemy == this.Name)
                    {
                        currentQuest.Update();
                    }
                }
            }
        }

        private void GenerateItem()
        {
            Point2D itemPosition = new Point2D(0, 0);

            if (this is Zombie)
            {
                if (this.DeathAnimation.SpriteEffect == SpriteEffects.None)
                {
                    itemPosition = new Point2D(this.DeathAnimation.Position.X, this.DeathAnimation.Position.Y + MovingDistanceStomper);
                }
                else
                {
                    itemPosition = new Point2D(this.DeathAnimation.Position.X + 100, this.DeathAnimation.Position.Y + MovingDistanceStomper);
                }

                Stomper.ItemAppear(itemPosition);

            }
            else if (this is Skeleton)
            {

                if (this.DeathAnimation.SpriteEffect == SpriteEffects.None)
                {
                    itemPosition = new Point2D(this.DeathAnimation.Position.X, this.DeathAnimation.Position.Y + MovingDistanceArmour);
                }
                else
                {
                    itemPosition = new Point2D(this.DeathAnimation.Position.X + 100, this.DeathAnimation.Position.Y + MovingDistanceArmour);
                }

                GiantArmour.ItemAppear(itemPosition);

            }
        }
    }
}
