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

        public abstract void DrawOnTheGameMenu(SpriteBatch spriteBatch, Point2D cameraPoint, GameTime gameTime);


        public abstract Rectangle2D BoundingBox { get; set; }

    }
}
