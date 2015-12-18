using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Orus.GameObjects;
using Orus.GameObjects.Enemies;
using Orus.GameObjects.Enemies.NormalEnemies;
using Orus.GameObjects.Items;
using Orus.Interfaces;
using Orus.Sprites.Animations;

namespace Orus
{
    class ItemFactory
    {
        public const float MovingDistanceArmour = 50;
        public const float MovingDistanceStomper = 70;

        //Generate new item on the field.

        public static void ProduceItemInField (FrameAnimation enemyAnimation, Enemy enemy, ICollection<IItem> visibleItems)
        {
            Point2D itemPosition = new Point2D(0, 0);

            if (enemy is Zombie)
            {
                if (enemyAnimation.SpriteEffect == SpriteEffects.None)
                {
                    itemPosition = new Point2D(enemyAnimation.Position.X, enemyAnimation.Position.Y + MovingDistanceStomper);
                }
                else
                {
                    itemPosition = new Point2D(enemyAnimation.Position.X + 100, enemyAnimation.Position.Y + MovingDistanceStomper);
                }

                visibleItems.Add(new Stomper("Stomper", itemPosition, Orus.Instance.Content));

            }
            else if (enemy is Skeleton)
            {

                if (enemyAnimation.SpriteEffect == SpriteEffects.None)
                {
                    itemPosition = new Point2D(enemyAnimation.Position.X, enemyAnimation.Position.Y + MovingDistanceArmour);
                }
                else
                {
                    itemPosition = new Point2D(enemyAnimation.Position.X + 100, enemyAnimation.Position.Y + MovingDistanceArmour);
                }

                visibleItems.Add(new GiantArmour("GiantArmour", itemPosition, Orus.Instance.Content));
            }

        }
    }
}
