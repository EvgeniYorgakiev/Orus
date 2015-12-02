using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orus.Animations;
using Orus.Constants;
using Orus.GameObjects.Enemies;
using Orus.GameObjects.Enemies.NormalEnemies;
using Orus.GameObjects.Player.Characters;
using System.Collections.Generic;

namespace Orus
{
    public class Orus : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Character character;
        private List<Enemy> enemies;

        private GraphicsDeviceManager Graphics { get { return this.graphics; } set { this.graphics = value; } }
        private SpriteBatch SpriteBatch { get { return this.spriteBatch; } set { this.spriteBatch = value; } }
        private Character Character { get { return this.character; } set { this.character = value; } }
        private List<Enemy> Enemies { get { return this.enemies; } set { this.enemies = value; } }

        public Orus()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Enemies = new List<Enemy>();
            Enemies.Add(new Zombie(new Vector2(400, 300), Content));
            Character = new Crusader(new Vector2(Constant.StartingPlayerXPosition, Constant.StartingPlayerYPosition), Content);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            UpdateInput(gameTime);
            Character.Animate(gameTime);
            foreach (var enemy in Enemies)
            {
                enemy.Animate(gameTime);
            }
            base.Update(gameTime);
        }

        private void UpdateInput(GameTime gameTime)
        {
            if (Character.AttackAnimation.IsActive)
            {
                return;
            }
            var keyState = Keyboard.GetState();
            var mouseState = Mouse.GetState();
            if (keyState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            else if (keyState.IsKeyDown(Keys.Right))
            {
                Character.Move(gameTime, true);
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                Character.Move(gameTime, false);
            }
            else
            {
                Character.StopMovement();
            }
            if (mouseState.LeftButton == ButtonState.Pressed && !Character.MoveAnimation.IsActive)
            {
                Character.Attack();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            Character.DrawAnimations(SpriteBatch);
            foreach (var enemy in Enemies)
            {
                enemy.DrawAnimations(SpriteBatch);
            }

            spriteBatch.End();
        }
    }
}
