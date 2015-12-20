﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orus.Constants;
using Orus.GameObjects;
using Orus.Sprites;
using Polenter.Serialization;
using System.Diagnostics;

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
        private Button newGameButton;
        private Button loadGameButton;
        private Button creditsButton;
        private Button quitButton;
        private Button backButton;
        private Button optionsButton;
        private bool characterSelectionInProgress = false;
        private bool hasLoaded = false;
        private Point2D differenceInPositionFromLoad;

        public Sprite MainMenuBackground
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

        public Sprite OptionsMenuBackground
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

        public Sprite CreditsInfo
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

        public Sprite CreditsBackground
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

        [ExcludeFromSerialization]
        public bool HasLoaded
        {
            get
            {
                return this.hasLoaded;
            }
            set
            {
                this.hasLoaded = value;
            }
        }

        [ExcludeFromSerialization]
        public Point2D DifferenceInPositionFromLoad
        {
            get
            {
                return this.differenceInPositionFromLoad;
            }
            set
            {
                this.differenceInPositionFromLoad = value;
            }
        }

        //Buttons
        public Button NewGameButton
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

        public Button LoadGameButton
        {
            get
            {
                return loadGameButton;
            }
            set
            {
                loadGameButton = value;
            }
        }

        public Button BackButton
        {
            get
            {
                return backButton;
            }
            set
            {
                backButton = value;
            }
        }

        public Button OptionsButton
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

        public Button CreditsButton
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

        public Button QuitButton
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
            this.MainMenuBackground = new Sprite("Sprites\\Background\\Main Menu", new Point2D(0, 0));
            this.CreditsBackground = new Sprite("Sprites\\Background\\CreditsBackground", new Point2D(0, 0));
            this.CreditsInfo = new Sprite("Sprites\\Background\\CreditsInfo", new Point2D(0, 0));
            this.OptionsMenuBackground = new Sprite("Sprites\\Background\\CreditsBackground", new Point2D(0, 0));

            this.NewGameButton = new Button(
                new Rectangle2D(Constant.NewGameButtonPositionX, Constant.NewGameButtonPositionY,
                                Constant.NewGameButtonWidth, Constant.NewGameButtonHeight));

            this.LoadGameButton = new Button(
                new Rectangle2D(Constant.LoadGameButtonPositionX, Constant.LoadGameButtonPositionY,
                                Constant.LoadGameButtonWidth, Constant.LoadGameButtonHeight));

            this.CreditsButton = new Button(
                new Rectangle2D(Constant.CreditsButtonPositionX, Constant.CreditsButtonPositionY,
                                Constant.CreditsButtonWidth, Constant.CreditsButtonHeight));
            this.QuitButton = new Button(
                new Rectangle2D(Constant.QuitButtonPositionX, Constant.QuitButtonPositionY,
                                Constant.QuitButtonWidth, Constant.WindowHeight));
            this.BackButton = new Button(
                new Rectangle2D(Constant.BackFromCreditsPositionX, Constant.BackFromCreditsPositionY,
                                Constant.BackFromCreditsWidth, Constant.BackFromCreditsHeight));
            this.OptionsButton = new Button(
                new Rectangle2D(Constant.OptionsButtonPositionX, Constant.OptionsButtonPositionY,
                                Constant.OptionsButtonWidth, Constant.OptionsButtonHeight));

            this.MainMenuBackground.IsActive = true;
            this.CreditsBackground.IsActive = false;
            this.CreditsInfo.IsActive = false;
            this.OptionsMenuBackground.IsActive = false;
        }

        public void Update()
        {
            var mouseState = Mouse.GetState();

            Point2D mouseCoordinates = new Point2D(
                mouseState.X - this.DifferenceInPositionFromLoad.X,
                mouseState.Y - this.DifferenceInPositionFromLoad.Y);
            //if ((mouseState.LeftButton == ButtonState.Pressed))
            //{
            //    Debug.WriteLine(mouseState.X + " " + mouseState.Y);
            //}

            //New Game BTN
            CheckNewGame(mouseState, mouseCoordinates);
            //Load Game BTN
            CheckLoadGame(mouseState, mouseCoordinates);
            //Credits BTN
            CheckCredits(mouseState, mouseCoordinates);
            //Options BTN
            CheckOptions(mouseState, mouseCoordinates);
            //Back From Credits BTN / Back From Options
            CheckBackButton(mouseState, mouseCoordinates);
            //Quit BTN
            CheckQuit(mouseState, mouseCoordinates);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            this.CreditsBackground.Draw(spriteBatch);
            this.MainMenuBackground.Draw(spriteBatch);
            this.OptionsMenuBackground.Draw(spriteBatch);
            this.CreditsInfo.Draw(spriteBatch);
        }

        public void CheckNewGame(MouseState mouseState, Point2D mouseCoordinates)
        {
            if (this.NewGameButton.ButtonPressed(mouseState, this.MainMenuBackground, mouseCoordinates))
            {
                this.NewGameButton.IsButtonPressed = true;
            }
            if (this.NewGameButton.IsButtonPressed)
            {
                if (this.NewGameButton.ButtonLocation.AsRectangle().Contains((int)mouseCoordinates.X, (int)mouseCoordinates.Y) &&
                    (mouseState.LeftButton == ButtonState.Released))
                {
                    Orus.Instance.NewGame();
                    this.IsMenuActive = false;
                    this.CharacterSelectionInProgress = true;
                    this.NewGameButton.IsButtonPressed = false;
                    this.HasLoaded = true;
                }
                else if (mouseState.LeftButton == ButtonState.Released)
                {
                    this.NewGameButton.IsButtonPressed = false;
                }
            }
        }

        public void CheckLoadGame(MouseState mouseState, Point2D mouseCoordinates)
        {
            if (this.LoadGameButton.ButtonPressed(mouseState, this.MainMenuBackground, mouseCoordinates))
            {
                this.LoadGameButton.IsButtonPressed = true;
            }
            if (this.LoadGameButton.IsButtonPressed)
            {
                if (this.LoadGameButton.ButtonLocation.AsRectangle().Contains((int)mouseCoordinates.X, (int)mouseCoordinates.Y) &&
                    (mouseState.LeftButton == ButtonState.Released))
                {
                    if (this.HasLoaded)
                    {
                        this.IsMenuActive = false;
                    }
                    else
                    {
                        DataManager.Data.Load();
                    }
                    this.LoadGameButton.IsButtonPressed = false;
                }
                else if (mouseState.LeftButton == ButtonState.Released)
                {
                    this.LoadGameButton.IsButtonPressed = false;
                }
            }
        }

        public void CheckOptions(MouseState mouseState, Point2D mouseCoordinates)
        {
            if (this.OptionsButton.ButtonPressed(mouseState, this.MainMenuBackground, mouseCoordinates))
            {
                this.OptionsButton.IsButtonPressed = true;
            }
            if (this.OptionsButton.IsButtonPressed)
            {
                if (this.OptionsButton.ButtonLocation.AsRectangle().Contains((int)mouseCoordinates.X, (int)mouseCoordinates.Y) &&
                    (mouseState.LeftButton == ButtonState.Released))
                {
                    MainMenuBackground.IsActive = false;
                    OptionsMenuBackground.IsActive = true;
                    this.OptionsButton.IsButtonPressed = false;
                }
                else if (mouseState.LeftButton == ButtonState.Released)
                {
                    this.OptionsButton.IsButtonPressed = false;
                }
            }
        }

        public void CheckCredits(MouseState mouseState, Point2D mouseCoordinates)
        {
            if (this.CreditsButton.ButtonPressed(mouseState, this.MainMenuBackground, mouseCoordinates))
            {
                this.CreditsButton.IsButtonPressed = true;
            }
            if (this.CreditsButton.IsButtonPressed)
            {
                if (this.CreditsButton.ButtonLocation.AsRectangle().Contains((int)mouseCoordinates.X, (int)mouseCoordinates.Y) &&
                    (mouseState.LeftButton == ButtonState.Released))
                {
                    this.MainMenuBackground.IsActive = false;
                    this.CreditsBackground.IsActive = true;
                    this.CreditsInfo.IsActive = true;
                    this.CreditsButton.IsButtonPressed = false;
                }
                else if (mouseState.LeftButton == ButtonState.Released)
                {
                    this.CreditsButton.IsButtonPressed = false;
                }
            }
        }

        public void CheckBackButton(MouseState mouseState, Point2D mouseCoordinates)
        {
            if (this.BackButton.ButtonPressed(mouseState, this.OptionsMenuBackground, mouseCoordinates) ||
                this.BackButton.ButtonPressed(mouseState, this.CreditsBackground, mouseCoordinates))
            {
                this.BackButton.IsButtonPressed = true;
            }
            if (this.BackButton.IsButtonPressed)
            {
                if (this.BackButton.ButtonLocation.AsRectangle().Contains((int)mouseCoordinates.X, (int)mouseCoordinates.Y) &&
                    (mouseState.LeftButton == ButtonState.Released))
                {
                    this.MainMenuBackground.IsActive = true;
                    this.OptionsMenuBackground.IsActive = false;
                    this.CreditsBackground.IsActive = false;
                    this.CreditsInfo.IsActive = false;
                    this.BackButton.IsButtonPressed = false;
                }
                else if (mouseState.LeftButton == ButtonState.Released)
                {
                    this.BackButton.IsButtonPressed = false;
                }
            }
        }

        public void CheckQuit(MouseState mouseState, Point2D mouseCoordinates)
        {
            if (this.QuitButton.ButtonPressed(mouseState, this.MainMenuBackground, mouseCoordinates))
            {
                this.QuitButton.IsButtonPressed = true;
            }
            if (this.QuitButton.IsButtonPressed)
            {
                if (this.QuitButton.ButtonLocation.AsRectangle().Contains((int)mouseCoordinates.X, (int)mouseCoordinates.Y) &&
                    (mouseState.LeftButton == ButtonState.Released))
                {
                    Orus.Instance.Exit();
                    this.QuitButton.IsButtonPressed = false;
                }
                else if (mouseState.LeftButton == ButtonState.Released)
                {
                    this.QuitButton.IsButtonPressed = false;
                }
            }
        }
    }
}