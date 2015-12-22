using Microsoft.Xna.Framework.Media;
using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.Menu
{
    public class SongSubstitude
    {
        private string path;
        public Song song;
        private readonly bool isLoad = false;

        public SongSubstitude()

        {
            this.isLoad = true;
        }

        public SongSubstitude(string path)
        {
            this.Song = Orus.Instance.Content.Load<Song>(path);
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
                    this.Song = Orus.Instance.Content.Load<Song>(value);
                }
                this.path = value;
            }
        }

        [ExcludeFromSerialization]
        public Song Song
        {
            get
            {
                return this.song;
            }
            set
            {
                this.song = value;
            }
        }
    }
}
