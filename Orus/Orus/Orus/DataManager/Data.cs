using Orus.Core;
using Orus.GameObjects;
using Orus.GameObjects.Player;
using Polenter.Serialization;
using System;

namespace Orus.DataManager
{
    public static class Data
    {
        public static void Save(object sender = null, object args = null)
        {
            if(OrusTheGame.Instance.GameInformation.Character != null)
            {
                SharpSerializer serializer = new SharpSerializer();
                //Decide which properties to ignore
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(OrusTheGame), "Content");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(OrusTheGame), "Components");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(OrusTheGame), "LaunchParameters");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(OrusTheGame), "Services");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(OrusTheGame), "TargetElapsedTime");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(OrusTheGame), "QuestFont");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(OrusTheGame), "NameFont");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(OrusTheGame), "AllCharacters");
                serializer.Serialize(OrusTheGame.Instance, "save.xml");
            }
        }

        public static void Load()
        {
            SharpSerializer serializer = new SharpSerializer();
            OrusTheGame loadedGame = serializer.Deserialize("save.xml") as OrusTheGame;
            if(loadedGame != null)
            {
                if (loadedGame.GameInformation.Character != null && !loadedGame.GameInformation.GameMenu.CharacterSelectionInProgress)
                {
                    UpdateGameProperties(loadedGame);
                }
            }
        }

        public static void UpdateGameProperties(OrusTheGame newGameProperties)
        {
            //Update the Game properties during the load
            OrusTheGame.Instance.GameInformation.Camera = new Camera(OrusTheGame.Instance.GraphicsDevice.Viewport);
            OrusTheGame.Instance.GameInformation.Character = newGameProperties.GameInformation.Character;
            OrusTheGame.Instance.GameInformation.CurrentLevelIndex = newGameProperties.GameInformation.CurrentLevelIndex;
            OrusTheGame.Instance.GameInformation.Levels = newGameProperties.GameInformation.Levels;
            OrusTheGame.Instance.GameInformation.NewGameSelection = newGameProperties.GameInformation.NewGameSelection;
            OrusTheGame.Instance.GameInformation.GameMenu = newGameProperties.GameInformation.GameMenu;
            OrusTheGame.Instance.GameInformation.GameMenu.IsMenuActive = false;
            OrusTheGame.Instance.IsMouseVisible = false;
            OrusTheGame.Instance.GameInformation.GameMenu.HasLoaded = true;
            OrusTheGame.Instance.GameInformation.GameMenu.DifferenceInPositionFromLoad = new Point2D(
                OrusTheGame.Instance.Window.ClientBounds.X - newGameProperties.Window.ClientBounds.X,
                OrusTheGame.Instance.Window.ClientBounds.Y - newGameProperties.Window.ClientBounds.Y);
        }
    }
}
