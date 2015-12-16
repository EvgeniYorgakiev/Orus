using Orus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.Quests
{
    public class SlayQuest : IQuest
    {
        private bool completed;
        private string nameOfEnemy;
        private int requiredNumber;
        private int currentNumber;

        public SlayQuest(string nameOfEnemy, int requiredNumber)
        {
            this.NameOfEnemy = nameOfEnemy;
            this.RequiredNumber = requiredNumber;
        }

        public bool Completed
        {
            get
            {
               return this.completed;
            }

            set
            {
                this.completed = value;
            }
        }

        public string NameOfEnemy
        {
            get
            {
                return this.nameOfEnemy;
            }

            set
            {
                this.nameOfEnemy = value;
            }
        }

        public int RequiredNumber
        {
            get
            {
                return this.requiredNumber;
            }

            set
            {
                this.requiredNumber = value;
            }
        }

        public int CurrentNumber
        {
            get
            {
                return this.currentNumber;
            }

            set
            {
                this.currentNumber = value;
            }
        }

        public void Update()
        {
            this.CurrentNumber++;
            if(this.CurrentNumber == this.RequiredNumber)
            {
                this.Completed = true;
            }
        }
    }
}
