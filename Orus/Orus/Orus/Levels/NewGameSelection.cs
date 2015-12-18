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
using Orus.Sprites;

namespace Orus.Levels
{
    public class NewGameSelection
    {
        private Text nameFieldDescription;
        private Text nameField;
        private Texture2DSubstitude confirmationButton;
        private Rectangle2D confirmationButtonLocation;

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

        public Texture2DSubstitude ConfirmationButton
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

        public Rectangle2D ConfirmationButtonLocation
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
            this.ConfirmationButton = new Texture2DSubstitude("Sprites\\Buttons\\Start");
            this.ConfirmationButtonLocation = new Rectangle2D(Constant.ConfirmationButtonPositionX, Constant.ConfirmationButtonPositionY,
                Constant.ConfirmationButtonWidth, Constant.ConfirmationButtonHeight);
            this.NameField = new Text("", true, Constant.InputBoxLeftCorner, Constant.NameFieldPositionY, 
                Constant.NameFieldWidth, Constant.InputBoxHeight,
                Constant.NameFieldDelay, Color.Black, true, Constant.NameFontPath);
            this.NameFieldDescription = new Text("Please enter a name for your character", false, 
                Constant.InputBoxLeftCorner, Constant.NameFieldDescriptionPositionY, 
                Constant.NameFieldDescriptionWidth, Constant.InputBoxHeight,
                Constant.NameFieldDescriptionDelay, Color.White, false, Constant.NameFontPath);
        }

        public void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            if(this.ConfirmationButtonLocation.AsRectangle().Contains(mouseState.X, mouseState.Y) && mouseState.LeftButton == ButtonState.Pressed)
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
                        Orus.Instance.GameMenu.CharacterSelectionInProgress = false;
                        Orus.Instance.IsMouseVisible = false;
                        Orus.Instance.Character = character;
                    }
                }
                catch(InvalidName exception)
                {
                    this.NameFieldDescription = new Text(exception.Message, false, 
                        Constant.InputBoxLeftCorner, Constant.NameFieldDescriptionPositionY,
                        Constant.ErrorNameFieldDescriptionWidth, Constant.InputBoxHeight,
                        Constant.NameFieldDescriptionDelay, Color.White, false, Constant.NameFontPath);
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
                    Constant.NameFieldDescriptionDelay, Color.White, false, Constant.NameFontPath);
            }
            this.NameFieldDescription.Update(gameTime, true);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.NameField.Draw(spriteBatch);
            this.NameFieldDescription.Draw(spriteBatch);
            spriteBatch.Draw(this.ConfirmationButton.Texture, this.ConfirmationButtonLocation.AsRectangle(), Color.White);

        }
    }
}
