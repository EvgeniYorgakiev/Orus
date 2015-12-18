using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.InputHandler;
using Orus.Sprites;
using Orus.Sprites.Animations;

namespace Orus.GameObjects.Items
{
    class Stomper : Item
    {
        public Stomper(string name, Point2D position, ContentManager content) : base(name, position, content)
        {
            this.ItemPicture = new Sprite(content.Load<Texture2D>("Sprites\\Items\\The_Stomper"), position);
            this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.ItemPicture.Texture.Width, this.ItemPicture.Texture.Height);

        }

        public override Rectangle BoundingBox { get; set; }

        public Text InventoryCounterText { get; set; }

        public static int Counter { get; set; }


        public override void DrawOnTheGameMenu(SpriteBatch spriteBatch, Point2D cameraPoint, GameTime gameTime)
        {
            if (this.IsCollectedByCharacter)
            {
                this.ItemPicture.Position = new Point2D(cameraPoint.X + this.ItemPicture.Texture.Width, cameraPoint.Y);
                this.ItemPicture.IsActive = true;
                this.BoundingBox = new Rectangle((int)this.ItemPicture.Position.X, (int)this.ItemPicture.Position.Y,
                    this.ItemPicture.Texture.Width, this.ItemPicture.Texture.Height);
                this.ItemPicture.Draw(spriteBatch);

                string counter = String.Format("{0}", Stomper.Counter);
                InventoryCounterText = new Text(counter, false, (int)this.ItemPicture.Position.X - 20, (int)this.ItemPicture.Position.Y - 20, 1, 1, 0, Color.DarkSlateGray, true, Orus.Instance.NameFont);
                InventoryCounterText.Update(gameTime, false);
                InventoryCounterText.Draw(spriteBatch);
            }
        }
    }
}
