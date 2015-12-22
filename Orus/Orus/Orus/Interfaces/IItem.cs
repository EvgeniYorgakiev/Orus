using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.GameObjects;
using Orus.GameObjects.Sprites;

namespace Orus.Interfaces
{
    public interface IItem
    {
        Sprite ItemPicture { get; set; }

        void DrawOnTheField(SpriteBatch spriteBatch);

        void Update(GameTime gameTime);

        void DrawOnTheGameMenu(SpriteBatch spriteBatch, Point2D cameraPoint);

        Rectangle2D BoundingBox { get; set; }

        bool IsCollectedByCharacter { get; set; }

        int NumberOfCollection { get; set; }

    }
}
