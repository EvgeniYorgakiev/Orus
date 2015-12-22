using Orus.Abilities;
using Orus.GameObjects;
using Orus.GameObjects.Player.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus
{
    public static class BattleEngine
    {
        private static Dictionary<DamageType, string> DamageTypesAndResistances = new Dictionary<DamageType, string>
        {
            {DamageType.Physical, "ArmorAsPercentage" },
            {DamageType.Arcane, "ArcaneResistance" },
            {DamageType.Fire, "FireResistance" },
            {DamageType.Ice, "IceResistance" },
            {DamageType.Lighting, "LightingResistance" }
        };

        public static void DamageResolution(AttackAbility attackAbility)
        {
            string resistanceType = DamageTypesAndResistances[attackAbility.DamageType];

            foreach (var affectedTarget in attackAbility.AffectedTargets)
            {
                var resistanceAmount = (double)(affectedTarget
                    .GetType()
                    .GetProperty(resistanceType)
                    .GetValue(affectedTarget, null));

                affectedTarget.Health -= (int)(attackAbility.Damage -
                    (attackAbility.Damage * resistanceAmount));
            }
        }
    }
}
