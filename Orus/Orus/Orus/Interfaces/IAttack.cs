using Orus.Animations;
namespace Orus.Interfaces
{
    interface IAttack
    {
        FrameAnimation AttackAnimation { get; set; }
        string AttackAnimationPath { get; set; }
        void Attack();
    }
}
