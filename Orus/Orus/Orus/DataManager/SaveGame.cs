using Microsoft.Xna.Framework;
using Orus.GameObjects.Player;
using Polenter.Serialization;
using System.Reflection;

namespace Orus.DataManager
{
    public static class SaveGame
    {
        private static SharpSerializer serializer = new SharpSerializer();

        public static void Save(object sender, object args)
        {
            var settings = new SharpSerializerXmlSettings();
            serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "Content");
            serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "Components");
            serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "GraphicsDevice");
            serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "LaunchParameters");
            serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "Services");
            serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "TargetElapsedTime");
            serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(Orus), "Window");
            serializer.Serialize(Orus.Instance, "save.xml");
        }

        public static void Load()
        {
            Orus loadedGame = serializer.Deserialize("save.xml") as Orus;
            Orus.Instance.Camera = new Camera(Orus.Instance.GraphicsDevice.Viewport);
            Orus.Instance.Character = loadedGame.Character;
            Orus.Instance.CurrentLevelIndex = loadedGame.CurrentLevelIndex;
            Orus.Instance.ItemsOnTheField = loadedGame.ItemsOnTheField;
            Orus.Instance.Levels = loadedGame.Levels;
            Orus.Instance.NewGameSelection = loadedGame.NewGameSelection;
            Orus.Instance.GameMenu = loadedGame.GameMenu;
        }
    }
}
