using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orus.Animations;
using Orus.Constants;

namespace Orus.Menu
{
    public static class GameMenu
    {
        private static Sprite background;
        private static bool isMenuActive = true;

        private static Sprite Background { get { return background; } set { background = value; } }
        public static bool IsMenuActive { get { return isMenuActive; } set { isMenuActive = value; } }

        public static void Load(ContentManager Content)
        {
            Background = new Sprite(
                Content.Load<Texture2D>("Sprites\\Background\\Main Menu"), 
                new Vector2(0, 0));
            Background.IsActive = true;
        }

        public static void Update()
        {
            var mouse = Mouse.GetState();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            Background.Draw(spriteBatch);
        }
    }
}