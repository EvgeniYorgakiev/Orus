using System;
using Microsoft.Xna.Framework;
using Orus.InputHandler;
using Orus.Exceptions;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Microsoft.Xna.Framework.Input;
using Orus.GameObjects.Player.Characters;
using Orus.GameObjects;
using Orus.Menu;

namespace Orus.Levels
{
    public class NewGameSelection
    {
        private Text nameFieldDescription;
        private Text nameField;
        private Texture2D confirmationButton;
        private Rectangle confirmationButtonLocation;





        public Text NameFieldDescription
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

        public Text NameField
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

        public Texture2D ConfirmationButton
        {
            get
            {
                return confirmationButton;
            }
            set
            {
                confirmationButton = value;
            }
        }

        public Rectangle ConfirmationButtonLocation
        {
            get
            {
                return confirmationButtonLocation;
            }
            set
            {
                confirmationButtonLocation = value;
            }
        }

        public void Load()
        {
            this.ConfirmationButton = Orus.Instance.Content.Load<Texture2D>("Sprites\\Buttons\\Start");
            this.ConfirmationButtonLocation = new Rectangle(Constant.ConfirmationButtonPositionX, Constant.ConfirmationButtonPositionY,
                Constant.ConfirmationButtonWidth, Constant.ConfirmationButtonHeight);
            this.NameField = new Text("", true, Constant.InputBoxLeftCorner, Constant.NameFieldPositionY, 
                Constant.NameFieldWidth, Constant.InputBoxHeight,
                Constant.NameFieldDelay, Color.Black, false, Orus.Instance.NameFont);
            this.NameFieldDescription = new Text("Please enter a name for your character", false, 
                Constant.InputBoxLeftCorner, Constant.NameFieldDescriptionPositionY, 
                Constant.NameFieldDescriptionWidth, Constant.InputBoxHeight,
                Constant.NameFieldDescriptionDelay, Color.White, true, Orus.Instance.NameFont);
        }

        public void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            if(this.ConfirmationButtonLocation.Contains(mouseState.X, mouseState.Y) && mouseState.LeftButton == ButtonState.Pressed)
            {
                try
                {
                    Character character = null;
                    foreach (var currentCharacter in Orus.Instance.AllCharacters)
                    {
                        if(currentCharacter.IddleAnimation.Scale > 1)
                        {
                            character = currentCharacter;
                            break;
                        }
                    }
                    if(character != null)
                    {
                        character.Name = this.NameField.TextInField;
                        character.IddleAnimation.Scale = 1;
                        character.Position = new Point2D(Constant.StartingPlayerXPosition, Constant.StartingPlayerYPosition);
                        GameMenu.CharacterSelectionInProgress = false;
                        Orus.Instance.IsMouseVisible = false;
                        Orus.Instance.Character = character;
                    }
                }
                catch(InvalidName exception)
                {
                    this.NameFieldDescription = new Text(exception.Message, false, 
                        Constant.InputBoxLeftCorner, Constant.NameFieldDescriptionPositionY,
                        Constant.ErrorNameFieldDescriptionWidth, Constant.InputBoxHeight,
                        Constant.NameFieldDescriptionDelay, Color.White, true, Orus.Instance.NameFont);
                }
            }
            try
            {
                this.NameField.Update(gameTime, false);

            }
            catch (InvalidName exception)
            {
                this.NameFieldDescription = new Text(exception.Message, false,
                    Constant.InputBoxLeftCorner, Constant.NameFieldDescriptionPositionY,
                    Constant.ErrorNameFieldDescriptionWidth, Constant.InputBoxHeight,
                    Constant.NameFieldDescriptionDelay, Color.White, true, Orus.Instance.NameFont);
            }
            this.NameFieldDescription.Update(gameTime, true);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.NameField.Draw(spriteBatch);
            this.NameFieldDescription.Draw(spriteBatch);
            spriteBatch.Draw(this.ConfirmationButton, this.ConfirmationButtonLocation, Color.White);

        }
    }
}
