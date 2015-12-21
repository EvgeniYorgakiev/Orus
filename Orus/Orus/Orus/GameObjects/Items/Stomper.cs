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
using Orus.Texts;
using Orus.Sprites;
using Orus.Sprites.Animations;

namespace Orus.GameObjects.Items
{
    class Stomper : Item
    {
        public Stomper()
        {

        }

        public Stomper(string name, Point2D position, ContentManager content) : base(name, position, content)
        {
            this.ItemPicture = new Sprite("Sprites\\Items\\The_Stomper", position);
            this.BoundingBox = new Rectangle2D((int)this.Position.X, (int)this.Position.Y, this.ItemPicture.Texture.Texture.Width, this.ItemPicture.Texture.Texture.Height);

        }

        public override Rectangle2D BoundingBox { get; set; }

        public static int Counter { get; set; }

        //This draws the item on the collected items' menu when the item is collected by the character.
        public override void DrawOnTheGameMenu(SpriteBatch spriteBatch, Point2D cameraPoint)
        {
            if (this.IsCollectedByCharacter)
            {
                this.ItemPicture.Position = new Point2D(cameraPoint.X + this.ItemPicture.Texture.Texture.Width, cameraPoint.Y);
                this.ItemPicture.IsActive = true;
                this.BoundingBox = new Rectangle2D((int)this.ItemPicture.Position.X, (int)this.ItemPicture.Position.Y,
                    this.ItemPicture.Texture.Texture.Width, this.ItemPicture.Texture.Texture.Height);
                base.DrawOnTheGameMenu(spriteBatch, cameraPoint);
            }
        }
    }
}
