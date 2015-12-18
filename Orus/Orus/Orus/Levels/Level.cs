﻿using Orus.GameObjects.Enemies;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.GameObjects;
using Orus.GameObjects.Enemies.NormalEnemies;
using Orus.Sprites;
using Orus.Constants;
using Orus.GameObjects.NPC;
using Orus.Interfaces;
using Orus.GameObjects.InteractiveBackgrounds;
using Orus.Quests;
using System.Linq;
using Microsoft.Xna.Framework;
using Orus.GameObjects.Enemies.Boss;

namespace Orus.Levels
{
    public class Level
    {
        private Sprite levelBackground;
        private List<Sprite> decor;
        private int requiredXForEnemySpawn;
        private bool spawnedEnemies = false;
        private List<Enemy> enemies;
        private List<QuestGiver> questGivers;
        private List<IInteractable> interactives;
        private Point2D lastCharacterCoordinates;

        public Level()
        {

        }

        public Level(int level, ContentManager content)
        {
            this.Enemies = new List<Enemy>();
            this.Decor = new List<Sprite>();
            this.QuestGivers = new List<QuestGiver>();
            this.Interactives = new List<IInteractable>();
            this.LastCharacterCoordinates = new Point2D(Constant.StartingPlayerXPosition, Constant.StartingPlayerYPosition);
            CreateLevel(level, content);
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

        public int RequiredXForEnemySpawn
        {
            get
            {
                return this.requiredXForEnemySpawn;
            }
            set
            {
                this.requiredXForEnemySpawn = value;
            }
        }

        public List<QuestGiver> QuestGivers
        {
            get
            {
                return this.questGivers;
            }
            set
            {
                this.questGivers = value;
            }
        }

        public List<IInteractable> Interactives
        {
            get
            {
                return this.interactives;
            }
            set
            {
                this.interactives = value;
            }
        }

        public Point2D LastCharacterCoordinates
        {
            get
            {
                return this.lastCharacterCoordinates;
            }
            set
            {
                this.lastCharacterCoordinates = value;
            }
        }

        private void CreateLevel(int level, ContentManager content)
        {
            switch (level)
            {
                case 1:
                    {
                        this.LevelBackground = new Sprite(Constant.Level1BackgroundPath, new Point2D(0, 0));

                        this.Decor.Add(new Sprite(Constant.BigTreePath, new Point2D(100, 50)));
                        this.Decor.Add(new Sprite(Constant.BigTreePath, new Point2D(500, 100)));
                        this.Decor.Add(new Sprite(Constant.BigTreePath, new Point2D(900, 75)));
                        this.Decor.Add(new Sprite(Constant.BigTreePath, new Point2D(1300, 100)));

                        this.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(350, 75)));
                        this.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(800, 55)));
                        this.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(650, 90)));
                        this.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(1100, 40)));
                        this.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(1500, 55)));
                        
                        this.Decor.Add(new Sprite(Constant.CryptPath,
                            new Point2D(Constant.CryptPositionX, Constant.CryptPositionY)));

                        this.Enemies.Add(new Zombie(new Point2D(1100, 300), Orus.Instance.Content));
                        this.Enemies.Add(new Zombie(new Point2D(1250, 300), Orus.Instance.Content));
                        this.Enemies.Add(new Zombie(new Point2D(1300, 300), Orus.Instance.Content));
                        this.Enemies.Add(new Zombie(new Point2D(1400, 300), Orus.Instance.Content));
                        this.RequiredXForEnemySpawn = 600;

                        this.QuestGivers = new List<QuestGiver>()
                        {
                            new QuestGiver(Constant.PeasantDefaultName,
                            new Point2D(Constant.QuestGiver1PositionX, Constant.QuestGiver1PositionY),
                            Constant.PeasantIddleAnimationPath, Constant.PeasantIddleFramesNumber,
                            new SlayQuest(Constant.SkeletonBossDefaultName, 1),
                            Constant.QuestGiver1InitialText,
                            Constant.QuestGiver1CompletedText,
                            Constant.QuestGiver1OffsetFromTopForInitial,
                            Constant.QuestGiver1OffsetFromTopForCompleted,
                            Constant.QuestGiver1HeightForText)
                        };
                        this.Interactives = new List<IInteractable>()
                        {
                            new LevelChanger("Crypt",
                            new Point2D(Constant.CryptPositionX, Constant.CryptPositionY),
                            new Rectangle2D(Constant.CryptPositionX, Constant.CryptPositionY,
                                          Constant.CryptWidth, Constant.CryptHeight), 2)
                        };
                        this.QuestGivers[0].IddleAnimation.SpriteEffect = SpriteEffects.FlipHorizontally;

                        break;
                    }
                case 2:
                    {
                        this.LevelBackground = new Sprite(Constant.Level2BackgroundPath, new Point2D(0, 0));
                        this.Enemies.Add(new SkeletonBoss(Constant.SkeletonBossDefaultName, new Point2D(1100, 300), Orus.Instance.Content));
                        this.Interactives = new List<IInteractable>()
                        {
                            new LevelChanger("CryptExit",
                            new Point2D(0, Constant.StartingPlayerYPosition),
                            new Rectangle2D(0, Constant.StartingPlayerYPosition,
                                          Constant.CryptWidth, Constant.CryptHeight), 1)
                        };
                        break;
                    }
            }
            this.LevelBackground.IsActive = true;
            foreach (var item in this.Decor)
            {
                item.IsActive = true;
            }
        }

        public static void Load(int index)
        {
            Orus.Instance.Levels[Orus.Instance.CurrentLevelIndex].LastCharacterCoordinates = Orus.Instance.Character.Position;
            Orus.Instance.CurrentLevelIndex = index - 1;
            Orus.Instance.Character.Position = Orus.Instance.Levels[Orus.Instance.CurrentLevelIndex].LastCharacterCoordinates;
        }

        public void Update(GameTime gameTime, ICollection<IItem> visibleItems)
        {
            foreach (var enemy in this.Enemies.Where(enemy => enemy.IsVisible()))
            {
                enemy.Update(gameTime);

                if (enemy.JustKilled)
                {
                    ItemFactory.ProduceItemInField(enemy.DeathAnimation, enemy, visibleItems);
                    enemy.JustKilled = false;
                }
            }
            foreach (var questGiver in this.QuestGivers)
            {
                questGiver.Update(gameTime);
            }

            if (!this.SpawnedEnemies && this.RequiredXForEnemySpawn < Orus.Instance.Character.Position.X && this.RequiredXForEnemySpawn > 0)
            {
                switch (Orus.Instance.CurrentLevelIndex + 1)
                {
                    case 1:
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
            foreach (var item in this.Decor)
            {
                item.Draw(spriteBatch);
            }
            foreach (var questGiver in this.QuestGivers)
            {
                questGiver.DrawAnimations(spriteBatch);
            }
            foreach (var enemy in this.Enemies.Where(enemy => enemy.IsVisible()))
            {
                enemy.DrawAnimations(spriteBatch);
            }
        }
    }
}
