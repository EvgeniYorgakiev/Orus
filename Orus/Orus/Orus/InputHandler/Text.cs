using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orus.Constants;
using Orus.Exceptions;

namespace Orus.InputHandler
{
    public class Text
    {
        private Rectangle textBox;
        private Texture2D background;
        private string textInField;
        private string parsedText;
        private string typedText;
        private double typedTextLength;
        private int delayInMilliseconds;
        private int timeSincePress;
        private bool isDoneDrawing;
        private bool isStatic;
        private Color color;
        private SpriteFont font;

        public Text(string text, bool hasBackground, int leftCorner, int topCorner, int widthOfBox, int height,
            int delayInMilliseconds, Color color, bool isStatic, SpriteFont font)
        {
            this.TextBox = new Rectangle(leftCorner, topCorner,
                        widthOfBox, height);
            if (hasBackground)
            {
                this.Background = Orus.Instance.Content.Load<Texture2D>("Texts\\TextBackground\\TextInputBackground");
            }
            this.IsStatic = isStatic;
            this.Font = font;
            this.Color = color;
            this.DelayInMilliseconds = delayInMilliseconds;
            this.IsDoneDrawing = false;
            this.TextInField = text;
            this.TypedText = "";
            this.ParsedText = ParseText(this.TextInField);
        }

        public Rectangle TextBox
        {
            get
            {
                return textBox;
            }
            set
            {
                textBox = value;
            }
        }

        public Texture2D Background
        {
            get
            {
                return background;
            }
            set
            {
                background = value;
            }
        }

        public string TextInField
        {
            get
            {
                return textInField;
            }
            set
            {
                textInField = value;
                this.IsDoneDrawing = false;
                this.ParsedText = this.ParseText(textInField);
                this.TimeSincePress = 1;
            }
        }

        public string ParsedText
        {
            get
            {
                return parsedText;
            }
            set
            {
                parsedText = value;
            }
        }

        public string TypedText
        {
            get
            {
                return typedText;
            }
            set
            {
                typedText = value;
            }
        }

        private double TypedTextLength
        {
            get
            {
                return typedTextLength;
            }
            set
            {
                typedTextLength = value;
            }
        }

        public int TimeSincePress
        {
            get
            {
                return timeSincePress;
            }
            set
            {
                timeSincePress = value;
            }
        }

        public int DelayInMilliseconds
        {
            get
            {
                return delayInMilliseconds;
            }
            set
            {
                delayInMilliseconds = value;
            }
        }

        private bool IsDoneDrawing
        {
            get
            {
                return isDoneDrawing;
            }
            set
            {
                isDoneDrawing = value;
            }
        }

        private bool IsStatic
        {
            get
            {
                return isStatic;
            }
            set
            {
                isStatic = value;
            }
        }

        private Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        private SpriteFont Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
            }
        }

        private string ParseText(string text)
        {
            string line = string.Empty;
            string returnString = string.Empty;
            string[] wordArray = text.Split(' ');

            foreach (string word in wordArray)
            {
                if (Orus.Instance.NameFont.MeasureString(line + word).Length() > this.TextBox.Width)
                {
                    if (this.IsStatic)
                    {
                        returnString = returnString + line + '\n';
                        line = string.Empty;
                    }
                    else
                    {
                        throw new InvalidName("Invalid username. It must be able to fit in the box");
                    }
                }
                line = line + word + ' ';
            }

            return returnString + line;
        }

        public void Update(GameTime gameTime, bool isStatic)
        {
            if (this.TimeSincePress == 0 && !isStatic)
            {
                this.UpdateText();
            }
            if(this.TimeSincePress > 0)
            {
                this.TimeSincePress += gameTime.ElapsedGameTime.Milliseconds;
                if(this.TimeSincePress > this.DelayInMilliseconds)
                {
                    this.TimeSincePress = 0;
                }
            }
            if (!this.IsDoneDrawing)
            {
                if (this.DelayInMilliseconds == 0)
                {
                    this.TypedText = this.ParsedText;
                    this.IsDoneDrawing = true;
                }
                else if (this.TypedTextLength < this.ParsedText.Length)
                {
                    this.TypedTextLength = this.TypedTextLength + gameTime.ElapsedGameTime.TotalMilliseconds / this.DelayInMilliseconds;

                    if (this.TypedTextLength >= this.ParsedText.Length)
                    {
                        this.TypedTextLength = this.ParsedText.Length;
                        this.IsDoneDrawing = true;
                    }
                    this.TypedText = this.ParsedText.Substring(0, (int)this.TypedTextLength);
                }
            }
        }

        private void UpdateText()
        {
            var keyboard = Keyboard.GetState();
            int shiftDifference = 0;
            if (keyboard.IsKeyDown(Keys.LeftShift))
            {
                shiftDifference = 32;
            }
            if (keyboard.IsKeyDown(Keys.Q))
            {
                this.TextInField += (char)('q' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.W))
            {
                this.TextInField += (char)('w' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.E))
            {
                this.TextInField += (char)('e' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.R))
            {
                this.TextInField += (char)('r' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.T))
            {
                this.TextInField += (char)('t' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.Y))
            {
                this.TextInField += (char)('y' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.U))
            {
                this.TextInField += (char)('u' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.I))
            {
                this.TextInField += (char)('i' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.O))
            {
                this.TextInField += (char)('o' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.P))
            {
                this.TextInField += (char)('p' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                this.TextInField += (char)('a' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                this.TextInField += (char)('s' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                this.TextInField += (char)('d' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.F))
            {
                this.TextInField += (char)('f' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.G))
            {
                this.TextInField += (char)('g' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.H))
            {
                this.TextInField += (char)('h' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.J))
            {
                this.TextInField += (char)('j' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.K))
            {
                this.TextInField += (char)('k' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.L))
            {
                this.TextInField += (char)('l' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.Z))
            {
                this.TextInField += (char)('z' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.X))
            {
                this.TextInField += (char)('x' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.C))
            {
                this.TextInField += (char)('c' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.V))
            {
                this.TextInField += (char)('v' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.B))
            {
                this.TextInField += (char)('b' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.N))
            {
                this.TextInField += (char)('n' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.M))
            {
                this.TextInField += (char)('m' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.Back) && TextInField.Length > 0)
            {
                this.TextInField = TextInField.Substring(0, TextInField.Length - 1);
                TypedText.TrimEnd();
                if(TypedText.Length > TextInField.Length)
                {
                    this.TypedText = TextInField;
                    this.TypedTextLength = TextInField.Length;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(this.Background != null)
            {
                spriteBatch.Draw(this.Background, this.TextBox, Color.White);
            }
            spriteBatch.DrawString(this.Font, this.TypedText, new Vector2(this.TextBox.X, this.TextBox.Y), this.Color);
        }
    }
}
