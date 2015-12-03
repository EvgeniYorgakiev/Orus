using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.GameObjects;
using Orus.GameObjects.Player.Characters;

namespace Orus.Animations
{
    public class Sprite
    {
        private Texture2D texture;
        private Vector2 position = Vector2.Zero;
        private Color color = Color.White;
        private Vector2 origin;
        private float rotation = Constant.DefaultRotation;
        private float scale = Constant.DefaultScale;
        private SpriteEffects spriteEffect;
        private Rectangle[] rectangles;
        private int frameIndex = Constant.DefaultFrameIndex;
        private bool isActive = false;
        private bool isLoop = true;

        protected Texture2D Texture { get { return this.texture; } set { this.texture = value; } }
        public Vector2 Position { get { return this.position; } set { this.position = value; } }
        protected Color Color { get { return this.color; } set { this.color = value; } }
        protected Vector2 Origin { get { return this.origin; } set { this.origin = value; } }
        public float Rotation { get { return this.rotation; } set { this.rotation = value; } }
        protected float Scale { get { return this.scale; } set { this.scale = value; } }
        public SpriteEffects SpriteEffect { get { return this.spriteEffect; } set { this.spriteEffect = value; } }
        protected Rectangle[] Rectangles { get { return this.rectangles; } set { this.rectangles = value; } }
        protected int FrameIndex { get { return this.frameIndex; } set { this.frameIndex = value; } }
        public bool IsActive { get { return this.isActive; } set { this.isActive = value; } }
        public bool IsLoop { get { return this.isLoop; } set { this.isLoop = value; } }

        public Sprite(Texture2D Texture, Vector2 position)
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

        public void Draw(SpriteBatch spriteBatch)
        {
            if(this.IsActive)
            {
                if(rectangles != null)
                {
                    spriteBatch.Draw(this.Texture, this.Position, this.Rectangles[FrameIndex],
                         this.Color, this.Rotation, this.Origin, this.Scale, this.SpriteEffect, Constant.DefaultLayerDepth);
                }
                else
                {
                    spriteBatch.Draw(this.Texture, this.Position, this.Color);
                }
            }
        }
    }
}
