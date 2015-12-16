using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.GameObjects;
using Orus.GameObjects.NPC;
using Orus.GameObjects.Player;
using Orus.GameObjects.Player.Characters;
using Orus.InputHandler;
using Orus.Interfaces;
using Orus.Levels;
using Orus.Menu;
using Orus.Quests;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Orus.GameObjects.Items;

namespace Orus
{
    public sealed class Orus : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Camera camera;
        private Character character;
        private List<QuestGiver> questGivers;
        private List<Character> allCharacters;
        private List<Level> levels;
        private int currentLevelIndex;
        private static Orus instance = null;
        private static readonly object padlock = new object();
        private SpriteFont questFont;
        private SpriteFont nameFont;
        private NewGameSelection newGameSelection;
        public static int a = 0;

        public Orus()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public static Orus Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Orus();
                    }
                    return instance;
                }
            }
        }

        private GraphicsDeviceManager Graphics
        {
            get
            {
                return this.graphics;
            }
            set
            {
                this.graphics = value;
            }
        }

        private SpriteBatch SpriteBatch
        {
            get
            {
                return this.spriteBatch;
            }
            set 
            { 
                this.spriteBatch = value;
            }
        }

        public Camera Camera
        {
            get
            {
                return this.camera;
            }
            set
            {
                this.camera = value;
            }
        }

        public Character Character
        {
            get
            {
                return this.character;
            }
            set
            { this.character = value;
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

        public List<Character> AllCharacters
        {
            get
            {
                return this.allCharacters;
            }
            set
            {
                this.allCharacters = value;
            }
        }

        public List<Level> Levels
        {
            get
            {
                return this.levels;
            }
            set
            {
                this.levels = value;
            }
        }

        public int CurrentLevelIndex
        {
            get
            {
                return this.currentLevelIndex;
            }
            set
            {
                this.currentLevelIndex = value;
            }
        }

        public SpriteFont QuestFont
        {
            get
            {
                return questFont;
            }
            set
            {
                questFont = value;
            }
        }

        public SpriteFont NameFont
        {
            get
            {
                return nameFont;
            }
            set
            {
                nameFont = value;
            }
        }

        public NewGameSelection NewGameSelection
        {
            get
            {
                return newGameSelection;
            }
            set
            {
                newGameSelection = value;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.IsMouseVisible = true;
            this.Camera = new Camera(GraphicsDevice.Viewport);
            //this.Camera = new Camera(this);
        }

        protected override void LoadContent()
        {
            this.NameFont = this.Content.Load<SpriteFont>("Texts\\Fonts\\NameFont");
            this.QuestFont = this.Content.Load<SpriteFont>("Texts\\Fonts\\QuestFont");
            this.Levels = new List<Level>()
            {
                new Level(1, this.Content)
            };
            this.AllCharacters = new List<Character>()
            {
                new Crusader(new Point2D(Constant.FirstCharacterPositionX, Constant.AllCharactersPositionY), Content)
            };
            this.QuestGivers = new List<QuestGiver>()
            {
                new QuestGiver(Constant.PeasantDefaultName, 
                new Point2D(Constant.QuestGiver1PositionX, Constant.QuestGiver1PositionY),
                Constant.PeasantIddleAnimationPath, Constant.PeasantIddleFramesNumber,
                new SlayQuest(Constant.SkeletonDefaultName, 1),
                Constant.QuestGiver1InitialText,
                Constant.QuestGiver1CompletedText,
                Constant.QuestGiver1OffsetFromTopForInitial,
                Constant.QuestGiver1OffsetFromTopForCompleted,
                Constant.QuestGiver1HeightForText)
            };
            this.QuestGivers[0].IddleAnimation.SpriteEffect = SpriteEffects.FlipHorizontally;
            this.CurrentLevelIndex = 0;
            this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.Graphics.PreferredBackBufferWidth = Constant.WindowWidth;
            this.Graphics.PreferredBackBufferHeight = Constant.WindowHeight;
            this.Graphics.ApplyChanges();
            GameMenu.Load(this.Content);
            this.NewGameSelection = new NewGameSelection();
            this.NewGameSelection.Load();
            //Character = new Crusader(new Point2D(Constant.FirstCharacterPositionX, Constant.AllCharactersPositionY), Content);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GameMenu.IsMenuActive)
            {
                GameMenu.Update();
            }
            else if (GameMenu.CharacterSelectionInProgress)
            {
                this.NewGameSelection.Update(gameTime);
                Input.UpdateCharacterSelectionInput();
                foreach (var character in AllCharacters)
                {
                    character.Animate(gameTime);
                }
            }
            else
            {
                Input.UpdateInput(gameTime);
                this.Levels[this.CurrentLevelIndex].SpawnNewEnemies(600);
                Character.Animate(gameTime);
                foreach (var enemy in this.Levels[this.CurrentLevelIndex].Enemies.Where(enemy => enemy.IsVisible()))
                {
                    enemy.Update(gameTime);
                }
                foreach (var questGiver in this.QuestGivers)
                {
                    questGiver.Update(gameTime);
                }
                this.Camera.Update(gameTime, this.Character.Position);
            }
            base.Update(gameTime);


        }
        
        public void MoveCharacter(GameTime gameTime, bool moveRight)
        {
            bool collides = Character.CollidesWithObjects(this.Levels[this.CurrentLevelIndex].Enemies.ConvertAll<ICollide>(enemy => enemy), moveRight);

            if ((this.Character.Position.X < 0 && !moveRight) ||
               (this.Character.Position.X + Constant.SpriteWidth > 
               this.Levels[this.CurrentLevelIndex].LevelBackground.Texture.Width && moveRight))
            {
                collides = true;
            }
            if (!collides)
            {
                this.Character.Move(gameTime, moveRight, collides);
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            if(GameMenu.IsMenuActive)
            {
                SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
                GameMenu.Draw(this.SpriteBatch);
            }
            else
            {
                SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, this.Camera.Transform);
                this.Levels[this.CurrentLevelIndex].Draw(this.SpriteBatch);
                if (GameMenu.CharacterSelectionInProgress)
                {
                    foreach (var character in AllCharacters)
                    {
                        this.SpriteBatch.DrawString(this.NameFont, character.Name,
                        new Vector2(character.Position.X, character.Position.Y), Color.White);
                                    character.DrawAnimations(this.SpriteBatch);
                    }
                    this.NewGameSelection.Draw(this.SpriteBatch);
                }
                else
                {

                    
                    foreach (var questGiver in this.QuestGivers)
                    {
                        questGiver.DrawAnimations(this.SpriteBatch);
                    }
                    foreach (var enemy in this.Levels[this.CurrentLevelIndex].Enemies.Where(enemy => enemy.IsVisible()))
                    {
                        enemy.DrawAnimations(this.SpriteBatch);
                    }

                    
                    foreach (var element in Item.VisibleItems)
                    {
                        element.Draw(SpriteBatch);
                    }

                    Character.DrawAnimations(this.SpriteBatch);
                }
            }
            spriteBatch.End();
        }
    }
}
