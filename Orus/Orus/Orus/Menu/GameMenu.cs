using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orus.Constants;
using Orus.GameObjects;
using Orus.Sprites;

namespace Orus.Menu
{
    public static class GameMenu
    {
        private static Sprite mainMenuBackground;
        private static Sprite creditsBackground;
        private static Sprite creditsInfo;
        private static bool isMenuActive = true;
        private static bool isCreditsActive = false;
        private static bool isGameOn = true;
        private static Rectangle newGameButton;
        private static Rectangle creditsButton;
        private static Rectangle quitButton;
        private static Rectangle backFromCreditsButton;
        private static bool isNewGamePressed = false;
        private static bool characterSelectionInProgress = false;

        private static Sprite MainMenuBackground
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
        private static Sprite CreditsInfo
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
        private static Sprite CreditsBackground
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
        public static bool IsMenuActive
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
        public static bool IsNewGamePressed
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
        public static bool CharacterSelectionInProgress
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

        public static bool IsCreditsActive
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
        public static bool IsGameOn
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
        public static Rectangle NewGameButton
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
        public static Rectangle BackFromCreditsButton
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

        public static Rectangle CreditsButton
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
        public static Rectangle QuitButton
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

        public static void Load(ContentManager Content)
        {
            MainMenuBackground = new Sprite(Content.Load<Texture2D>("Sprites\\Background\\Main Menu"), new Point2D(0, 0));
            CreditsBackground = new Sprite(Content.Load<Texture2D>("Sprites\\Background\\CreditsBackground"), new Point2D(0, 0));
            CreditsInfo = new Sprite(Content.Load<Texture2D>("Sprites\\Background\\CreditsInfo"), new Point2D(0, 0));


            newGameButton = new Rectangle(Constant.NewGameButtonPositionX, Constant.NewGameButtonPositionY,
                                          Constant.NewGameButtonWidth, Constant.NewGameButtonHeight);
            creditsButton = new Rectangle(Constant.CreditsButtonPositionX, Constant.CreditsButtonPositionY,
                                          Constant.CreditsButtonWidth, Constant.CreditsButtonHeight);
            quitButton = new Rectangle(Constant.QuitButtonPositionX, Constant.QuitButtonPositionY,
                                          Constant.QuitButtonWidth, Constant.WindowHeight);
            backFromCreditsButton = new Rectangle(Constant.BackFromCreditsPositionX, Constant.BackFromCreditsPositionY,
                                           Constant.BackFromCreditsWidth, Constant.BackFromCreditsHeight);

            MainMenuBackground.IsActive = true;
            CreditsBackground.IsActive = false;
            CreditsInfo.IsActive = false;

        }

        public static void Update()
        {
            var mouseState = Mouse.GetState();

            //New Game BTN
            if (NewGameButton.Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Pressed) && (MainMenuBackground.IsActive == true))
            {
                IsNewGamePressed = true;
            }
            if (IsNewGamePressed)
            {
                if (NewGameButton.Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Released))
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
            if (CreditsButton.Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Pressed) && (MainMenuBackground.IsActive == true))
            {
                MainMenuBackground.IsActive = false;
                CreditsBackground.IsActive = true;
                CreditsInfo.IsActive = true;
            }
            //Back From Credits BTN
            if (BackFromCreditsButton.Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Pressed) && (MainMenuBackground.IsActive == false))
            {
                MainMenuBackground.IsActive = true;
                CreditsBackground.IsActive = false;
                CreditsInfo.IsActive = false;
            }
            //Quit BTN
            if (QuitButton.Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Pressed))
            {
                Orus.Instance.Exit();
            }
            
        }


        public static void Draw(SpriteBatch spriteBatch)
        {
            CreditsBackground.Draw(spriteBatch);
            MainMenuBackground.Draw(spriteBatch);
            CreditsInfo.Draw(spriteBatch);
        }
    }
}