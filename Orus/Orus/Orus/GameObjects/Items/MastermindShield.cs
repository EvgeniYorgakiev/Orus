using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.GameObjects.Texts;
using Orus.GameObjects.Sprites;
using Orus.Constants;

namespace Orus.GameObjects.Items
{
    class MastermindShield : Item
    {
        public MastermindShield()
        {

        }
        
        public MastermindShield(string name, Point2D position, ContentManager content) : base(name, position, content)
        {
            this.ItemPicture = new Sprite("Sprites\\Items\\Mastermind_Shield", position);
            this.BoundingBox = new Rectangle2D((int)this.Position.X, (int)this.Position.Y, this.ItemPicture.Texture.Texture.Width, this.ItemPicture.Texture.Texture.Height);
            this.NumberOfCollection = MastermindShield.Counter;
        }

        public override Rectangle2D BoundingBox { get; set; }

        public static int Counter { get; set; }

        //This draws the item on the collected items' menu when the item is collected by the character.
        public override void DrawOnTheGameMenu(SpriteBatch spriteBatch, Point2D cameraPoint)
        {
            if (this.IsCollectedByCharacter)
            {
                this.ItemPicture.Position = new Point2D(cameraPoint.X + 3 * this.ItemPicture.Texture.Texture.Width, cameraPoint.Y);
                this.ItemPicture.IsActive = true;
                this.BoundingBox = new Rectangle2D((int)this.ItemPicture.Position.X, (int)this.ItemPicture.Position.Y,
                    this.ItemPicture.Texture.Texture.Width, this.ItemPicture.Texture.Texture.Height);
                base.DrawOnTheGameMenu(spriteBatch, cameraPoint);
            }
        }
    }
}
