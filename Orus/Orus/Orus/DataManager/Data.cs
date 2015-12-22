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
            if(Orus.Instance.Character != null)
            {
                SharpSerializer serializer = new SharpSerializer();
                //Decide which properties to ignore
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "Content");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "Components");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "LaunchParameters");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "Services");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "TargetElapsedTime");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "QuestFont");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "NameFont");
                serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "AllCharacters");
                serializer.Serialize(Orus.Instance, "save.xml");
            }
        }

        public static void Load()
        {
            SharpSerializer serializer = new SharpSerializer();
            Orus loadedGame = serializer.Deserialize("save.xml") as Orus;
            if (loadedGame.Character != null && !loadedGame.GameMenu.CharacterSelectionInProgress)
            {
                UpdateGameProperties(loadedGame);
            }
        }

        public static void UpdateGameProperties(Orus newGameProperties)
        {
            //Update the Game properties during the load
            Orus.Instance.Camera = new Camera(Orus.Instance.GraphicsDevice.Viewport);
            Orus.Instance.Character = newGameProperties.Character;
            Orus.Instance.CurrentLevelIndex = newGameProperties.CurrentLevelIndex;
            Orus.Instance.Levels = newGameProperties.Levels;
            Orus.Instance.NewGameSelection = newGameProperties.NewGameSelection;
            Orus.Instance.GameMenu = newGameProperties.GameMenu;
            Orus.Instance.GameMenu.IsMenuActive = false;
            Orus.Instance.IsMouseVisible = false;
            Orus.Instance.GameMenu.HasLoaded = true;
            Orus.Instance.GameMenu.DifferenceInPositionFromLoad = new Point2D(
                Orus.Instance.Window.ClientBounds.X - newGameProperties.Window.ClientBounds.X,
                Orus.Instance.Window.ClientBounds.Y - newGameProperties.Window.ClientBounds.Y);
        }
    }
}
