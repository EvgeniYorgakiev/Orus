using Orus.GameObjects.Enemies;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.GameObjects;
using Orus.GameObjects.Enemies.NormalEnemies;
using Orus.Sprites;

namespace Orus.Levels
{
    public class Level
    {
        private Sprite levelBackground;
        private List<Sprite> decor;
        private Sprite crypt;
        private bool spawnedEnemies = false;
                     
        private List<Enemy> enemies;

        public Level(int level, ContentManager content)
        {
            this.Enemies = new List<Enemy>();
            this.Decor = new List<Sprite>();
            CreateLevel(level, content);
        }

        private void CreateLevel(int level, ContentManager content)
        {
            switch (level)
            {
                case 1:
                    {
                        this.LevelBackground = new Sprite(content.Load<Texture2D>("Sprites\\Background\\Level1Background"), new Point2D(0, 0));

                        this.Decor.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\BigTree"), new Point2D(100, 50)));
                        this.Decor.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\BigTree"), new Point2D(500, 100)));
                        this.Decor.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\BigTree"), new Point2D(900, 75)));
                        this.Decor.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\BigTree"), new Point2D(1300, 100)));


                        this.Decor.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\SmallTree"), new Point2D(350, 75)));
                        this.Decor.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\SmallTree"), new Point2D(800, 55)));
                        this.Decor.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\SmallTree"), new Point2D(650, 90)));
                        this.Decor.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\SmallTree"), new Point2D(1100, 40)));
                        this.Decor.Add(new Sprite(content.Load<Texture2D>("Sprites\\Background\\SmallTree"), new Point2D(1500, 55)));
                        
                        this.Crypt = new Sprite(content.Load<Texture2D>("Sprites\\Background\\Crypt"), new Point2D(1100, 115));
                        
                        this.Enemies.Add(new Zombie(new Point2D(1100, 300), Orus.Instance.Content));
                        this.Enemies.Add(new Zombie(new Point2D(1250, 300), Orus.Instance.Content));
                        this.Enemies.Add(new Zombie(new Point2D(1300, 300), Orus.Instance.Content));
                        this.Enemies.Add(new Zombie(new Point2D(1400, 300), Orus.Instance.Content));

                        break;
                    }
            }
            this.LevelBackground.IsActive = true;
            this.Crypt.IsActive = true;
            foreach (var item in this.Decor)
            {
                item.IsActive = true;
            }
            foreach (var item in this.Decor)
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

        public List<Sprite> Decor
        {
            get
            {
                return this.decor;
            }
            set
            {
                this.decor = value;
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

        public bool SpawnedEnemies
        {
            get
            {
                return this.spawnedEnemies;
            }
            set
            {
                this.spawnedEnemies = value;
            }
        }

        public void SpawnNewEnemies(int requiredX)
        {
            if (!this.SpawnedEnemies && requiredX < Orus.Instance.Character.Position.X)
            {
                switch (Orus.Instance.CurrentLevelIndex)
                {
                    case 0:
                        {
                            this.Enemies.Add(new Zombie(new Point2D(300, 300), Orus.Instance.Content));
                            break;
                        }
                }
                this.SpawnedEnemies = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.LevelBackground.Draw(spriteBatch);
            this.Crypt.Draw(spriteBatch);
            foreach (var item in this.Decor)
            {
                item.Draw(spriteBatch);
            }
            foreach (var item in this.Decor)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
