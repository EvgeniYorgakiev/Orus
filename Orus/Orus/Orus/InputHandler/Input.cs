using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Orus.GameObjects;

namespace Orus.InputHandler
{
    public static class Input
    {
        private static bool mouseClicked;

        public static bool MouseClicked
        {
            get { return mouseClicked; }
            set { mouseClicked = value; }
        }

        public static void UpdateInput(GameTime gameTime)
        {
            if (Orus.Instance.Character.AttackAnimation.IsActive || Orus.Instance.Character.Health == 0)
            {
                return;
            }
            var keyState = Keyboard.GetState();
            var mouseState = Mouse.GetState();
            if (keyState.IsKeyDown(Keys.Escape))
            {
                Orus.Instance.Exit();
            }
            else if (keyState.IsKeyDown(Keys.Right))
            {
                Orus.Instance.MoveCharacter(gameTime, true);
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                Orus.Instance.MoveCharacter(gameTime, false);
            }
            else
            {
                Orus.Instance.Character.StopMovement();
            }
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Orus.Instance.Character.Attack(Orus.Instance.Levels[Orus.Instance.CurrentLevelIndex].Enemies.ConvertAll<AnimatedGameObject>(enemy => enemy));
            }
        }

        public static void UpdateCharacterSelectionInput()
        {
            var mouseState = Mouse.GetState();
            if(mouseState.LeftButton == ButtonState.Pressed)
            {
                mouseClicked = true;
            }
            if(mouseState.LeftButton == ButtonState.Released && mouseClicked)
            {
                mouseClicked = false;
                foreach (var character in Orus.Instance.AllCharacters)
                {
                    Rectangle scaledBoundingBox = new Rectangle(
                        character.BoundingBox.X, character.BoundingBox.Y,
                        (int)(character.BoundingBox.Width * character.IddleAnimation.Scale),
                        (int)(character.BoundingBox.Height * character.IddleAnimation.Scale));
                    if (scaledBoundingBox.Contains(mouseState.X, mouseState.Y))
                    {
                        character.IddleAnimation.Scale = 1.5f;
                    }
                    else
                    {
                        character.IddleAnimation.Scale = 1f;
                    }
                }
            }
        }
    }
}
