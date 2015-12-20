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
            this.Exiting += Data.Save;
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

        protected override void Initialize()
        {
            base.Initialize();
            //this.Camera = new Camera(this);
        }

        protected override void LoadContent()
        {
            this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.Graphics.PreferredBackBufferWidth = Constant.WindowWidth;
            this.Graphics.PreferredBackBufferHeight = Constant.WindowHeight;
            this.Graphics.ApplyChanges();
            this.GameMenu = new GameMenu();
            GameMenu.Load(this.Content);
            this.NewGame();
        }

        public void NewGame()
        {
            this.IsMouseVisible = true;
            this.Camera = new Camera(GraphicsDevice.Viewport);
            this.NameFont = new SpriteFontSubstitude(Constant.NameFontPath);
            this.QuestFont = new SpriteFontSubstitude(Constant.QuestFontPath);
            this.Levels = new List<Level>()
            {
                new Level1(),
                new OptionalLevel1(),
                new Level2()
            };
            this.AllCharacters = new List<Character>()
            {
                new Crusader(new Point2D(Constant.FirstCharacterPositionX, Constant.AllCharactersPositionY), Content)
            };
            this.CurrentLevelIndex = 0;
            this.NewGameSelection = new NewGameSelection();
            this.NewGameSelection.Load();
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
                    character.Update(gameTime);
                }
            }
            else
            {
                this.Camera.Update(gameTime, this.Character.Position);
                this.Levels[this.CurrentLevelIndex].Update(gameTime);
                if (this.Character.Health > 0 || 
                    (this.Character.DeathAnimation.FrameIndex < this.Character.DeathAnimation.Rectangles.Length &&
                     this.Character.DeathAnimation.IsActive))
                {
                    Input.UpdateInput(gameTime);
                    this.Character.CheckCollisionOfCharacterWithItems(this.Levels[this.CurrentLevelIndex].ItemsOnTheField);
                    this.Character.Update(gameTime);
                }
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
                    this.Character.DrawAnimations(this.SpriteBatch);
                }
            }
            spriteBatch.End();
        }

        public void UpdateGameProperties(Orus newGameProperties)
        {
            this.Camera = new Camera(Orus.Instance.GraphicsDevice.Viewport);
            this.Character = newGameProperties.Character;
            this.CurrentLevelIndex = newGameProperties.CurrentLevelIndex;
            this.Levels = newGameProperties.Levels;
            this.NewGameSelection = newGameProperties.NewGameSelection;
            this.GameMenu = newGameProperties.GameMenu;
            this.GameMenu.IsMenuActive = false;
            this.IsMouseVisible = false;
            this.GameMenu.HasLoaded = true;
            this.GameMenu.DifferenceInPositionFromLoad = new Point2D(
                this.Window.ClientBounds.X - newGameProperties.Window.ClientBounds.X,
                this.Window.ClientBounds.Y - newGameProperties.Window.ClientBounds.Y);
        }
    }
}
