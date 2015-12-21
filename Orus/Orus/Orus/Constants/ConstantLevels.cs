using System.Collections.Generic;

namespace Orus.Constants
{
    public static class ConstantLevels
    {
        public static List<int> CharacterLevels()
        {
            var levels = new List<int>();
            int experience = 100;
            for (int i = 0; i < 20; i++)
            {
                experience = experience * (i + 1) + i * 20;
                levels.Add(experience);
            }
            return levels;
        }
    }
}
