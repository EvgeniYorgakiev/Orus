using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orus.Animations;
using Orus.Constants;
using Orus.GameObjects;
using Orus.GameObjects.Enemies;
using Orus.GameObjects.Enemies.NormalEnemies;
using Orus.GameObjects.Player.Characters;
using Orus.InputHandler;
using Orus.Interfaces;
using Orus.Menu;
using System.Collections.Generic;
using System.Diagnostics;

namespace Orus
{
    public sealed class Orus : Game 
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Character character;
        private List<Enemy> enemies;
        private static Orus instance = null;
        private static readonly object padlock = new object();
        private SpriteFont healthFont;
        private Sprite level1Background;

        public Orus()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        public Sprite Level1Background 
        {
            get
            {
                return this.level1Background;
            }
            set
            {
                this.level1Background = value;
            }
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

        public SpriteFont HealthFont
        {
            get
            {
                return this.healthFont;
            }
            set
            {
                this.healthFont = value;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            Level1Background = new Sprite(Content.Load<Texture2D>("Sprites\\Background\\Level1Background"), new Point2D(0, 0));
            Level1Background.IsActive = true;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.HealthFont = Content.Load<SpriteFont>("Texts\\Fonts\\HealthFont");

            graphics.PreferredBackBufferWidth = Constant.WindowWidth;
            graphics.PreferredBackBufferHeight = Constant.WindowHeight;
            graphics.ApplyChanges();
            GameMenu.Load(this.Content);

            Enemies = new List<Enemy>();
            Enemies.Add(new Zombie(new Point2D(100, 300), Content));
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
                foreach (var enemy in Enemies)
                {
                    enemy.Update(gameTime);
                }
            }
            base.Update(gameTime);
        }
        
        public void MoveCharacter(GameTime gameTime, bool moveRight)
        {
            bool collides = Character.CollidesWithObjects(this.Enemies.ConvertAll<ICollide>(enemy => enemy), moveRight);
            if ((this.Character.Position.X < 0 && !moveRight) ||
               (this.Character.Position.X + Constant.CrusaderWidth > Constant.WindowWidth && moveRight))
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
            
            SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            
            if(GameMenu.IsMenuActive)
            {
                
                GameMenu.Draw(SpriteBatch);
                
            }
            else
            {
                
                Character.DrawAnimations(SpriteBatch);
                Level1Background.Draw(SpriteBatch);
                foreach (var enemy in Enemies)
                {
                    
                    enemy.DrawAnimations(SpriteBatch);
                    
                }
                
            }
            
            
            spriteBatch.End();
            
        }
    }
}
