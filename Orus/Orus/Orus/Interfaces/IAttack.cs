using Orus.GameObjects;
using Orus.Sprites.Animations;
using System.Collections.Generic;

namespace Orus.Interfaces
{
    interface IAttack
    {
        int AttackDamage { get; set; }
        int AttackRange { get; set; }
        FrameAnimation AttackAnimation { get; set; }
        string AttackAnimationPath { get; set; }
        void Attack(List<AnimatedGameObject> gameObjects);
    }
}
