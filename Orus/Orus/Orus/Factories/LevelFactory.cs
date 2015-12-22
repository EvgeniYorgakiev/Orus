namespace Orus.Factories
{
    using Constants;
    using Sprites;
    using Levels;
    using Microsoft.Xna.Framework.Content;
    using System.Collections.Generic;
    using GameObjects;
    using GameObjects.Enemies.NormalEnemies;
    using GameObjects.NPC;
    using Quests;
    using Interfaces;
    using GameObjects.InteractiveBackgrounds;
    using Microsoft.Xna.Framework.Graphics;
    using GameObjects.Enemies.Boss;

    public static class LevelFactory
    {
        //Create a level based on the level index

        public static void CreateLevel(Level level, int levelIndex, ContentManager content)
        {
            switch (levelIndex)
            {
                case 1:
                    {
                        level.LevelBackground = new Sprite(Constant.Level1BackgroundPath, new Point2D(0, 0));

                        level.Decor.Add(new Sprite(Constant.BigTreePath, new Point2D(100, 50)));
                        level.Decor.Add(new Sprite(Constant.BigTreePath, new Point2D(500, 100)));
                        level.Decor.Add(new Sprite(Constant.BigTreePath, new Point2D(900, 75)));
                        level.Decor.Add(new Sprite(Constant.BigTreePath, new Point2D(1300, 100)));

                        level.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(350, 75)));
                        level.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(800, 55)));
                        level.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(650, 90)));
                        level.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(1100, 40)));
                        level.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(1500, 55)));

                        level.Decor.Add(new Sprite(Constant.CryptPath,
                            new Point2D(Constant.CryptPositionX, Constant.CryptPositionY)));

                        level.Enemies.Add(new Zombie(new Point2D(1100, Constant.StartingPlayerYPosition), Orus.Instance.Content));
                        level.Enemies.Add(new Zombie(new Point2D(1250, Constant.StartingPlayerYPosition), Orus.Instance.Content));
                        level.Enemies.Add(new Zombie(new Point2D(1300, Constant.StartingPlayerYPosition), Orus.Instance.Content));
                        level.Enemies.Add(new Zombie(new Point2D(1400, Constant.StartingPlayerYPosition), Orus.Instance.Content));
                        level.RequiredXForEnemySpawn = 600;

                        level.QuestGivers = new List<QuestGiver>()
                        {
                            new QuestGiver(Constant.PeasantDefaultName,
                            new Point2D(Constant.QuestGiver1PositionX, Constant.QuestGiver1PositionY),
                            Constant.PeasantIddleAnimationPath, Constant.PeasantIddleFramesNumber,
                            new SlayQuest(Constant.ZombieDefaultName, 1),
                            Constant.QuestGiver1InitialText,
                            Constant.QuestGiver1CompletedText,
                            Constant.QuestGiver1OffsetFromTopForInitial,
                            Constant.QuestGiver1OffsetFromTopForCompleted,
                            Constant.QuestGiver1HeightForText, 
                            Constant.QuestGiver1ExperienceOnFinish)
                        };
                        level.Interactives = new List<IInteractable>()
                        {
                            new LevelChanger("Crypt",
                                new Point2D(Constant.CryptPositionX, Constant.CryptPositionY),
                                new Rectangle2D(Constant.CryptPositionX, Constant.CryptPositionY,
                                          Constant.CryptWidth, Constant.CryptHeight), 2),
                            new LevelChanger("Level3",
                                new Point2D(
                                    level.LevelBackground.Texture.Texture.Width - Constant.SpriteWidth,
                                    Constant.StartingPlayerYPosition),
                                new Rectangle2D(
                                    level.LevelBackground.Texture.Texture.Width - Constant.SpriteWidth,
                                    Constant.StartingPlayerYPosition,
                                    Constant.SpriteWidth,
                                    Constant.DefaultHeighForEverything), 3)
                        };
                        level.QuestGivers[0].IddleAnimation.SpriteEffect = SpriteEffects.FlipHorizontally;

                        break;
                    }
                case 2:
                    {
                        level.LevelBackground = new Sprite(Constant.Level2BackgroundPath, new Point2D(0, 0));
                        level.Enemies.Add(new SkeletonBoss(Constant.SkeletonBossDefaultName, new Point2D(1100, 250), Orus.Instance.Content));
                        level.Interactives = new List<IInteractable>()
                        {
                            new LevelChanger("CryptExit",
                                             new Point2D(0, Constant.StartingPlayerYPosition),
                                             new Rectangle2D(0, Constant.StartingPlayerYPosition,
                                                             Constant.SpriteWidth, Constant.DefaultHeighForEverything), 1)
                        };
                        break;
                    }
                case 3:
                    {
                        level.LevelBackground = new Sprite(Constant.Level1BackgroundPath, new Point2D(0, 0));

                        level.Decor.Add(new Sprite(Constant.BigTreePath, new Point2D(250, 50)));
                        level.Decor.Add(new Sprite(Constant.BigTreePath, new Point2D(400, 100)));
                        level.Decor.Add(new Sprite(Constant.BigTreePath, new Point2D(700, 75)));
                        level.Decor.Add(new Sprite(Constant.BigTreePath, new Point2D(1100, 100)));

                        level.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(50, 75)));
                        level.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(350, 55)));
                        level.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(650, 90)));
                        level.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(975, 40)));
                        level.Decor.Add(new Sprite(Constant.SmallTreePath, new Point2D(1350, 55)));

                        level.Enemies.Add(new LichBoss(new Point2D(1100, 275), Orus.Instance.Content));
                        level.Interactives = new List<IInteractable>()
                        {
                            new LevelChanger("LevelReturn",
                                             new Point2D(0, Constant.StartingPlayerYPosition),
                                             new Rectangle2D(0, Constant.StartingPlayerYPosition,
                                                              Constant.SpriteWidth, Constant.DefaultHeighForEverything), 1)
                        };
                        break;
                    }
            }
            level.LevelBackground.IsActive = true;
            foreach (var item in level.Decor)
            {
                item.IsActive = true;
            }
        }
    }
}
