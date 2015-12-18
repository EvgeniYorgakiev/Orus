using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.GameObjects;

namespace Orus.Sprites
{
    public class Sprite
    {
        private Texture2DSubstitude texture;
        private Point2D position = Point2D.Zero();
        private Color color = Color.White;
        private Point2D origin;
        private float rotation = Constant.DefaultRotation;
        private float scale = Constant.DefaultScale;
        private float layerDepth = Constant.DefaultLayerDepth;
        private SpriteEffects spriteEffect;
        private Rectangle2D[] rectangles;
        private int frameIndex = Constant.DefaultFrameIndex;
        private bool isActive = false;
        private bool isLoop = true;

        public Sprite()
        {

        }

        public Sprite(string path, Point2D position)
        {
            this.Texture = new Texture2DSubstitude(path);
            this.Position = position;
        }

        public Sprite(string path, int frames, AnimatedGameObject animatedGameObject) : this(path, frames)
        {
            this.Position = animatedGameObject.Position;
        }

        public Sprite(string path, int frames)
        {
            this.Texture = new Texture2DSubstitude(path);
            int width = Texture.Texture.Width / frames;
            this.Rectangles = new Rectangle2D[frames];
            for (int i = 0; i < frames; i++)
            {
                this.Rectangles[i] = new Rectangle2D(i * width, Constant.DefaultYForImage, width, Texture.Texture.Height);
            }
        }

        public Texture2DSubstitude Texture
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
        public Color Color
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
        public Point2D Origin
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
        public Rectangle2D[] Rectangles
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
                    spriteBatch.Draw(this.Texture.Texture, new Vector2(this.Position.X, this.Position.Y), 
                        new Rectangle(this.Rectangles[FrameIndex].X, this.Rectangles[FrameIndex].Y ,
                        this.Rectangles[FrameIndex].Width, this.Rectangles[FrameIndex].Height),
                         this.Color, this.Rotation, new Vector2(this.Origin.X, this.Origin.Y), this.Scale, this.SpriteEffect, this.LayerDepth);
                    
                }
                else
                {
                    spriteBatch.Draw(this.Texture.Texture, new Vector2(this.Position.X, this.Position.Y), this.Color);
                }
            }
        }
    }
}
