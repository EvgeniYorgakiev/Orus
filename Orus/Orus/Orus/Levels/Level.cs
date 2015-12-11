using Orus.Animations;
using Orus.GameObjects.Enemies;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.GameObjects;

namespace Orus.Levels
{
    public class Level
    {
        private Sprite levelBackground;
        private List<Enemy> enemies;

        public Level(int level, ContentManager content)
        {
            CreateLevel(level, content);
        }

        private void CreateLevel(int level, ContentManager content)
        {
            switch (level)
            {
                case 1:
                    {
                        this.LevelBackground = new Sprite(content.Load<Texture2D>("Sprites\\Background\\Level1Background"), new Point2D(0, 0));
                        break;
                    }
            }
            this.LevelBackground.IsActive = true;
        }

        public Sprite LevelBackground
        {
            get
            {
                return this.levelBackground;
            }
            set
            {
                this.levelBackground = value;
            }
        }

        public List<Enemy> Enemies
        {
            get
            {
                return this.enemies;
            }
            set
            {
                this.enemies = value;
            }
        }
    }
}
