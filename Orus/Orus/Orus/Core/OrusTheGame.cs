namespace Orus.Core
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Constants;
    using DataManager;
    using System;

    [Serializable()]
    public sealed class OrusTheGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameInformation information;
        private static OrusTheGame instance = null;
        private static readonly object padlock = new object();

        public OrusTheGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Exiting += Data.Save;
        }

        //Singleton pattern
        public static OrusTheGame Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new OrusTheGame();
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

        public GameInformation GameInformation
        {
            get
            {
                return this.information;
            }
            set
            {
                this.information = value;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Load the content
            this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.Graphics.PreferredBackBufferWidth = Constant.WindowWidth;
            this.Graphics.PreferredBackBufferHeight = Constant.WindowHeight;
            this.Graphics.ApplyChanges();
            this.GameInformation = new GameInformation();
            this.GameInformation.Load(this.Content);
        }

        protected override void Update(GameTime gameTime)
        {
            this.GameInformation.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            this.GameInformation.Draw(this.SpriteBatch);
        }
    }
}
