using Orus.GameObjects.Player.Characters;

namespace Orus.Abilities
{
    public static class AbilityFactory
    {
        public static void UseAbility(int numberOfAbility, Character character)
        {
            switch (numberOfAbility)
            {
                case 1:
                    {
                        if(character is Crusader)
                        {
                            if(!(character as Crusader).DoubleStrike.IsOnCooldown)
                            {
                                (character as Crusader).DoubleStrike.Action(character);
                            }
                        }
                        break;
                    }
            }
        }
    }
}
