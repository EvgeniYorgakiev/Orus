using Microsoft.Xna.Framework.Graphics;
using Orus.Core;
using Polenter.Serialization;

namespace Orus.SubstitudeClasses
{
    public class SpriteFontSubstitude
    {
        private string path;
        public SpriteFont font;
        private readonly bool isLoad = false;

        public SpriteFontSubstitude()
        {
            this.isLoad = true;
        }

        public SpriteFontSubstitude(string path)
        {
            this.Font = OrusTheGame.Instance.Content.Load<SpriteFont>(path);
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
                    this.Font = OrusTheGame.Instance.Content.Load<SpriteFont>(value);
                }
                this.path = value;
            }
        }

        [ExcludeFromSerialization]
        public SpriteFont Font
        {
            get
            {
                return this.font;
            }
            set
            {
                this.font = value;
            }
        }
    }
}
