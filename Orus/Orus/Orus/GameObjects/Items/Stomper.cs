using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Sprites;

namespace Orus.GameObjects.Items
{
    class Stomper : Item
    {
        private Sprite stomperPicture;

        public Stomper(string name, Point2D position, ContentManager content) : base(name, position)
        {
            stomperPicture = new Sprite(content.Load<Texture2D>("Sprites\\Items\\The_Stomper"), position);
        }

        public static void ItemAppear(Point2D position)
        {
            Item.VisibleItems.Add(new Stomper("Stomper", position, Orus.Instance.Content));

        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            stomperPicture.IsActive = true;
            stomperPicture.Draw(spriteBatch);
        }
    }
}
