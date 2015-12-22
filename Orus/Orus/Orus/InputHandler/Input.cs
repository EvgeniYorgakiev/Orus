using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Orus.Abilities;
using Orus.Core;
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

        //Update the input during gameplay
        public static void UpdateInput(GameTime gameTime)
        {
            if (OrusTheGame.Instance.GameInformation.Character.AttackAnimation.IsActive || OrusTheGame.Instance.GameInformation.Character.Health == 0 || 
                OrusTheGame.Instance.GameInformation.Character.IsUsingAbility)
            {
                return;
            }
            var keyState = Keyboard.GetState();
            var mouseState = Mouse.GetState();
            if (keyState.IsKeyDown(Keys.Escape))
            {
                OrusTheGame.Instance.GameInformation.GameMenu.IsMenuActive = true;
                OrusTheGame.Instance.IsMouseVisible = true;
            }
            else if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
            {
                OrusTheGame.Instance.GameInformation.Character.TryToMove(gameTime, true);
            }
            else if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
            {
                OrusTheGame.Instance.GameInformation.Character.TryToMove(gameTime, false);
            }
            else
            {
                OrusTheGame.Instance.GameInformation.Character.StopMovement();
            }
            if (keyState.IsKeyDown(Keys.Space))
            {
                IsSpacePressed = true;
            }
            if(keyState.IsKeyUp(Keys.Space) && IsSpacePressed)
            {
                foreach (var questGiver in OrusTheGame.Instance.GameInformation.Levels[OrusTheGame.Instance.GameInformation.CurrentLevelIndex].QuestGivers)
                {
                    if (questGiver.Collides(OrusTheGame.Instance.GameInformation.Character))
                    {
                        questGiver.Interact();
                        break;
                    }
                }
                foreach (var interactiveItem in OrusTheGame.Instance.GameInformation.Levels[OrusTheGame.Instance.GameInformation.CurrentLevelIndex].Interactives)
                {
                    if (interactiveItem.Collides(OrusTheGame.Instance.GameInformation.Character))
                    {
                        interactiveItem.Interact();
                        break;
                    }
                }
                IsSpacePressed = false;
            }
            if (keyState.IsKeyDown(Keys.Q) && !OrusTheGame.Instance.GameInformation.Character.MoveAnimation.IsActive)
            {
                AbilityFactory.UseAbility(1, OrusTheGame.Instance.GameInformation.Character);
            }
            else if (keyState.IsKeyDown(Keys.E) && !OrusTheGame.Instance.GameInformation.Character.MoveAnimation.IsActive)
            {
                AbilityFactory.UseAbility(2, OrusTheGame.Instance.GameInformation.Character);
            }
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                OrusTheGame.Instance.GameInformation.Character.Attack(OrusTheGame.Instance.GameInformation.Levels[OrusTheGame.Instance.GameInformation.CurrentLevelIndex].Enemies.ConvertAll<AttackingGameObject>(enemy => enemy));
            }
        }

        //Update the input during character selection
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
                foreach (var character in OrusTheGame.Instance.GameInformation.AllCharacters)
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
