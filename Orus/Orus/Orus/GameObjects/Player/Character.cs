using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Orus.GameObjects.Items;
using Orus.Interfaces;

namespace Orus.GameObjects.Player.Characters
{
    public abstract class Character : AttackableGameObject, ICollectItems
    {
        protected Character(string name, Point2D position, Rectangle boundingBox, float moveSpeed,
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
        }
    }
}
