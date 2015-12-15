using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.Exceptions;
using Orus.GameObjects;
using Orus.GameObjects.Player;
using Orus.GameObjects.Player.Characters;
using Orus.InputHandler;
using Orus.Interfaces;
using Orus.Levels;
using Orus.Menu;
using System.Collections.Generic;
using System.Linq;

namespace Orus
{
    public sealed class Orus : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Camera camera;
        private Character character;
        private List<Character> allCharacters;
        private List<Level> levels;
        private int currentLevelIndex;
        private static Orus instance = null;
        private static readonly object padlock = new object();
        private SpriteFont font;
        private static TextInput nameFieldDescription;
        private static TextInput nameField;

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

        public SpriteFont Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
            }
        }

        public TextInput NameFieldDescription
        {
            get
            {
                return nameFieldDescription;
            }
            set
            {
                nameFieldDescription = value;
            }
        }

        public TextInput NameField
        {
            get
            {
                return nameField;
            }
            set
            {
                nameField = value;
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
            this.Levels = new List<Level>();
            this.Levels.Add(new Level(1, this.Content));
            this.CurrentLevelIndex = 0;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferWidth = Constant.WindowWidth;
            graphics.PreferredBackBufferHeight = Constant.WindowHeight;
            graphics.ApplyChanges();
            this.Font = this.Content.Load<SpriteFont>("Texts\\Fonts\\Arial");
            GameMenu.Load(this.Content);
            this.NameFieldDescription = new TextInput("Please enter a name for your character", false, 30, 400, 100, Color.White);
            this.NameField = new TextInput("", true, 60, 200, 250, Color.Black);
            //Character = new Crusader(new Point2D(Constant.FirstCharacterPositionX, Constant.AllCharactersPositionY), Content);
            AllCharacters = new List<Character>()
            {
                new Crusader(new Point2D(Constant.FirstCharacterPositionX, Constant.AllCharactersPositionY), Content)}
            ;
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
                Input.UpdateCharacterSelectionInput();
                try
                {
                    this.NameField.UpdateInputNameText(gameTime, false);
                }
                catch (InvalidName exception)
                {
                    this.NameFieldDescription = new TextInput(exception.Message, false, 30, 700, 100, Color.White);
                }
                this.NameFieldDescription.UpdateInputNameText(gameTime, true);
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
                        this.SpriteBatch.DrawString(this.Font, character.Name,
                        new Vector2(character.Position.X, character.Position.Y), Color.White);
                                    character.DrawAnimations(this.SpriteBatch);
                    }
                    this.NameField.Draw(spriteBatch);
                    this.NameFieldDescription.Draw(spriteBatch);
                }
                else
                {
                    Character.DrawAnimations(this.SpriteBatch);
                    foreach (var enemy in this.Levels[this.CurrentLevelIndex].Enemies.Where(enemy => enemy.IsVisible()))
                    {
                        enemy.DrawAnimations(this.SpriteBatch);
                    }
                }
            }
            spriteBatch.End();
            
        }
    }
}
