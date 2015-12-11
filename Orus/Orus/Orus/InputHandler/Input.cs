using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Orus.GameObjects;

namespace Orus.InputHandler
{
    public static class Input
    {
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
    }
}
