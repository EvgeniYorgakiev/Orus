using System.Collections.Generic;
using Orus.GameObjects.Items;
using Orus.Interfaces;
using Orus.Sprites;
using Orus.GameObjects.Enemies;
using Orus.Constants;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Orus.GameObjects.Player.Characters
{
    public abstract class Character : AttackableGameObject, ICollectItems
    {
        private int experience;
        private int currentLevel;
        private List<int> levels;
        private int healthOnLevelUp;
        private int damageOnLevelUp;

        protected Character()
        {

        }

        protected Character(string name, Point2D position, Rectangle2D boundingBox, float moveSpeed,
            int health, int armor, int fireResistance, int lightingResistance, int arcaneResistance, int iceResistance,
            int attackDamage, int attackRange, float attackSpeed,
            float timeUntilDamageSinceAttack, int healthOnLevelup, int damageOnLevelUp)
            : base(name, position, boundingBox, moveSpeed, health, armor, fireResistance, lightingResistance, arcaneResistance, iceResistance,
                  attackDamage, attackRange, attackSpeed, timeUntilDamageSinceAttack)
        {
            this.Experience = 0;
            this.CurrentLevel = 1;
            this.CollectedItems = new List<IItem>();
            this.Levels = ConstantLevels.CharacterLevels();
            this.HealthOnLevelUp = healthOnLevelup;
            this.DamageOnLevelUp = damageOnLevelUp;
        }

        public ICollection<IItem> CollectedItems { get; set; }

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

        public int HealthOnLevelUp
        {
            get
            {
                return this.healthOnLevelUp;
            }
            set
            {
                this.healthOnLevelUp = value;
            }
        }

        public int DamageOnLevelUp
        {
            get
            {
                return this.damageOnLevelUp;
            }
            set
            {
                this.damageOnLevelUp = value;
            }
        }

        public int CurrentLevel
        {
            get
            {
                return this.currentLevel;
            }
            set
            {
                this.currentLevel = value;
            }
        }

        public List<int> Levels
        {
            get
            {
                return this.levels;
            }
            set
            {
                this.levels = value;
            }
        }

        public void CheckCollisionOfCharacterWithItems(ICollection<IItem> itemCollection)
        {
            foreach (var element in itemCollection)
            {
                if (this.CollidesWithItem(element))
                {
                    element.IsCollectedByCharacter = true;
                    element.ItemPicture.IsActive = false;
                    this.Collect(element);
                }
            }
        }

        private bool CollidesWithItem(IItem collider)
        {
            if ((this.Position.X + this.BoundingBox.Width < collider.BoundingBox.X + collider.BoundingBox.Width
            && this.Position.X > collider.BoundingBox.X) 
            || ((this.Position.X + this.BoundingBox.Width > collider.BoundingBox.X) &&
                (this.Position.X + this.BoundingBox.Width < collider.BoundingBox.X + collider.BoundingBox.Width)))
            {
                return true;
            }

            return false;
        }

        public void Collect(IItem item)
        {
            this.CollectedItems.Add(item);

            IncreaseCollectedItemCounter(item);
        }

        private void IncreaseCollectedItemCounter(IItem item)
        {
            if (item is Stomper)
            {
                Stomper.Counter++;

                if (Stomper.Counter == 2)
                {
                    this.Health = MaxHealth;
                    Stomper.Counter = 0;
                }
            }
            else if (item is GiantArmour)
            {
                GiantArmour.Counter++;

                if (GiantArmour.Counter == 2)
                {
                    this.Health = MaxHealth;
                    GiantArmour.Counter = 0;
                }
            }
            else if (item is MastermindShield)
            {
                MastermindShield.Counter++;

                if (MastermindShield.Counter == 2)
                {
                    this.Health = MaxHealth;
                    MastermindShield.Counter = 0;
                }
            }
        }

        protected override void OnHit()
        {
            base.OnHit();
            if(this.ObjectAttacked.Health == 0)
            {
                this.AddExperience((this.ObjectAttacked as Enemy).Experience);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (var element in this.CollectedItems)
            {
                element.Update(gameTime);
            }
        }

        public override void DrawAnimations(SpriteBatch spriteBatch)
        {
            foreach (var element in this.CollectedItems)
            {
                Point2D beginningOfTheMenu = new Point2D(
                    Orus.Instance.Camera.Center.X + element.ItemPicture.Texture.Texture.Width,
                    Orus.Instance.Camera.Center.Y + element.ItemPicture.Texture.Texture.Height / 2);
                element.DrawOnTheGameMenu(spriteBatch, beginningOfTheMenu);
            }
            base.DrawAnimations(spriteBatch);
            if (!Orus.Instance.GameMenu.CharacterSelectionInProgress)
            {
                this.DrawExperienceBar(spriteBatch);
            }
        }

        private void DrawExperienceBar(SpriteBatch spriteBatch)
        {
            //The gray part 

            spriteBatch.Draw(this.Bar.Texture.Texture,
                new Vector2(Orus.Instance.Camera.Center.X + Constant.ExperiencePositionX,
                Orus.Instance.Camera.Center.Y + Constant.ExperiencePositionY),
                new Rectangle(0, 12, this.Bar.Texture.Texture.Width, 8), Color.Gray);

            //The purple experience

            double experienceInPercentage = ((double)this.Experience / this.Levels[this.CurrentLevel]) * 100;
            spriteBatch.Draw(this.Bar.Texture.Texture,
                new Rectangle(
                (int)Orus.Instance.Camera.Center.X + (int)(Constant.ExperiencePositionX),
                (int)Orus.Instance.Camera.Center.Y + (int)(Constant.ExperiencePositionY),
                (int)(this.Bar.Texture.Texture.Width * (experienceInPercentage / 100)), 8),
                 new Rectangle(0, 12, this.Bar.Texture.Texture.Width, 11), Color.Purple);

            //The border

            spriteBatch.Draw(this.Bar.Texture.Texture,
               new Vector2(Orus.Instance.Camera.Center.X + Constant.ExperiencePositionX,
                Orus.Instance.Camera.Center.Y + Constant.ExperiencePositionY),
               new Rectangle(0, 0, this.Bar.Texture.Texture.Width, 11), Color.White);
        }

        private void AddExperience(int experience)
        {
            if(this.CurrentLevel < this.Levels.Count)
            {
                this.Experience += experience;
                if(this.Experience >= this.Levels[this.CurrentLevel - 1])
                {
                    this.CurrentLevel++;
                    this.OnLevelUp();
                }
            }
        }

        private void OnLevelUp()
        {
            this.AttackDamage += this.DamageOnLevelUp;
            this.MaxHealth += this.HealthOnLevelUp;
            this.Health = this.MaxHealth;
        }
    }
}
