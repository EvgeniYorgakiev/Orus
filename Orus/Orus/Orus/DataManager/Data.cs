using Orus.GameObjects.Player;
using Polenter.Serialization;

namespace Orus.DataManager
{
    public static class Data
    {
        public static void Save(object sender = null, object args = null)
        {
            SharpSerializer serializer = new SharpSerializer();
            var settings = new SharpSerializerXmlSettings();
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

        public static void Load()
        {
            SharpSerializer serializer = new SharpSerializer();
            Orus loadedGame = serializer.Deserialize("save.xml") as Orus;
            if (loadedGame.Character != null && !loadedGame.GameMenu.CharacterSelectionInProgress)
            {
                Orus.Instance.UpdateGameProperties(loadedGame);
            }
        }
    }
}
