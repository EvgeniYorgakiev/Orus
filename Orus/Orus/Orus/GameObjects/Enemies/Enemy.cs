using Microsoft.Xna.Framework;
using Orus.Constants;
using Orus.Quests;
using Orus.Sprites;

namespace Orus.GameObjects.Enemies
{
    public class Enemy : AttackableGameObject
    {
        private int experience;

        protected Enemy()
        {

        }

        protected Enemy(string name, Point2D position, Rectangle2D boundingBox, float moveSpeed,
            int health, int armor, int fireResistance, int lightingResistance, int arcaneResistance, int iceResistance, int attackDamage, int attackRange, float attackSpeed, float timeUntilDamageSinceAttack, int experience)
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
            if (!this.AttackAnimation.IsActive && this.Health > 0 && Orus.Instance.Character.Health > 0)
            {
                bool movesRight = this.Position.X < Orus.Instance.Character.Position.X;
                if (this.CollidesForAttack(Orus.Instance.Character, movesRight, this.AttackRange))
                {
                    this.AttackAnimation.IsActive = true;
                    this.MoveAnimation.IsActive = false;
                    this.IddleAnimation.IsActive = false;
                    this.ObjectAttacked = Orus.Instance.Character;
                    this.IsAttacking = true;
                }
                else
                {
                    bool collides = false;
                    foreach (var enemy in Orus.Instance.Levels[Orus.Instance.CurrentLevelIndex].Enemies)
                    {
                        if (this.CollidesForAttack(enemy, movesRight, this.AttackRange))
                        {
                            collides = true;
                            break;
                        }
                    }
                    this.Move(gameTime, movesRight, collides);
                }
            }
            base.Update(gameTime);
        }

        public bool IsVisible()
        {
            return this.Position.X - Orus.Instance.Camera.Center.X < Constant.WindowWidth;
        }

        public bool JustKilled { get; set; }

        public override void Die()
        {
            base.Die();

            foreach (var level in Orus.Instance.Levels)
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
