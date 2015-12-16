using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Sprites;

namespace Orus.GameObjects.Items
{
    class Stomper : Item
    {

        public Stomper(string name, Point2D position, ContentManager content) : base(name, position, content)
        {
            this.ItemPicture = new Sprite(content.Load<Texture2D>("Sprites\\Items\\The_Stomper"), position);
        }

        public static void ItemAppear(Point2D position)
        {
            Item.VisibleItems.Add(new Stomper("Stomper", position, Orus.Instance.Content));

        }


    }
}
