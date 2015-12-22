namespace Orus.Levels
{
    using GameObjects.Enemies;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using GameObjects;
    using Constants;
    using GameObjects.NPC;
    using Interfaces;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Factories;
    using Core;
    using GameObjects.Sprites;

    public abstract class Level
    {
        private Sprite levelBackground;
        private List<Sprite> decor;
        private int requiredXForEnemySpawn;
        private bool spawnedEnemies = false;
        private List<Enemy> enemies;
        private List<QuestGiver> questGivers;
        private List<IInteractable> interactives;
        private Point2D lastCharacterCoordinates;

        protected Level()
        {

        }

        protected Level(int level, ContentManager content)
        {
            this.Enemies = new List<Enemy>();
            this.Decor = new List<Sprite>();
            this.QuestGivers = new List<QuestGiver>();
            this.Interactives = new List<IInteractable>();
            this.ItemsOnTheField = new List<IItem>();
            this.LastCharacterCoordinates = new Point2D(Constant.StartingPlayerXPosition, Constant.StartingPlayerYPosition);
            LevelFactory.CreateLevel(this, level, content);
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

        public ICollection<IItem> ItemsOnTheField { get; set; }

        public static void Load(int index)
        {
            OrusTheGame.Instance.GameInformation.Levels[OrusTheGame.Instance.GameInformation.CurrentLevelIndex].LastCharacterCoordinates = OrusTheGame.Instance.GameInformation.Character.Position;
            OrusTheGame.Instance.GameInformation.CurrentLevelIndex = index - 1;
            OrusTheGame.Instance.GameInformation.Character.Position = OrusTheGame.Instance.GameInformation.Levels[OrusTheGame.Instance.GameInformation.CurrentLevelIndex].LastCharacterCoordinates;
        }

        //Make it virtual in case we want to to override the Update and add spawning enemies on different levels 
        public virtual void Update(GameTime gameTime)
        {
            foreach (var enemy in this.Enemies.Where(enemy => enemy.IsVisible()))
            {
                enemy.Update(gameTime);

                if (enemy.JustKilled)
                {
                    ItemFactory.ProduceItemInField(enemy.DeathAnimation, enemy, this.ItemsOnTheField);
                    enemy.JustKilled = false;
                }
            }
            foreach (var questGiver in this.QuestGivers)
            {
                questGiver.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.LevelBackground.Draw(spriteBatch);
            foreach (var element in this.ItemsOnTheField)
            {
                element.DrawOnTheField(spriteBatch);
            }
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
