using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.GameObjects;
using Orus.GameObjects.Player;
using Orus.GameObjects.Player.Characters;
using Orus.InputHandler;
using Orus.Interfaces;
using Orus.Levels;
using Orus.Menu;
using System.Collections.Generic;
using Orus.DataManager;
using System;
using Orus.Sprites;

namespace Orus
{
    [Serializable()]
    public sealed class Orus : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Camera camera;
        private GameMenu gameMenu;
        private Character character;
        private List<Character> allCharacters;
        private List<Level> levels;
        private int currentLevelIndex;
        private static Orus instance = null;
        private static readonly object padlock = new object();
        private SpriteFontSubstitude questFont;
        private SpriteFontSubstitude nameFont;
        private NewGameSelection newGameSelection;

        public Orus()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Exiting += SaveGame.Save;
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

        public GameMenu GameMenu
        {
            get
            {
                return this.gameMenu;
            }
            set
            {
                this.gameMenu = value;
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

        public SpriteFontSubstitude QuestFont
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

        public SpriteFontSubstitude NameFont
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

        public ICollection<IItem> ItemsOnTheField { get; set; }

        protected override void Initialize()
        {
            base.Initialize();
            this.IsMouseVisible = true;
            this.Camera = new Camera(GraphicsDevice.Viewport);
            //this.Camera = new Camera(this);
            ItemsOnTheField = new List<IItem>();
        }

        protected override void LoadContent()
        {
            this.NameFont = new SpriteFontSubstitude(Constant.NameFontPath);
            this.QuestFont = new SpriteFontSubstitude(Constant.QuestFontPath);
            this.Levels = new List<Level>()
            {
                new Level(1, this.Content),
                new Level(2, this.Content)
            };
            this.AllCharacters = new List<Character>()
            {
                new Crusader(new Point2D(Constant.FirstCharacterPositionX, Constant.AllCharactersPositionY), Content)
            };
            this.CurrentLevelIndex = 0;
            this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.Graphics.PreferredBackBufferWidth = Constant.WindowWidth;
            this.Graphics.PreferredBackBufferHeight = Constant.WindowHeight;
            this.Graphics.ApplyChanges();
            this.GameMenu = new GameMenu();
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
                this.Camera.Update(gameTime, this.Character.Position);
                Input.UpdateInput(gameTime);
                this.Levels[this.CurrentLevelIndex].Update(gameTime, ItemsOnTheField);
                Character.Animate(gameTime);
                this.Character.CheckCollisionOfCharacterWithItems(this.ItemsOnTheField);
            }
            base.Update(gameTime);


        }
        
        public void MoveCharacter(GameTime gameTime, bool moveRight)
        {
            bool collides = false;
            foreach (var enemy in this.Levels[this.CurrentLevelIndex].Enemies)
            {
                if (this.Character.CollidesForAttack(enemy, moveRight))
                {
                    collides = true;
                    break;
                }
            }
            if ((this.Character.Position.X < 0 && !moveRight) ||
               (this.Character.Position.X + Constant.SpriteWidth > 
               this.Levels[this.CurrentLevelIndex].LevelBackground.Texture.Texture.Width && moveRight))
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
                        this.SpriteBatch.DrawString(this.NameFont.Font, character.Name,
                        new Vector2(character.Position.X, character.Position.Y), Color.White);
                                    character.DrawAnimations(this.SpriteBatch);
                    }
                    this.NewGameSelection.Draw(this.SpriteBatch);
                }
                else
                {
                    foreach (var element in this.ItemsOnTheField)
                    {
                        element.DrawOnTheField(this.SpriteBatch);
                    }

                    foreach (var element in this.Character.CollectedItems)
                    {
                        Point2D beginningOfTheMenu = new Point2D(this.Camera.Center.X+element.ItemPicture.Texture.Texture.Width,
                            this.Camera.Center.Y + element.ItemPicture.Texture.Texture.Height/2);
                        element.DrawOnTheGameMenu(this.SpriteBatch, beginningOfTheMenu, gameTime);
                    }

                    Character.DrawAnimations(this.SpriteBatch);
                }
            }
            spriteBatch.End();
        }
    }
}
