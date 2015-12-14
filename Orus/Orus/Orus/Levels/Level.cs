using Orus.Animations;
using Orus.GameObjects.Enemies;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.GameObjects;
using Orus.GameObjects.Enemies.NormalEnemies;

namespace Orus.Levels
{
    public class Level
    {
        private Sprite levelBackground;
        private List<Sprite> bigTree;
        private List<Sprite> smallTree;
        private Sprite crypt;
        private List<Enemy> enemies;

        public Level(int level, ContentManager content)
        {
            this.Enemies = new List<Enemy>();
            CreateLevel(level, content);
        }

        private void CreateLevel(int level, ContentManager content)
        {
            this.SmallTree = new List<Sprite>();
            this.BigTree = new List<Sprite>();
            switch (level)
            {
                case 1:
                    {
                        this.LevelBackground = new Sprite(content.Load<Texture2D>("Sprites\\Background\\Level1Background"), new Point2D(0, 0));

                        this.BigTree.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\BigTree"), new Point2D(100, 50)));
                        this.BigTree.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\BigTree"), new Point2D(500, 100)));
                        this.BigTree.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\BigTree"), new Point2D(900, 75)));
                        this.BigTree.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\BigTree"), new Point2D(1300, 100)));


                        this.SmallTree.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\SmallTree"), new Point2D(350, 75)));
                        this.SmallTree.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\SmallTree"), new Point2D(800, 55)));
                        this.SmallTree.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\SmallTree"), new Point2D(650, 90)));
                        this.SmallTree.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\SmallTree"), new Point2D(1100, 40)));
                        this.SmallTree.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\SmallTree"), new Point2D(1500, 55)));

                        this.Enemies.Add(new Zombie(new Point2D(300, 300), Orus.Instance.Content));
                        this.Crypt = new Sprite(content.Load<Texture2D>("Sprites\\Background\\Crypt"), new Point2D(1100, 115));

                        break;
                    }
            }
            this.LevelBackground.IsActive = true;
            this.Crypt.IsActive = true;
            foreach (var item in BigTree)
            {
                item.IsActive = true;
            }
            foreach (var item in SmallTree)
            {
                item.IsActive = true;
            }
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
        public Sprite Crypt
        {
            get
            {
                return this.crypt;
            }
            set
            {
                this.crypt = value;
            }
        }
        public List<Sprite> BigTree
        {
            get
            {
                return this.bigTree;
            }
            set
            {
                this.bigTree = value;
            }
        }
        public List<Sprite> SmallTree
        {
            get
            {
                return this.smallTree;
            }
            set
            {
                this.smallTree = value;
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
