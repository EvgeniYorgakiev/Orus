using Microsoft.Xna.Framework.Media;
using Orus.Core;
using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.SubstitudeClasses
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
            this.Song = OrusTheGame.Instance.Content.Load<Song>(path);
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
                    this.Song = OrusTheGame.Instance.Content.Load<Song>(value);
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
