using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orus.Abilities;
using Orus.GameObjects;

namespace Orus.InputHandler
{
    public static class Input
    {
        private static bool mouseClicked;
        private static bool isSpacePressed = false;

        public static bool MouseClicked
        {
            get { return mouseClicked; }
            set { mouseClicked = value; }
        }

        public static bool IsSpacePressed
        {
            get
            {
                return isSpacePressed;
            }
            set
            {
                isSpacePressed = value;
            }
        }

        public static void UpdateInput(GameTime gameTime)
        {
            if (Orus.Instance.Character.AttackAnimation.IsActive || Orus.Instance.Character.Health == 0 || 
                Orus.Instance.Character.IsUsingAbility)
            {
                return;
            }
            var keyState = Keyboard.GetState();
            var mouseState = Mouse.GetState();
            if (keyState.IsKeyDown(Keys.Escape))
            {
                Orus.Instance.Exit();
            }
            else if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
            {
                Orus.Instance.MoveCharacter(gameTime, true);
            }
            else if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
            {
                Orus.Instance.MoveCharacter(gameTime, false);
            }
            else
            {
                Orus.Instance.Character.StopMovement();
            }
            if (keyState.IsKeyDown(Keys.Space))
            {
                IsSpacePressed = true;
            }
            if(keyState.IsKeyUp(Keys.Space) && IsSpacePressed)
            {
                foreach (var questGiver in Orus.Instance.Levels[Orus.Instance.CurrentLevelIndex].QuestGivers)
                {
                    if (questGiver.Collides(Orus.Instance.Character))
                    {
                        questGiver.Interact();
                        break;
                    }
                }
                foreach (var interactiveItem in Orus.Instance.Levels[Orus.Instance.CurrentLevelIndex].Interactives)
                {
                    if (interactiveItem.Collides(Orus.Instance.Character))
                    {
                        interactiveItem.Interact();
                        break;
                    }
                }
                IsSpacePressed = false;
            }
            if (keyState.IsKeyDown(Keys.Q))
            {
                AbilityFactory.UseAbility(1, Orus.Instance.Character);
            }
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Orus.Instance.Character.Attack(Orus.Instance.Levels[Orus.Instance.CurrentLevelIndex].Enemies.ConvertAll<AttackableGameObject>(enemy => enemy));
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
