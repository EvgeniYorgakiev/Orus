﻿using Orus.GameObjects;
using Orus.GameObjects.Sprites.Animations;
using System.Collections.Generic;

namespace Orus.Interfaces
{
    interface IAttack
    {
        int AttackDamage { get; set; }
        int AttackRange { get; set; }
        FrameAnimation AttackAnimation { get; set; }
        void Attack(List<AttackingGameObject> gameObjects);
    }
}
