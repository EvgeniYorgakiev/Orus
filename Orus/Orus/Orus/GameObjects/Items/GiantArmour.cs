using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.InputHandler;
using Orus.Sprites;
using Orus.Sprites.Animations;
using Orus.Constants;

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

        public Text InventoryCounterText { get; set; }

        public override void DrawOnTheGameMenu(SpriteBatch spriteBatch, Point2D cameraPoint, GameTime gameTime)
        {
            if (this.IsCollectedByCharacter)
            {
                this.ItemPicture.Position = new Point2D(cameraPoint.X + 2*this.ItemPicture.Texture.Texture.Width, cameraPoint.Y);
                this.ItemPicture.IsActive = true;
                this.BoundingBox = new Rectangle2D((int)this.ItemPicture.Position.X, (int)this.ItemPicture.Position.Y,
                    this.ItemPicture.Texture.Texture.Width, this.ItemPicture.Texture.Texture.Height);
                this.ItemPicture.Draw(spriteBatch);

                string counter = String.Format("{0}", Stomper.Counter);
                InventoryCounterText = new Text(counter, false, (int)this.ItemPicture.Position.X - 20, (int)this.ItemPicture.Position.Y - 20, 1, 1, 0, Color.Brown, false, Constant.NameFontPath);
                InventoryCounterText.Update(gameTime, false);
                InventoryCounterText.Draw(spriteBatch);
            }
        }
    }
}
