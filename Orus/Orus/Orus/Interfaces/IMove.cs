using Microsoft.Xna.Framework;
using Orus.Sprites.Animations;

namespace Orus.Interfaces
{
    interface IMove
    {
        FrameAnimation MoveAnimation { get; set; }
        string MoveAnimationPath { get; set; }
        void Move(GameTime gameTime, bool directionIsRight, bool collides);
        float MoveSpeed { get; set; }
    }
}
