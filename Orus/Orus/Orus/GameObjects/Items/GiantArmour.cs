using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Sprites;
using Orus.Sprites.Animations;

namespace Orus.GameObjects.Items
{
    class GiantArmour : Item
    {
        public GiantArmour(string name, Point2D position, ContentManager content) : base(name, position, content)
        {
            this.ItemPicture = new Sprite(content.Load<Texture2D>("Sprites\\Items\\Fireborn_Giant_Armor"), position);
            this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.ItemPicture.Texture.Width, this.ItemPicture.Texture.Height);
            this.NumberOfCollection = Item.Counter;
        }

        public override Rectangle BoundingBox { get; set; }

        public static int Counter { get; set; }


        public override void DrawOnTheGameMenu(SpriteBatch spriteBatch, Point2D cameraPoint, GameTime gameTime)
        {
            if (this.IsCollectedByCharacter)
            {
                this.ItemPicture.Position = new Point2D(cameraPoint.X + this.ItemPicture.Texture.Width * (this.NumberOfCollection), cameraPoint.Y);
                this.ItemPicture.IsActive = true;
                this.BoundingBox = new Rectangle((int)this.ItemPicture.Position.X, (int)this.ItemPicture.Position.Y,
                    this.ItemPicture.Texture.Width, this.ItemPicture.Texture.Height);
                this.ItemPicture.Draw(spriteBatch);
            }
        }
    }
}
