using Orus.GameObjects.Player.Characters;
using Microsoft.Xna.Framework;
using Orus.GameObjects;
using System.Collections.Generic;

namespace Orus.Abilities
{
    public abstract class AttackAbility : Ability
    {
        private float timeForAttack;
        private float timeAttacking;
        private bool isAttacking = false;
        private List<AttackableGameObject> affectedTargets;
        private const DamageType damageType = DamageType.Physical;

        public AttackAbility()
        {

        }

        public AttackAbility(int damage, int cooldown, float timeForAttack, string pathForAnimation, int framesForAnimation)
            : base(damage, cooldown, pathForAnimation, framesForAnimation, damageType)
        {
            this.TimeForAttack = timeForAttack;
            this.AffectedTargets = new List<AttackableGameObject>();
        }

        public float TimeForAttack
        {
            get
            {
                return this.timeForAttack;
            }
            set
            {
                this.timeForAttack = value;
            }
        }

        public float TimeAttacking
        {
            get
            {
                return this.timeAttacking;
            }
            set
            {
                this.timeAttacking = value;
            }
        }

        public bool IsAttacking
        {
            get
            {
                return this.isAttacking;
            }
            set
            {
                this.isAttacking = value;
            }
        }

        public List<AttackableGameObject> AffectedTargets
        {
            get
            {
                return this.affectedTargets;
            }
            set
            {
                this.affectedTargets = value;
            }
        }

        public abstract void UpdateAffectedTargets(AttackableGameObject thisObject);

        public override void Update(GameTime gameTime, AttackableGameObject objectUsingAbility)
        {
            if (IsOnCooldown)
            {
                base.Update(gameTime, objectUsingAbility);
                if (this.IsAttacking)
                {
                    this.TimeAttacking += gameTime.ElapsedGameTime.Milliseconds / 1000;
                    if (TimeAttacking >= TimeForAttack)
                    {
                        BattleEngine.DamageResolution(this);
                        this.IsAttacking = false;
                    }
                }
            }
        }

        public override void Action(Character character)
        {
            base.Action(character);
        }
    }
}
