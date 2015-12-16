using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Orus.Interfaces;
using Orus.Sprites;

namespace Orus.GameObjects.Items
{
    public abstract class Item : GameObject, IItem
    {
        private static ICollection<IItem> visibleItems;



        static Item()
        {
            Item.VisibleItems = new List<IItem>();

        }

        protected Item(string name, Point2D position) : base(name, position)
        {
        }


        public Sprite ItemPicture { get; set; }

        public static ICollection<IItem> VisibleItems
        {
            get { return Item.visibleItems; }
            set { Item.visibleItems = value; }
        }



        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
