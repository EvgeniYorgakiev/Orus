using Orus.Animations;
using Orus.GameObjects;
using System.Collections.Generic;

namespace Orus.Interfaces
{
    interface IAttack
    {
        int AttackDamage { get; set; }
        FrameAnimation AttackAnimation { get; set; }
        string AttackAnimationPath { get; set; }
        void Attack(List<AnimatedGameObject> gameObjects);
    }
}
