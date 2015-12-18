using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.InputHandler;
using Orus.Sprites;

namespace Orus.GameObjects.Items
{
    class MastermindShield : Item
    {
        public MastermindShield(string name, Point2D position, ContentManager content) : base(name, position, content)
        {
            this.ItemPicture = new Sprite(content.Load<Texture2D>("Sprites\\Items\\Mastermind_Shield"), position);
            this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.ItemPicture.Texture.Width, this.ItemPicture.Texture.Height);
            this.NumberOfCollection = MastermindShield.Counter;
        }

        public override Rectangle BoundingBox { get; set; }

        public static int Counter { get; set; }

        public Text InventoryCounterText { get; set; }

        public override void DrawOnTheGameMenu(SpriteBatch spriteBatch, Point2D cameraPoint, GameTime gameTime)
        {
            if (this.IsCollectedByCharacter)
            {
                this.ItemPicture.Position = new Point2D(cameraPoint.X + 3 * this.ItemPicture.Texture.Width, cameraPoint.Y);
                this.ItemPicture.IsActive = true;
                this.BoundingBox = new Rectangle((int)this.ItemPicture.Position.X, (int)this.ItemPicture.Position.Y,
                    this.ItemPicture.Texture.Width, this.ItemPicture.Texture.Height);
                this.ItemPicture.Draw(spriteBatch);

                string counter = String.Format("{0}", Stomper.Counter);
                InventoryCounterText = new Text(counter, false, (int)this.ItemPicture.Position.X - 20, (int)this.ItemPicture.Position.Y - 20, 1, 1, 0, Color.Brown, true, Orus.Instance.NameFont);
                InventoryCounterText.Update(gameTime, false);
                InventoryCounterText.Draw(spriteBatch);
            }
        }
    }
}
