namespace Orus.Core
{
    using GameObjects.Player;
    using GameObjects.Player.Characters;
    using Levels;
    using Menu;
    using GameObjects.Sprites;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Content;
    using Constants;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using InputHandler;
    using Microsoft.Xna.Framework.Graphics;
    using SubstitudeClasses;

    public class GameInformation
    {
        private Camera camera;
        private GameMenu gameMenu;
        private Character character;
        private List<Character> allCharacters;
        private List<Level> levels;
        private int currentLevelIndex;
        private SpriteFontSubstitude questFont;
        private SpriteFontSubstitude nameFont;
        private NewGameSelection newGameSelection;

        public Camera Camera
        {
            get
            {
                return this.camera;
            }
            set
            {
                this.camera = value;
            }
        }

        public GameMenu GameMenu
        {
            get
            {
                return this.gameMenu;
            }
            set
            {
                this.gameMenu = value;
            }
        }

        public Character Character
        {
            get
            {
                return this.character;
            }
            set
            {
                this.character = value;
            }
        }

        public List<Character> AllCharacters
        {
            get
            {
                return this.allCharacters;
            }
            set
            {
                this.allCharacters = value;
            }
        }

        public List<Level> Levels
        {
            get
            {
                return this.levels;
            }
            set
            {
                this.levels = value;
            }
        }

        public int CurrentLevelIndex
        {
            get
            {
                return this.currentLevelIndex;
            }
            set
            {
                this.currentLevelIndex = value;
            }
        }

        public SpriteFontSubstitude QuestFont
        {
            get
            {
                return questFont;
            }
            set
            {
                questFont = value;
            }
        }

        public SpriteFontSubstitude NameFont
        {
            get
            {
                return nameFont;
            }
            set
            {
                nameFont = value;
            }
        }

        public void Load(ContentManager content)
        {
            this.GameMenu = new GameMenu();
            this.GameMenu.Load(content);
            this.NewGame();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (GameMenu.IsMenuActive)
            {

                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
                GameMenu.Draw(spriteBatch);
            }
            else
            {
                //We need to set the the Camera to follow the character during the game
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, this.Camera.Transform);

                //In all cases we need to draw the level
                this.Levels[this.CurrentLevelIndex].Draw(spriteBatch);
                if (GameMenu.CharacterSelectionInProgress)
                {
                    //Draw all of the characters that can be picked during character selection
                    foreach (var character in AllCharacters)
                    {
                        spriteBatch.DrawString(this.NameFont.Font, character.Name,
                        new Vector2(character.Position.X, character.Position.Y), Color.White);
                        character.DrawAnimations(spriteBatch);
                    }

                    this.NewGameSelection.Draw(spriteBatch);
                }
                else
                {
                    //Else draw the character
                    this.Character.DrawAnimations(spriteBatch);
                }
            }
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            if (GameMenu.IsMenuActive)
            {
                GameMenu.Update();
            }
            else if (GameMenu.CharacterSelectionInProgress) // If we are in the process of selecting a character
            {
                this.NewGameSelection.Update(gameTime);
                Input.UpdateCharacterSelectionInput();
                foreach (var character in AllCharacters)
                {
                    character.Update(gameTime);
                }
            }
            else //Else we are playing the game
            {
                this.Camera.Update(gameTime, this.Character.Position);
                this.Levels[this.CurrentLevelIndex].Update(gameTime);
                if (this.Character.Health > 0 ||
                    (this.Character.DeathAnimation.FrameIndex < this.Character.DeathAnimation.Rectangles.Length &&
                     this.Character.DeathAnimation.IsActive))
                {
                    //If the character is alive and his death animation is playing we need to update it
                    Input.UpdateInput(gameTime);
                    this.Character.CheckCollisionOfCharacterWithItems(this.Levels[this.CurrentLevelIndex].ItemsOnTheField);
                    this.Character.Update(gameTime);
                }
            }
        }

        public void NewGame()
        {
            //Set everything in need for a new game
            OrusTheGame.Instance.IsMouseVisible = true;
            this.Camera = new Camera(OrusTheGame.Instance.GraphicsDevice.Viewport);
            this.NameFont = new SpriteFontSubstitude(Constant.NameFontPath);
            this.QuestFont = new SpriteFontSubstitude(Constant.QuestFontPath);
            this.Levels = new List<Level>()
            {
                new Level1(),
                new OptionalLevel1(),
                new Level2()
            };
            this.AllCharacters = new List<Character>()
            {
                new Crusader(new Point2D(Constant.FirstCharacterPositionX, Constant.AllCharactersPositionY), OrusTheGame.Instance.Content)
            };
            this.CurrentLevelIndex = 0;
            this.NewGameSelection = new NewGameSelection();
            this.NewGameSelection.Load();
        }

        public NewGameSelection NewGameSelection
        {
            get
            {
                return newGameSelection;
            }
            set
            {
                newGameSelection = value;
            }
        }

    }
}
