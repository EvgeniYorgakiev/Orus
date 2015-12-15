using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orus.Constants;
using Orus.Exceptions;

namespace Orus.InputHandler
{
    public class TextInput
    {
        private Rectangle textBox;
        private Texture2D background;
        private string text;
        private string parsedText;
        private string typedText;
        private double typedTextLength;
        private int delayInMilliseconds;
        private int timeSincePress;
        private bool isDoneDrawing;
        private Color color;

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

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                this.IsDoneDrawing = false;
                this.ParsedText = this.ParseText(text);
                this.TimeSincePress = 1;
            }
        }

        private string ParsedText
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

        public TextInput(string text, bool hasBackground, int topCorner, int widthOfBox, int delayInMilliseconds, Color color)
        {
            this.TextBox = new Rectangle(Constant.InputBoxLeftCorner, topCorner,
                        widthOfBox, Constant.InputBoxHeight);
            if (hasBackground)
            {
                this.Background = Orus.Instance.Content.Load<Texture2D>("Texts\\TextBackground\\TextInputBackground");
            }
            this.Text = text;
            this.TypedText = "";
            this.ParsedText = ParseText(this.Text);
            this.DelayInMilliseconds = delayInMilliseconds;
            this.IsDoneDrawing = false;
            this.Color = color;
        }

        private string ParseText(string text)
        {
            string line = string.Empty;
            string returnString = string.Empty;
            string[] wordArray = text.Split(' ');

            foreach (string word in wordArray)
            {
                if (Orus.Instance.Font.MeasureString(line + word).Length() > this.TextBox.Width)
                {
                    throw new InvalidName("Invalid username. It must be able to fit in the box");
                }
                line = line + word + ' ';
            }

            return returnString + line;
        }

        public void UpdateInputNameText(GameTime gameTime, bool isStatic)
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
                this.Text += (char)('q' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.W))
            {
                this.Text += (char)('w' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.E))
            {
                this.Text += (char)('e' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.R))
            {
                this.Text += (char)('r' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.T))
            {
                this.Text += (char)('t' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.Y))
            {
                this.Text += (char)('y' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.U))
            {
                this.Text += (char)('u' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.I))
            {
                this.Text += (char)('i' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.O))
            {
                this.Text += (char)('o' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.P))
            {
                this.Text += (char)('p' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                this.Text += (char)('a' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                this.Text += (char)('s' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                this.Text += (char)('d' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.F))
            {
                this.Text += (char)('f' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.G))
            {
                this.Text += (char)('g' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.H))
            {
                this.Text += (char)('h' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.J))
            {
                this.Text += (char)('j' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.K))
            {
                this.Text += (char)('k' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.L))
            {
                this.Text += (char)('l' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.Z))
            {
                this.Text += (char)('z' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.X))
            {
                this.Text += (char)('x' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.C))
            {
                this.Text += (char)('c' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.V))
            {
                this.Text += (char)('v' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.B))
            {
                this.Text += (char)('b' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.N))
            {
                this.Text += (char)('n' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.M))
            {
                this.Text += (char)('m' - shiftDifference);
            }
            if (keyboard.IsKeyDown(Keys.Back) && Text.Length > 0)
            {
                this.Text = Text.Substring(0, Text.Length - 1);
                TypedText.TrimEnd();
                if(TypedText.Length > Text.Length)
                {
                    this.TypedText = Text;
                    this.TypedTextLength = Text.Length;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(this.Background != null)
            {
                spriteBatch.Draw(this.Background, this.TextBox, Color.White);
            }
            spriteBatch.DrawString(Orus.Instance.Font, this.TypedText, new Vector2(this.TextBox.X, this.TextBox.Y), this.Color);
        }
    }
}
