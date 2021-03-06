﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.GameObjects.Sprites;

namespace Orus.GameObjects.Items
{
    class GiantArmour : Item
    {
        public GiantArmour()
        {

        }

        public GiantArmour(string name, Point2D position, ContentManager content) : base(name, position, content)
        {
            this.ItemPicture = new Sprite("Sprites\\Items\\Fireborn_Giant_Armor", position);
            this.BoundingBox = new Rectangle2D((int)this.Position.X, (int)this.Position.Y, this.ItemPicture.Texture.Texture.Width, this.ItemPicture.Texture.Texture.Height);
        }

        public override Rectangle2D BoundingBox { get; set; }

        public static int Counter { get; set; }

        //This draws the item on the collected items' menu when the item is collected by the character.
        public override void DrawOnTheGameMenu(SpriteBatch spriteBatch, Point2D cameraPoint)
        {
            if (this.IsCollectedByCharacter)
            {
                this.ItemPicture.Position = new Point2D(cameraPoint.X + 2*this.ItemPicture.Texture.Texture.Width, cameraPoint.Y);
                this.ItemPicture.IsActive = true;
                this.BoundingBox = new Rectangle2D((int)this.ItemPicture.Position.X, (int)this.ItemPicture.Position.Y,
                    this.ItemPicture.Texture.Texture.Width, this.ItemPicture.Texture.Texture.Height);
                base.DrawOnTheGameMenu(spriteBatch, cameraPoint);
            }
        }
    }
}
