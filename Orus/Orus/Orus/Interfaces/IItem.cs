using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Orus.GameObjects;
using Orus.Sprites;

namespace Orus.Interfaces
{
    public interface IItem
    {
        Sprite ItemPicture { get; set; }

        void Draw(SpriteBatch spriteBatch);

        bool CollidesWithCharacter(AnimatedGameObject collider, bool isMovingRight, int additionalXOffset = 0);

        bool IsCollectedByCharacter { get; set; }

        void Update();
    }
}
