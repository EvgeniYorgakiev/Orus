using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orus.Constants;
using Orus.GameObjects;
using Orus.Sprites;

namespace Orus.Menu
{
    public class GameMenu
    {
        private Sprite mainMenuBackground;
        private Sprite creditsBackground;
        private Sprite creditsInfo;
        private Sprite optionsMenuBackground;
        private bool isMenuActive = true;
        private bool isCreditsActive = false;
        private bool isGameOn = true;
        private Rectangle2D newGameButton;
        private Rectangle2D creditsButton;
        private Rectangle2D quitButton;
        private Rectangle2D backFromCreditsButton;
        private Rectangle2D optionsButton;
        private bool isNewGamePressed = false;
        private bool characterSelectionInProgress = false;

        private Sprite MainMenuBackground
        {
            get
            {
                return mainMenuBackground;
            }
            set
            {
                mainMenuBackground = value;
            }
        }
        private Sprite OptionsMenuBackground
        {
            get
            {
                return optionsMenuBackground;
            }
            set
            {
                optionsMenuBackground = value;
            }
        }
        private Rectangle2D OptionsButton
        {
            get
            {
                return optionsButton;
            }
            set
            {
                optionsButton = value;
            }
        }
        private Sprite CreditsInfo
        {
            get
            {
                return creditsInfo;
            }
            set
            {
                creditsInfo = value;
            }
        }
        private Sprite CreditsBackground
        {
            get
            {
                return creditsBackground;
            }
            set
            {
                creditsBackground = value;
            }
        }
        public bool IsMenuActive
        {
            get
            {
                return isMenuActive;
            }
            set
            {
                isMenuActive = value;
            }
        }
        public bool IsNewGamePressed
        {
            get
            {
                return isNewGamePressed;
            }
            set
            {
                isNewGamePressed = value;
            }
        }
        public bool CharacterSelectionInProgress
        {
            get
            {
                return characterSelectionInProgress;
            }
            set
            {
                characterSelectionInProgress = value;
            }
        }

        public bool IsCreditsActive
        {
            get
            {
                return isCreditsActive;
            }
            set
            {
                isCreditsActive = value;
            }
        }
        public bool IsGameOn
        {
            get
            {
                return isGameOn;
            }
            set
            {
                isGameOn = value;
            }
        }

        //Buttons
        public Rectangle2D NewGameButton
        {
            get
            {
                return newGameButton;
            }
            set
            {
                newGameButton = value;
            }
        }
        public Rectangle2D BackFromCreditsButton
        {
            get
            {
                return backFromCreditsButton;
            }
            set
            {
                backFromCreditsButton = value;
            }
        }

        public Rectangle2D CreditsButton
        {
            get
            {
                return creditsButton;
            }
            set
            {
                creditsButton = value;
            }
        }
        public Rectangle2D QuitButton
        {
            get
            {
                return quitButton;
            }
            set
            {
                quitButton = value;
            }
        }

        public void Load(ContentManager Content)
        {
            MainMenuBackground = new Sprite("Sprites\\Background\\Main Menu", new Point2D(0, 0));
            CreditsBackground = new Sprite("Sprites\\Background\\CreditsBackground", new Point2D(0, 0));
            CreditsInfo = new Sprite("Sprites\\Background\\CreditsInfo", new Point2D(0, 0));
            OptionsMenuBackground = new Sprite("Sprites\\Background\\CreditsBackground", new Point2D(0, 0));

            newGameButton = new Rectangle2D(Constant.NewGameButtonPositionX, Constant.NewGameButtonPositionY,
                                          Constant.NewGameButtonWidth, Constant.NewGameButtonHeight);
            creditsButton = new Rectangle2D(Constant.CreditsButtonPositionX, Constant.CreditsButtonPositionY,
                                          Constant.CreditsButtonWidth, Constant.CreditsButtonHeight);
            quitButton = new Rectangle2D(Constant.QuitButtonPositionX, Constant.QuitButtonPositionY,
                                          Constant.QuitButtonWidth, Constant.WindowHeight);
            backFromCreditsButton = new Rectangle2D(Constant.BackFromCreditsPositionX, Constant.BackFromCreditsPositionY,
                                          Constant.BackFromCreditsWidth, Constant.BackFromCreditsHeight);
            optionsButton = new Rectangle2D(Constant.OptionsButtonPositionX, Constant.OptionsButtonPositionY,
                                          Constant.OptionsButtonWidth, Constant.OptionsButtonHeight);

            MainMenuBackground.IsActive = true;
            CreditsBackground.IsActive = false;
            CreditsInfo.IsActive = false;
            OptionsMenuBackground.IsActive = false;
        }

        public void Update()
        {
            var mouseState = Mouse.GetState();

            //New Game BTN
            if (NewGameButton.AsRectangle().Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Pressed) && (MainMenuBackground.IsActive == true))
            {
                IsNewGamePressed = true;
            }
            if (IsNewGamePressed)
            {
                if (NewGameButton.AsRectangle().Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Released))
                {
                    isMenuActive = false;
                    CharacterSelectionInProgress = true;
                }
                else if (mouseState.LeftButton == ButtonState.Released)
                {
                    IsNewGamePressed = false;
                }
            }
            //Credits BTN
            if (CreditsButton.AsRectangle().Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Pressed) && (MainMenuBackground.IsActive == true))
            {
                MainMenuBackground.IsActive = false;
                CreditsBackground.IsActive = true;
                CreditsInfo.IsActive = true;
            }
            //Options BTN
            if (OptionsButton.AsRectangle().Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Pressed) && (MainMenuBackground.IsActive == true))
            {
                DataManager.SaveGame.Load();
            }
            //Back From Credits BTN / Back From Options
            if (BackFromCreditsButton.AsRectangle().Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Pressed) && ((CreditsBackground.IsActive == true) || (OptionsMenuBackground.IsActive == true)))
            {
                MainMenuBackground.IsActive = true;
                OptionsMenuBackground.IsActive = false;
                CreditsBackground.IsActive = false;
                CreditsInfo.IsActive = false;
            }
            //Quit BTN
            if (QuitButton.AsRectangle().Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Pressed))
            {
                Orus.Instance.Exit();
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            CreditsBackground.Draw(spriteBatch);
            MainMenuBackground.Draw(spriteBatch);
            OptionsMenuBackground.Draw(spriteBatch);
            CreditsInfo.Draw(spriteBatch);
        }
    }
}