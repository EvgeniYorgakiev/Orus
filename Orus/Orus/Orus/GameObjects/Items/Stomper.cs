using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Sprites;
using Orus.Sprites.Animations;

namespace Orus.GameObjects.Items
{
    class Stomper : Item
    {
        public const float MovingDistanceStomper = 70;

        public Stomper(string name, Point2D position, ContentManager content) : base(name, position, content)
        {
            this.ItemPicture = new Sprite(content.Load<Texture2D>("Sprites\\Items\\The_Stomper"), position);
            this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.ItemPicture.Texture.Width, this.ItemPicture.Texture.Height);

        }

        public override Rectangle BoundingBox { get; set; }
    }
}
