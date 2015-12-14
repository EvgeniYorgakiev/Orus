using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;

namespace Orus.GameObjects.Player
{
    public class Camera
    {
        private Matrix transform;
        private Viewport viewPort;
        private Point2D center;

        public Camera(Viewport viewPort)
        {
            this.ViewPort = viewPort;
            this.Center = new Point2D(0, 0);
            this.Transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-this.Center.X, -this.Center.Y, 0));
        }

        public Matrix Transform
        {
            get
            {
                return this.transform;
            }
            set
            {
                this.transform = value;
            }
        }

        private Viewport ViewPort
        {
            get
            {
                return this.viewPort;
            }
            set
            {
                this.viewPort = value;
            }
        }

        public Point2D Center
        {
            get
            {
                return this.center;
            }
            set
            {
                this.center = value;
            }
        }

        public void Update(GameTime gameTime, Point2D characterPosition)
        {
            if(characterPosition.X + Constant.WindowWidth < 
                Orus.Instance.Levels[Orus.Instance.CurrentLevelIndex].LevelBackground.Texture.Width &&
                characterPosition.X - Constant.WindowWidth / 2 > 0)
            {
                this.Center = new Point2D(characterPosition.X - Constant.WindowWidth / 2, 0);
                this.Transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                    Matrix.CreateTranslation(new Vector3(-this.Center.X, -this.Center.Y, 0));
            }
        }
    }
}
