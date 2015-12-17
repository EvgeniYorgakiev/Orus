using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Sprites;
using Orus.Sprites.Animations;

namespace Orus.GameObjects.Items
{
    class GiantArmour : Item
    {
        public const float MovingDistanceArmour = 50;

        public GiantArmour(string name, Point2D position, ContentManager content) : base(name, position, content)
        {
            this.ItemPicture = new Sprite(content.Load<Texture2D>("Sprites\\Items\\Fireborn_Giant_Armor"), position);
            this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.ItemPicture.Texture.Width, this.ItemPicture.Texture.Height);
        }

        public static void ItemAppear(Point2D position)
        {
            Item.VisibleItems.Add(new GiantArmour("GiantArmour", position, Orus.Instance.Content));

        }


        public override Rectangle BoundingBox { get; set; }
    }
}
