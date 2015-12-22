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
        private bool abilityFinished = false;
        private HashSet<AttackableGameObject> affectedTargets;
        private const DamageType damageType = DamageType.Physical;

        public AttackAbility()
        {

        }

        public AttackAbility(int damage, int cooldown, float timeForAttack, string pathForAnimation, int framesForAnimation)
            : base(damage, cooldown, pathForAnimation, framesForAnimation, damageType)
        {
            this.TimeForAttack = timeForAttack;
            this.AffectedTargets = new HashSet<AttackableGameObject>();
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

        private bool AbilityFinished
        {
            get
            {
                return this.abilityFinished;
            }
            set
            {
                this.abilityFinished = value;
            }
        }

        public HashSet<AttackableGameObject> AffectedTargets
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

        protected abstract void UpdateAffectedTargets(AttackableGameObject thisObject);

        public override void Update(GameTime gameTime, AttackableGameObject objectUsingAbility)
        {
            if (this.IsOnCooldown)
            {
                if (!this.Animation.IsActive)
                {
                    if (!this.AbilityFinished)
                    {
                        BattleEngine.DamageResolution(this);
                        this.AbilityFinished = true;
                    }
                    objectUsingAbility.IsUsingAbility = false;
                }
                this.TimeSinceUse += gameTime.ElapsedGameTime.Milliseconds / 1000;
                if (this.TimeSinceUse >= this.CooldownTime)
                {
                    this.AbilityFinished = false;
                    this.IsOnCooldown = false;
                }
                this.Animation.Animate(gameTime, objectUsingAbility);
            }
        }

        public override void Action(Character character)
        {
            character.AbilityInUse = this;
            base.Action(character);
        }
    }
}
