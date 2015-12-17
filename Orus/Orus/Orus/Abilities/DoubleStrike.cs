using Orus.GameObjects.Player.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orus.GameObjects;
using Microsoft.Xna.Framework.Graphics;

namespace Orus.Abilities
{
    public class DoubleStrike : AttackAbility
    {
        public DoubleStrike(int damage, string pathForAnimation, int framesForAnimation)
            : base(damage, 20, 0.8f, pathForAnimation, framesForAnimation)
        {

        }

        public override void UpdateAffectedTargets(AttackableGameObject thisObject)
        {
            foreach (var enemy in Orus.Instance.Levels[Orus.Instance.CurrentLevelIndex].Enemies)
            {
                if (thisObject.CollidesForAttack(enemy,
                    !thisObject.IddleAnimation.SpriteEffect.HasFlag(SpriteEffects.FlipHorizontally)))
                {
                    this.AffectedTargets.Add(enemy);
                }
            }
        }

        public override void Action(Character character)
        {
            base.Action(character);
        }
    }
}
