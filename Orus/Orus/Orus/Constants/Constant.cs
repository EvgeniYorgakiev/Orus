using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.Constants
{
    public static class Constant
    {
        public const float TimeForFrameInMilliSeconds = 1000f / 60f;
        public const float DefaultRotation = 0f;
        public const float DefaultScale = 1f;
        public const int DefaultFrameIndex = 0;
        public const float DefaultLayerDepth = 0f;
        public const float Velocity = 10f;
        public const int DefaultYForImage = 0;
        public const int CrusaderIddleFramesNumber = 11;
        public const int CrusaderMoveFramesNumber = 8;
        public const int CrusaderAttackFramesNumber = 8;
        public const int StartingPlayerXPosition = 300;
        public const int StartingPlayerYPosition = 300;
        public const int DirectionIndicatingRight = 1;
        public const int DirectionIndicatingLeft = -1;
    }
}
