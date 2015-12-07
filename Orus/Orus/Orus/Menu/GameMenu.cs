using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orus.Animations;
using Orus.Constants;

namespace Orus.Menu
{
    public static class GameMenu
    {
        private static Sprite mainMenuBackground;
        private static Sprite creditsBackground;
        private static bool isMenuActive = true;
        private static bool isCreditsActive = false;
        private static bool isGameOn = true;
        private static Rectangle newGameButton;
        private static Rectangle creditsButton;
        private static Rectangle quitButton;
        private static bool isNewGamePrssed = false;

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
                return isNewGamePrssed;
            }
            set
            {
                isNewGamePrssed = value;
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
            MainMenuBackground = new Sprite(Content.Load<Texture2D>("Sprites\\Background\\Main Menu"), new Vector2(0, 0));
            CreditsBackground = new Sprite(Content.Load<Texture2D>("Sprites\\Background\\CreditsBackground"), new Vector2(0, 0));
            CreditsBackground.Scale = 100f;

            newGameButton = new Rectangle(Constant.NewGameButtonPositionX, Constant.NewGameButtonPositionY,
                                          Constant.NewGameButtonWidth, Constant.NewGameButtonHeight);
            creditsButton = new Rectangle(Constant.CreditsButtonPositionX, Constant.CreditsButtonPositionY,
                                          Constant.CreditsButtonWidth, Constant.CreditsButtonHeight);
            quitButton = new Rectangle(Constant.QuitButtonPositionX, Constant.QuitButtonPositionY,
                                          Constant.QuitButtonWidth, Constant.WindowHeight);

            MainMenuBackground.IsActive = true;
            CreditsBackground.IsActive = false;

        }

        public static void Update()
        {
            var mouseState = Mouse.GetState();

            if (NewGameButton.Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Pressed) && (CreditsBackground.IsActive == false))
            {
                IsNewGamePressed = true;
            }
            if(IsNewGamePressed)
            {
                if (NewGameButton.Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Released))
                {
                    isMenuActive = false;
                    Orus.Instance.IsMouseVisible = false;
                }
                else if(mouseState.LeftButton == ButtonState.Released)
                {
                    IsNewGamePressed = false;
                }
            }


            if (CreditsButton.Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Pressed))
            {
                MainMenuBackground.IsActive = false;
                CreditsBackground.IsActive = true;
                
            }

            if (QuitButton.Contains(mouseState.X, mouseState.Y) && (mouseState.LeftButton == ButtonState.Pressed))
            {
                
            }
        }
        
        private static void Exit()
        {
                Exit();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            MainMenuBackground.Draw(spriteBatch);
            CreditsBackground.Draw(spriteBatch);
        }
    }
}