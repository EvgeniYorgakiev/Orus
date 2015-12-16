using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Interfaces;
using Orus.Sprites;

namespace Orus.GameObjects.Items
{
    public abstract class Item : GameObject, IItem
    {
        private static ICollection<IItem> visibleItems;
        private Rectangle boundingBox;
        private bool isCollectedByCharacter;


        static Item()
        {
            Item.VisibleItems = new List<IItem>();

        }

        protected Item(string name, Point2D position, ContentManager content) : base(name, position)
        {

        }

        public bool IsCollectedByCharacter
        {
            get { return this.isCollectedByCharacter; }
            set { this.isCollectedByCharacter = value; }
        }


        public Sprite ItemPicture { get; set; }

        public static ICollection<IItem> VisibleItems
        {
            get { return Item.visibleItems; }
            set { Item.visibleItems = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!this.IsCollectedByCharacter)
            {
                this.ItemPicture.IsActive = true;
                this.BoundingBox = new Rectangle((int) this.ItemPicture.Position.X, (int) this.ItemPicture.Position.Y,
                    this.ItemPicture.Texture.Width, this.ItemPicture.Texture.Height);
                this.ItemPicture.Draw(spriteBatch);
            }
            else
            {
                this.BoundingBox = new Rectangle(0,0,0,0);
            }

        }



        public Rectangle BoundingBox
        {
            get { return this.boundingBox; }
            set { this.boundingBox = value; }
        }

        public bool CollidesWithCharacter(AnimatedGameObject collider, bool isMovingRight, int additionalXOffset = 0)
        {
            if (isMovingRight)
            {
                if (collider.Position.X + collider.BoundingBox.Width + collider.BoundingBox.Width/2 >
                this.Position.X - additionalXOffset &&
                    collider.Position.X + collider.BoundingBox.Width + collider.BoundingBox.Width/2 < this.Position.X + this.BoundingBox.Width)
                {
                    return true;
                }



            }
            else
            {
                if (collider.Position.X + collider.BoundingBox.Width >
                this.Position.X + additionalXOffset &&
                    collider.Position.X + collider.BoundingBox.Width < this.Position.X + this.BoundingBox.Width)
                {
                    return true;
                }

            }
            return false;
        }

        public void Update()
        {

        }
    }
}
