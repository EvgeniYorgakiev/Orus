using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orus.Animations;
using Orus.Constants;
using Orus.Player.Characters;

namespace Orus
{
    public class Orus : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Character character;

        private GraphicsDeviceManager Graphics { get { return this.graphics; } set { this.graphics = value; } }
        private SpriteBatch SpriteBatch { get { return this.spriteBatch; } set { this.spriteBatch = value; } }
        private Character Character { get { return this.character; } set { this.character = value; } }

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
           Character = new Crusader(new Vector2(Constant.StartingPlayerXPosition, Constant.StartingPlayerYPosition));
           Character.IddleAnimation = new FrameAnimation(
                Content.Load<Texture2D>(Character.IddleAnimationPath), 
                Constant.CrusaderIddleFramesNumber,
                character);
            Character.IddleAnimation.IsActive = true;
            Character.MoveAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(Character.MoveAnimationPath),
                 Constant.CrusaderMoveFramesNumber,
                 character);
            Character.AttackAnimation = new FrameAnimation(
                 Content.Load<Texture2D>(Character.AttackAnimationPath),
                 Constant.CrusaderAttackFramesNumber,
                 character);
            Character.AttackAnimation.IsLoop = false;
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            UpdateInput(gameTime);
            Character.Animate(gameTime);
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
            if (mouseState.LeftButton == ButtonState.Pressed && Character.MoveAnimation.IsActive)
            {
                Character.Attack();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            Character.DrawAnimations(SpriteBatch);
            spriteBatch.End();
        }
    }
}
