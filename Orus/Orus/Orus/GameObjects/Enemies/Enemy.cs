using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.Core;
using Orus.Quests;
using Orus.GameObjects.Sprites;

namespace Orus.GameObjects.Enemies
{
    public class Enemy : AttackingGameObject
    {
        private int experience;

        protected Enemy()
        {

        }

        protected Enemy(string name, Point2D position, Rectangle2D boundingBox, float moveSpeed,
            int health, int armor, double fireResistance, double lightingResistance, double arcaneResistance, 
            double iceResistance, int attackDamage, int attackRange, float attackSpeed, float timeUntilDamageSinceAttack, 
            int experience)
            : base(name, position, boundingBox, moveSpeed, health, armor, fireResistance, lightingResistance, arcaneResistance, iceResistance,
                  attackDamage, attackRange, attackSpeed, timeUntilDamageSinceAttack)
        {
            this.Experience = experience;
        }

        public int Experience
        {
            get
            {
                return this.experience;
            }
            set
            {
                this.experience = value;
            }
        }

        public override void Update(GameTime gameTime)
        {
            //If both the enemy and the character are alive
            if (!this.AttackAnimation.IsActive && this.Health > 0 && OrusTheGame.Instance.GameInformation.Character.Health > 0)
            {
                //If the enemy can attack the character
                bool movesRight = this.Position.X < OrusTheGame.Instance.GameInformation.Character.Position.X;
                if(movesRight && this.IddleAnimation.SpriteEffect.HasFlag(SpriteEffects.FlipHorizontally))
                {
                    FlipImages(false);
                }
                else if(!movesRight && !this.IddleAnimation.SpriteEffect.HasFlag(SpriteEffects.FlipHorizontally))
                {
                    FlipImages(true);
                }
                if (this.CollidesForAttack(OrusTheGame.Instance.GameInformation.Character, movesRight, this.AttackRange))
                {
                    this.AttackAnimation.IsActive = true;
                    this.MoveAnimation.IsActive = false;
                    this.IddleAnimation.IsActive = false;
                    this.ObjectAttacked = OrusTheGame.Instance.GameInformation.Character;
                    this.IsAttacking = true;
                }
                else
                {
                    //Else move toward the character if nothing is in the way
                    bool collides = false;
                    foreach (var enemy in OrusTheGame.Instance.GameInformation.Levels[OrusTheGame.Instance.GameInformation.CurrentLevelIndex].Enemies)
                    {
                        if (this.CollidesForAttack(enemy, movesRight, this.AttackRange))
                        {
                            collides = true;
                            break;
                        }
                    }
                    this.Move(gameTime.ElapsedGameTime.Milliseconds, movesRight, collides);
                }
            }
            base.Update(gameTime);
        }

        public bool IsVisible()
        {
            return this.Position.X - OrusTheGame.Instance.GameInformation.Camera.Center.X < Constant.WindowWidth;
        }

        public bool JustKilled { get; set; }

        public override void Die()
        {
            base.Die();

            //Update the quests that require slaying of monsters
            foreach (var level in OrusTheGame.Instance.GameInformation.Levels)
            {
                foreach (var questGiver in level.QuestGivers)
                {
                    if (questGiver.Quest is SlayQuest)
                    {
                        SlayQuest currentQuest = questGiver.Quest as SlayQuest;
                        if (currentQuest.NameOfEnemy == this.Name)
                        {
                            currentQuest.Update();
                        }
                    }
                }
            }

            this.JustKilled = true;
        }

    }
}
