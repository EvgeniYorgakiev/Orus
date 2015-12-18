using Orus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Orus.Levels;
using Orus.Sprites;

namespace Orus.GameObjects.InteractiveBackgrounds
{
    public class LevelChanger : ColliderObjects, IInteractable
    {
        private int newLevelIndex;

        public LevelChanger()
        {

        }

        public LevelChanger(string name, Point2D position, Rectangle2D boundingBox, int newLevelIndex)
            : base(name, position)
        {
            this.NewLevelIndex = newLevelIndex;
            this.BoundingBox = boundingBox;
        }

        public int NewLevelIndex
        {
            get
            {
                return this.newLevelIndex;
            }

            set
            {
                this.newLevelIndex = value;
            }
        }

        public void Interact()
        {
            Level.Load(this.NewLevelIndex);
        }
    }
}
