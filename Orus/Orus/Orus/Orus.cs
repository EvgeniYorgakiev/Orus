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

namespace Orus
{
    public sealed class Orus : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Camera camera;
        private Character character;
        private List<Level> levels;
        private int currentLevelIndex;
        private static Orus instance = null;
        private static readonly object padlock = new object();

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

        private Camera Camera
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
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferWidth = Constant.WindowWidth;
            graphics.PreferredBackBufferHeight = Constant.WindowHeight;
            graphics.ApplyChanges();
            GameMenu.Load(this.Content);
            Character = new Crusader(new Point2D(Constant.StartingPlayerXPosition, Constant.StartingPlayerYPosition), Content);
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
            else
            {
                Input.UpdateInput(gameTime);
                Character.Animate(gameTime);
                foreach (var enemy in this.Levels[this.CurrentLevelIndex].Enemies)
                {
                    if(enemy.Position.X - this.Character.Position.X < Constant.WindowWidth)
                    {
                        enemy.Update(gameTime);
                    }
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
                GameMenu.Draw(SpriteBatch);
            }
            else
            {
                SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, this.Camera.Transform);
                this.Levels[this.CurrentLevelIndex].LevelBackground.Draw(SpriteBatch);

                foreach (var item in this.Levels[this.CurrentLevelIndex].BigTree)
                {
                    item.Draw(spriteBatch);
                }
                foreach (var item in this.Levels[this.CurrentLevelIndex].SmallTree)
                {
                    item.Draw(spriteBatch);
                }

                
                Character.DrawAnimations(SpriteBatch);
                foreach (var enemy in this.Levels[this.CurrentLevelIndex].Enemies)
                {
                    enemy.DrawAnimations(SpriteBatch);
                }
            }
            spriteBatch.End();
            
        }
    }
}
