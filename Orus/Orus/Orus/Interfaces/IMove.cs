﻿using Microsoft.Xna.Framework;
using Orus.GameObjects.Sprites.Animations;

namespace Orus.Interfaces
{
    interface IMove
    {
        FrameAnimation MoveAnimation { get; set; }
        void Move(int distance, bool directionIsRight, bool collides);
        float MoveSpeed { get; set; }
    }
}
