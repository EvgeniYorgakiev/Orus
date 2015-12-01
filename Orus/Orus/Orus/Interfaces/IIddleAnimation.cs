using Orus.Animations;
namespace Orus.Interfaces
{
    interface IIddleAnimation
    {
        FrameAnimation IddleAnimation { get; set; }
        string IddleAnimationPath { get; set; }
    }
}
