using Microsoft.Xna.Framework.Graphics;
using Polenter.Serialization;

namespace Orus.Sprites
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
            this.Font = Orus.Instance.Content.Load<SpriteFont>(path);
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
                    this.Font = Orus.Instance.Content.Load<SpriteFont>(value);
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
