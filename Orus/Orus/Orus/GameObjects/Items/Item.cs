﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Interfaces;
using Orus.Sprites;
using Orus.Texts;
using Orus.Constants;

namespace Orus.GameObjects.Items
{
    public abstract class Item : GameObject, IItem
    {
        private Rectangle2D boundingBox;
        private bool isCollectedByCharacter;

        protected Item()
        {

        }

        protected Item(string name, Point2D position, ContentManager content) : base(name, position)
        {
        }

        public bool IsCollectedByCharacter
        {
            get { return this.isCollectedByCharacter; }
            set { this.isCollectedByCharacter = value; }
        }

        public int NumberOfCollection { get; set; }

        public Sprite ItemPicture { get; set; }

        public Text InventoryCounterText { get; set; }

        public void DrawOnTheField(SpriteBatch spriteBatch)
        {
            if (!this.IsCollectedByCharacter)
            {
                this.ItemPicture.IsActive = true;
                this.BoundingBox = new Rectangle2D((int) this.ItemPicture.Position.X, (int) this.ItemPicture.Position.Y,
                    this.ItemPicture.Texture.Texture.Width, this.ItemPicture.Texture.Texture.Height);
                this.ItemPicture.Draw(spriteBatch);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            string counter = String.Format("{0}", Stomper.Counter);
            InventoryCounterText = new Text(counter, false, (int)this.ItemPicture.Position.X - 20, (int)this.ItemPicture.Position.Y - 20, 1, 1, 0, Color.DarkSlateGray, false, Constant.NameFontPath);
            InventoryCounterText.Update(gameTime, false);
       }

        public virtual void DrawOnTheGameMenu(SpriteBatch spriteBatch, Point2D cameraPoint)
        {
            this.ItemPicture.Draw(spriteBatch);
            this.InventoryCounterText.Draw(spriteBatch);
        }

        public abstract Rectangle2D BoundingBox { get; set; }

    }
}
