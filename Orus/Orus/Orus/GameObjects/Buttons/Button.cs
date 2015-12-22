using Microsoft.Xna.Framework.Input;
using Orus.GameObjects;
using Orus.GameObjects.Sprites;

namespace Orus.GameObjects.Buttons
{
    public class Button : GameObject
    {
        private Rectangle2D buttonLocation;
        private bool isButtonPressed;

        public Button()
        {

        }

        public Button(Rectangle2D buttonLocation)
        {
            this.ButtonLocation = buttonLocation;
        }

        public Rectangle2D ButtonLocation
        {
            get
            {
                return buttonLocation;
            }
            set
            {
                buttonLocation = value;
            }
        }

        public bool IsButtonPressed
        {
            get
            {
                return isButtonPressed;
            }
            set
            {
                isButtonPressed = value;
            }
        }

        public bool ButtonPressed(MouseState mouseState, Sprite background, Point2D mouseCoordinates)
        {
            return this.ButtonLocation.AsRectangle().Contains((int)mouseCoordinates.X, (int)mouseCoordinates.Y) && 
                (mouseState.LeftButton == ButtonState.Pressed) && (background.IsActive == true);
        }
    }
}
