using Orus.Animations;
namespace Orus.Interfaces
{
    interface IDeath
    {
        FrameAnimation DeathAnimation { get; set; }
        string DeathAnimationPath { get; set; }
    }
}
