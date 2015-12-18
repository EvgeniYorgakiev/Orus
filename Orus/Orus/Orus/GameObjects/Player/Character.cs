using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Orus.GameObjects.Items;
using Orus.Interfaces;
using Orus.Sprites;

namespace Orus.GameObjects.Player.Characters
{
    public abstract class Character : AttackableGameObject, ICollectItems
    {
        protected Character()
        {

        }

        protected Character(string name, Point2D position, Rectangle2D boundingBox, float moveSpeed,
            int health, int armor, int fireResistance, int lightingResistance, int arcaneResistance, int iceResistance,
            int attackDamage, int attackRange, float timeUntilDamageSinceAttack)
            : base(name, position, boundingBox, moveSpeed, health, armor, fireResistance, lightingResistance, arcaneResistance, iceResistance,
                  attackDamage, attackRange, timeUntilDamageSinceAttack)
        {
            this.CollectedItems = new List<IItem>();
        }

        public ICollection<IItem> CollectedItems { get; set; }

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
    }
}
