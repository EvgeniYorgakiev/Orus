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

        //Health bar
        public const int HealthBarOffsetX = 25;
        public const int HealthBarOffsetY = 15;

        //Health bar
        public const int ExperiencePositionX = 20;
        public const int ExperiencePositionY = 500;

        //NEW GAME BTN
        public const int NewGameButtonPositionX = 730;
        public const int NewGameButtonPositionY = 215;
        public const int NewGameButtonWidth = 90;
        public const int NewGameButtonHeight = 70;

        //LOAD GAME BTN
        public const int LoadGameButtonPositionX = 350;
        public const int LoadGameButtonPositionY = 205;
        public const int LoadGameButtonWidth = 100;
        public const int LoadGameButtonHeight = 60;

        //CREDITS BTN
        public const int CreditsButtonPositionX = 486;
        public const int CreditsButtonPositionY = 145;
        public const int CreditsButtonWidth = 101;
        public const int CreditsButtonHeight = 49;

        //OPTIONS BTN
        public const int OptionsButtonPositionX = 635;
        public const int OptionsButtonPositionY = 120;
        public const int OptionsButtonWidth = 93;
        public const int OptionsButtonHeight = 75;

        //QUIT BTN
        public const int QuitButtonPositionX = 100;
        public const int QuitButtonPositionY = 424;
        public const int QuitButtonWidth = 100;
        public const int QuitButtonHeight = 100;

        //MUSIC ON/OFF BTN
        public const int MusicButtonPositionX = 400;
        public const int MusicButtonPositionY = 100;
        public const int MusicButtonWidth = 190;
        public const int MusicButtonHeight = 45;

        //CREDITS BACK BTN
        public const int BackFromCreditsPositionX = 900;
        public const int BackFromCreditsPositionY = 380;
        public const int BackFromCreditsWidth = 100;
        public const int BackFromCreditsHeight = 124;

        //New Game selection
        public const int FirstCharacterPositionX = 200;
        public const int AllCharactersPositionY = 250;

        //Name input text
        public const string NameFontPath = "Texts\\Fonts\\NameFont";
        public const string QuestFontPath = "Texts\\Fonts\\QuestFont";
        public const int NameFieldPositionY = 60;
        public const int NameFieldDescriptionPositionY = 30;
        public const int NameFieldWidth = 200;
        public const int NameFieldDescriptionWidth = 400;
        public const int ErrorNameFieldDescriptionWidth = 700;
        public const int NameFieldDelay = 250;
        public const int NameFieldDescriptionDelay = 100;
        public const int InputBoxLeftCorner = 400;
        public const int InputBoxHeight = 25;
        public const int ConfirmationButtonPositionX = 615;
        public const int ConfirmationButtonPositionY = 50;
        public const int ConfirmationButtonWidth = 119;
        public const int ConfirmationButtonHeight = 40;

        //Levels
        public const string Level1BackgroundPath = "Sprites\\Background\\Level1Background";
        public const string Level2BackgroundPath = "Sprites\\Background\\Level2Background";
        public const string SmallTreePath = "Sprites\\Background\\SmallTree";
        public const string BigTreePath = "Sprites\\Background\\BigTree";
        public const string CryptPath = "Sprites\\Background\\Crypt";
        public const int CryptPositionX = 700;
        public const int CryptPositionY = 115;
        public const int CryptWidth = 150;
        public const int CryptHeight = 100;

        public const int MinimumNameLength = 2;
        public const float TimeForFrameInMilliSeconds = 1000f / 60f;
        public const float DefaultRotation = 0f;
        public const float DefaultScale = 1f;
        public const int DefaultFrameIndex = 0;
        public const float DefaultLayerDepth = 0.0f;
        public const float Velocity = 10f;
        public const int DefaultYForImage = 0;
        public const int DirectionIndicatingRight = 1;
        public const int DirectionIndicatingLeft = -1;
        public const int StartingPlayerXPosition = 0;
        public const int StartingPlayerYPosition = 300;
        public const int DefaultHeighForEverything = 140;
        public const double ConstantForArmorFormula = 0.06;
        public const int SpriteWidth = 120;
        public const float DefaultAnimationSpeed = 1f;

        //Characters
        public const string CrusaderDefaultName = "Crusader";
        public const string CrusaderIddleAnimationPath = "Sprites\\Characters\\Crusader\\Crusader iddle";
        public const string CrusaderMoveAnimationPath = "Sprites\\Characters\\Crusader\\Crusader move";
        public const string CrusaderAttackAnimationPath = "Sprites\\Characters\\Crusader\\Crusader attack";
        public const string CrusaderDeathAnimationPath = "Sprites\\Characters\\Crusader\\Crusader death";
        public const string CrusaderDoubleAttackAnimationPath = "Sprites\\Characters\\Crusader\\Crusader double attack";
        public const int CrusaderIddleFramesNumber = 11;
        public const int CrusaderMoveFramesNumber = 8;
        public const int CrusaderAttackFramesNumber = 8;
        public const int CrusaderDeathFramesNumber = 8;
        public const int CrusaderDoubleAttackFramesNumber = 11;
        public const int CrusaderWidth = 50;
        public const float CrusaderDefaultMoveSpeed = 1f;
        public const int CrusaderDefaultHealth = 200;
        public const int CrusaderHealthOnLevelUp = 20;
        public const int CrusaderDefaultArmor = 20;
        public const int CrusaderDefaultFireResistance = 10;
        public const int CrusaderDefaultLightingResistance = 10;
        public const int CrusaderDefaultArcaneResistance = 10;
        public const int CrusaderDefaultIceResistance = 10;
        public const int CrusaderDefaultAttackDamage = 30;
        public const int CrusaderDamageOnLevelUp = 4;
        public const int CrusaderAttackRange = 20;
        public const int CrusaderAttackFrame = 8;
        public const float CrusaderAttackSpeed = 1;

        //Enemies
        public const string ZombieDefaultName = "Zombie";
        public const string ZombieIddleAnimationPath = "Sprites\\Enemies\\Zombie\\Zombie iddle";
        public const string ZombieMoveAnimationPath = "Sprites\\Enemies\\Zombie\\Zombie move";
        public const string ZombieAttackAnimationPath = "Sprites\\Enemies\\Zombie\\Zombie attack";
        public const string ZombieDeathAnimationPath = "Sprites\\Enemies\\Zombie\\Zombie death";
        public const int ZombieIddleFramesNumber = 13;
        public const int ZombieMoveFramesNumber = 11;
        public const int ZombieAttackFramesNumber = 5;
        public const int ZombieDeathFramesNumber = 14;
        public const int ZombieWidth = 50;
        public const float ZombieDefaultMoveSpeed = 0.3f;
        public const int ZombieDefaultHealth = 90;
        public const int ZombieDefaultArmor = 5;
        public const int ZombieDefaultFireResistance = 0;
        public const int ZombieDefaultLightingResistance = 0;
        public const int ZombieDefaultArcaneResistance = 0;
        public const int ZombieDefaultIceResistance = 0;
        public const int ZombieDefaultAttackDamage = 30;
        public const int ZombieAttackRange = 10;
        public const int ZombieAttackFrame = 4;
        public const float ZombieAttackSpeed = 0.2f;
        public const int ZombieExperience = 30;

        public const string SkeletonDefaultName = "Skeleton";
        public const string SkeletonIddleAnimationPath = "Sprites\\Enemies\\Skeleton\\Skeleton iddle";
        public const string SkeletonMoveAnimationPath = "Sprites\\Enemies\\Skeleton\\Skeleton move";
        public const string SkeletonAttackAnimationPath = "Sprites\\Enemies\\Skeleton\\Skeleton attack";
        public const string SkeletonDeathAnimationPath = "Sprites\\Enemies\\Skeleton\\Skeleton death";
        public const int SkeletonIddleFramesNumber = 5;
        public const int SkeletonMoveFramesNumber = 9;
        public const int SkeletonAttackFramesNumber = 5;
        public const int SkeletonDeathFramesNumber = 7;
        public const int SkeletonWidth = 50;
        public const float SkeletonDefaultMoveSpeed = 1f;
        public const int SkeletonDefaultHealth = 100;
        public const int SkeletonDefaultArmor = 5;
        public const int SkeletonDefaultFireResistance = 5;
        public const int SkeletonDefaultLightingResistance = 5;
        public const int SkeletonDefaultArcaneResistance = 5;
        public const int SkeletonDefaultIceResistance = 5;
        public const int SkeletonDefaultAttackDamage = 20;
        public const int SkeletonAttackRange = 10;
        public const int SkeletonAttackFrame = 4;
        public const float SkeletonAttackSpeed = 0.25f;
        public const int SkeletonExperience = 55;

        public const string SkeletonBossDefaultName = "Skeleton Boss";
        public const string SkeletonBossIddleAnimationPath = "Sprites\\Enemies\\Skeleton\\Skeleton iddle";
        public const string SkeletonBossMoveAnimationPath = "Sprites\\Enemies\\Skeleton\\Skeleton move";
        public const string SkeletonBossAttackAnimationPath = "Sprites\\Enemies\\Skeleton\\Skeleton attack";
        public const string SkeletonBossDeathAnimationPath = "Sprites\\Enemies\\Skeleton\\Skeleton death";
        public const int SkeletonBossIddleFramesNumber = 5;
        public const int SkeletonBossMoveFramesNumber = 9;
        public const int SkeletonBossAttackFramesNumber = 5;
        public const int SkeletonBossDeathFramesNumber = 7;
        public const int SkeletonBossWidth = 50;
        public const float SkeletonBossDefaultMoveSpeed = 1f;
        public const int SkeletonBossDefaultHealth = 200;
        public const int SkeletonBossDefaultArmor = 10;
        public const int SkeletonBossDefaultFireResistance = 10;
        public const int SkeletonBossDefaultLightingResistance = 10;
        public const int SkeletonBossDefaultArcaneResistance = 10;
        public const int SkeletonBossDefaultIceResistance = 10;
        public const int SkeletonBossDefaultAttackDamage = 80;
        public const int SkeletonBossAttackRange = 10;
        public const int SkeletonBossAttackFrame = 5;
        public const float SkeletonBossAttackSpeed = 0.15f;
        public const int SkeletonBossExperience = 140;
        public const float SkeletonBossScale = 1.5f;

        public const string LichBossDefaultName = "Lich Boss";
        public const string LichBossIddleAnimationPath = "Sprites\\Enemies\\Lich\\Lich iddle";
        public const string LichBossMoveAnimationPath = "Sprites\\Enemies\\Lich\\Lich move";
        public const string LichBossAttackAnimationPath = "Sprites\\Enemies\\Lich\\Lich attack";
        public const string LichBossDeathAnimationPath = "Sprites\\Enemies\\Lich\\Lich death";
        public const int LichBossIddleFramesNumber = 4;
        public const int LichBossMoveFramesNumber = 8;
        public const int LichBossAttackFramesNumber = 5;
        public const int LichBossDeathFramesNumber = 10;
        public const int LichBossWidth = 50;
        public const float LichBossDefaultMoveSpeed = 1f;
        public const int LichBossDefaultHealth = 150;
        public const int LichBossDefaultArmor = 5;
        public const int LichBossDefaultFireResistance = 5;
        public const int LichBossDefaultLightingResistance = 5;
        public const int LichBossDefaultArcaneResistance = 5;
        public const int LichBossDefaultIceResistance = 5;
        public const int LichBossDefaultAttackDamage = 15;
        public const int LichBossAttackRange = 10;
        public const int LichBossAttackFrame = 5;
        public const float LichBossAttackSpeed = 1f;
        public const int LichBossExperience = 140;
        public const float LichBossScale = 1.25f;

        //NPCs

        public const int QuestGiverTextDelayInMilliseconds = 75;
        public const int QuestGiverTextWidth = 250;

        public const int QuestGiver1PositionY = 280;
        public const int QuestGiver1PositionX = 150;
        public const string QuestGiver1InitialText = "Milord, today when I visited my former master I found his skeleton roaming the halls of his crypt. Would you please put his skeleton to rest?";
        public const string QuestGiver1CompletedText = "Thank you milord.";
        public const int QuestGiver1OffsetFromTopForInitial = 50;
        public const int QuestGiver1OffsetFromTopForCompleted = 0;
        public const int QuestGiver1HeightForText = 50;

        public const string PeasantDefaultName = "Peasant";
        public const string PeasantIddleAnimationPath = "Sprites\\NPCS\\Peasant\\Peasant iddle";
        public const int PeasantIddleFramesNumber = 4;
        public const int PeasantWidth = 50;
    }
}
