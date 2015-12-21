using System;
using Microsoft.Xna.Framework;
using Orus.Interfaces;
using Orus.Sprites.Animations;
using Microsoft.Xna.Framework.Graphics;
using Orus.Constants;
using Orus.Texts;
using Orus.Sprites;

namespace Orus.GameObjects.NPC
{
    public class QuestGiver : AnimatedGameObject, IIddle, IInteractable
    {
        private string initialTextOnly;
        private string completedTextOnly;
        private Text initialText;
        private Text completedText;
        private IQuest quest;
        private bool updating;

        public QuestGiver()
        {

        }

        public QuestGiver(string name, Point2D position, string iddleAnimationPath, int framesForIddleAnimation, IQuest quest,
            string initialText, string completedText, int offsetFromTopForInitial, int offsetFromTopForCompleted, int heightForText) 
            : base(name, position, 
                  new Rectangle2D((int)position.X + Constant.PeasantWidth / 2, (int)position.Y,
                      Constant.PeasantWidth, Constant.DefaultHeighForEverything))
        {
            this.IddleAnimation = new FrameAnimation(
                 iddleAnimationPath,
                 framesForIddleAnimation);
            this.AnimationSpeed = 0.1f;
            this.IddleAnimation.IsActive = true;
            this.Quest = quest;
            this.InitialTextOnly = initialText;
            this.CompletedTextOnly = completedText;
            this.Position = position;
            this.InitialText = new Text(this.InitialTextOnly, false, (int)this.Position.X, (int)this.Position.Y - offsetFromTopForInitial, 
                Constant.QuestGiverTextWidth, heightForText, Constant.QuestGiverTextDelayInMilliseconds,
                Color.White, false, Constant.QuestFontPath);
            this.CompletedText = new Text(this.CompletedTextOnly, false, (int)this.Position.X, (int)this.Position.Y - offsetFromTopForCompleted,
                Constant.QuestGiverTextWidth, heightForText, Constant.QuestGiverTextDelayInMilliseconds,
                Color.White, false, Constant.QuestFontPath);
        }

        public string InitialTextOnly
        {
            get
            {
                return this.initialTextOnly;
            }
            set
            {
                this.initialTextOnly = value;
            }
        }

        public string CompletedTextOnly
        {
            get
            {
                return this.completedTextOnly;
            }
            set
            {
                this.completedTextOnly = value;
            }
        }

        public Text InitialText
        {
            get
            {
                return this.initialText;
            }
            set
            {
                this.initialText = value;
            }
        }

        public Text CompletedText
        {
            get
            {
                return this.completedText;
            }
            set
            {
                this.completedText = value;
            }
        }

        public IQuest Quest
        {
            get
            {
                return this.quest;
            }
            set
            {
                this.quest = value;
            }
        }

        public bool Updating
        {
            get
            {
                return this.updating;
            }
            set
            {
                this.updating = value;
            }
        }

        public void Interact()
        {
            this.Updating = true;
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (this.Updating)
            {
                if (!this.Quest.Completed)
                {
                    if(this.InitialText.TypedText.Length == this.InitialText.ParsedText.Length)
                    {
                        updating = false;
                    }
                    this.InitialText.Update(gameTime, true);
                }
                else
                {
                    if (this.CompletedText.TypedText.Length == this.InitialText.ParsedText.Length)
                    {
                        updating = false;
                    }
                    this.CompletedText.Update(gameTime, true);
                }
            }
        }

        public override void DrawAnimations(SpriteBatch spriteBatch)
        {
            base.DrawAnimations(spriteBatch);
            if (!this.Quest.Completed)
            {
                this.InitialText.Draw(spriteBatch);
            }
            else
            {
                this.CompletedText.Draw(spriteBatch);
            }
        }
    }
}
