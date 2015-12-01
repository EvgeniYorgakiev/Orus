using Orus.Animations;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Orus.Player.Characters
{
    public class Crusader : Character
    {
        public Crusader(Vector2 position) : base(position)
        {
            this.IddleAnimationPath = "Sprites\\Crusader\\Crusader iddle";
            this.MoveAnimationPath = "Sprites\\Crusader\\Crusader move";
            this.AttackAnimationPath = "Sprites\\Crusader\\Crusader attack";
        }
    }
}
