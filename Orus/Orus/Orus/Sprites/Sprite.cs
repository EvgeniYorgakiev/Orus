using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.GameObjects;
using Orus.GameObjects.Player.Characters;

namespace Orus.Sprites
{
    public class Sprite
    {
        private Texture2D texture;
        private Point2D position = Point2D.Zero();
        private Color color = Color.White;
        private Point2D origin;
        private float rotation = Constant.DefaultRotation;
        private float scale = Constant.DefaultScale;
        private float layerDepth = Constant.DefaultLayerDepth;
        private SpriteEffects spriteEffect;
        private Rectangle[] rectangles;
        private int frameIndex = Constant.DefaultFrameIndex;
        private bool isActive = false;
        private bool isLoop = true;

        public Sprite(Texture2D Texture, Point2D position)
        {
            this.Texture = Texture;
            this.Position = position;
        }

        public Sprite(Texture2D Texture, int frames, AnimatedGameObject animatedGameObject) : this(Texture, frames)
        {
            this.Position = animatedGameObject.Position;
        }

        public Sprite(Texture2D Texture, int frames)
        {
            this.Texture = Texture;
            int width = Texture.Width / frames;
            this.Rectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
            {
                this.Rectangles[i] = new Rectangle(i * width, Constant.DefaultYForImage, width, Texture.Height);
            }
        }

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
        public Point2D Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }
        protected Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
        protected Point2D Origin
        {
            get
            {
                return this.origin;
            }
            set
            {
                this.origin = value;
            }
        }
        public float Rotation
        {
            get
            {
                return this.rotation;
            }
            set
            {
                this.rotation = value;
            }
        }
        public float Scale
        {
            get
            {
                return this.scale;
            }
            set
            {
                this.scale = value;
            }
        }
        public float LayerDepth
        {
            get
            {
                return this.layerDepth;
            }
            set
            {
                this.layerDepth = value;
            }
        }
        public SpriteEffects SpriteEffect
        {
            get
            {
                return this.spriteEffect;
            }
            set
            {
                this.spriteEffect = value;
            }
        }
        protected Rectangle[] Rectangles
        {
            get
            {
                return this.rectangles;
            }
            set
            {
                this.rectangles = value;
            }
        }
        public int FrameIndex
        {
            get
            {
                return this.frameIndex;
            }
            set
            {
                this.frameIndex = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return this.isActive;
            }
            set
            {
                this.isActive = value;
            }
        }
        public bool IsLoop
        {
            get
            {
                return this.isLoop;
            }
            set
            {
                this.isLoop = value;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(this.IsActive)
            {
                if(rectangles != null)
                {
                    spriteBatch.Draw(this.Texture, new Vector2(this.Position.X, this.Position.Y), this.Rectangles[FrameIndex],
                         this.Color, this.Rotation, new Vector2(this.Origin.X, this.Origin.Y), this.Scale, this.SpriteEffect, this.LayerDepth);
                    
                }
                else
                {
                    spriteBatch.Draw(this.Texture, new Vector2(this.Position.X, this.Position.Y), this.Color);
                }
            }
        }
    }
}
