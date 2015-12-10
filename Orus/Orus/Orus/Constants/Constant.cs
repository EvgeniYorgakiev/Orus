using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.Constants
{
    public static class Constant
    {
        public const int WindowWidth = 1024;
        public const int WindowHeight = 512;

        //NEW GAME BTN
        public const int NewGameButtonPositionX = 730;
        public const int NewGameButtonPositionY = 215;
        public const int NewGameButtonWidth = 90;
        public const int NewGameButtonHeight = 70;

        //CREDITS BTN
        public const int CreditsButtonPositionX = 486;
        public const int CreditsButtonPositionY = 145;
        public const int CreditsButtonWidth = 101;
        public const int CreditsButtonHeight = 49;

        //QUIT BTN
        public const int QuitButtonPositionX = 100;
        public const int QuitButtonPositionY = 424;
        public const int QuitButtonWidth = 100;
        public const int QuitButtonHeight = 100;

        public const float TimeForFrameInMilliSeconds = 1000f / 60f;
        public const float DefaultRotation = 0f;
        public const float DefaultScale = 1f;
        public const int DefaultFrameIndex = 0;
        public const float DefaultLayerDepth = 0f;
        public const float Velocity = 10f;
        public const int DefaultYForImage = 0;
        public const int DirectionIndicatingRight = 1;
        public const int DirectionIndicatingLeft = -1;
        public const int StartingPlayerXPosition = 300;
        public const int StartingPlayerYPosition = 300;
        public const int DefaultHeighForEverything = 100;

        public const string CrusaderDefaultName = "Crusader";
        public const int CrusaderIddleFramesNumber = 11;
        public const int CrusaderMoveFramesNumber = 8;
        public const int CrusaderAttackFramesNumber = 8;
        public const int CrusaderDeathFramesNumber = 8;
        public const int CrusaderWidth = 50;
        public const float CrusaderDefaultMoveSpeed = 1f;
        public const int CrusaderDefaultHealth = 200;
        public const int CrusaderDefaultArmor = 20;
        public const int CrusaderDefaultFireResistance = 10;
        public const int CrusaderDefaultLightingResistance = 10;
        public const int CrusaderDefaultArcaneResistance = 10;
        public const int CrusaderDefaultIceResistance = 10;
        public const int CrusaderDefaultAttackDamage = 30;
        public const int CrusaderAttackRange = 20;
        public const int CrusaderAttackFrame = 8;

        public const string ZombieDefaultName = "Zombie";
        public const int ZombieIddleFramesNumber = 13;
        public const int ZombieMoveFramesNumber = 11;
        public const int ZombieAttackFramesNumber = 14;
        public const int ZombieDeathFramesNumber = 14;
        public const int ZombieWidth = 50;
        public const float ZombieDefaultMoveSpeed = 0.3f;
        public const int ZombieDefaultHealth = 90;
        public const int ZombieDefaultArmor = 5;
        public const int ZombieDefaultFireResistance = 0;
        public const int ZombieDefaultLightingResistance = 0;
        public const int ZombieDefaultArcaneResistance = 0;
        public const int ZombieDefaultIceResistance = 0;
        public const int ZombieDefaultAttackDamage = 10;
        public const int ZombieAttackRange = 10;
        public const int ZombieAttackFrame = 7;
    }
}
