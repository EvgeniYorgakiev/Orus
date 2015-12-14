using Orus.Sprites.Animations;

namespace Orus.Interfaces
{
    interface IIddle
    {
        FrameAnimation IddleAnimation { get; set; }
        string IddleAnimationPath { get; set; }
    }
}
