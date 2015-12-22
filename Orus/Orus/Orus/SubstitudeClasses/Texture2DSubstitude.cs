using Microsoft.Xna.Framework.Graphics;
using Orus.Core;
using Polenter.Serialization;

namespace Orus.SubstitudeClasses
{
    public class Texture2DSubstitude
    {
        private string path;
        public Texture2D texture;
        private readonly bool isLoad = false;

        public Texture2DSubstitude()

        {
            this.isLoad = true;
        }

        public Texture2DSubstitude(string path)
        {
            this.Texture = OrusTheGame.Instance.Content.Load<Texture2D>(path);
            this.Path = path;
        }

        public string Path
        {
            get
            {
                return this.path;
            }
            set
            {
                if (this.isLoad)
                {
                    this.Texture = OrusTheGame.Instance.Content.Load<Texture2D>(value);
                }
                this.path = value;
            }
        }

        [ExcludeFromSerialization]
        public Texture2D Texture
        {
            get
            {
                return this.texture;
            }
            set
            {
                this.texture = value;
            }
        }
    }
}
