﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Sprites;

namespace Orus.GameObjects.Items
{
    class MastermindShield : Item
    {
        public MastermindShield(string name, Point2D position, ContentManager content) : base(name, position, content)
        {
            this.ItemPicture = new Sprite(content.Load<Texture2D>("Sprites\\Items\\Mastermind_Shield"), position);
        }


        public static void ItemAppear(Point2D position)
        {
            Item.VisibleItems.Add(new MastermindShield("MastermindShield", position, Orus.Instance.Content));
        }
    }
}