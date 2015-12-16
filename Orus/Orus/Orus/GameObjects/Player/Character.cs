using System.Collections.Generic;
using Microsoft.Xna.Framework;
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

        }

        public ICollection<IItem> CollectedItems { get; set; }

        public void Collect(IItem item)
        {
            this.CollectedItems.Add(item);
        }
    }
}
