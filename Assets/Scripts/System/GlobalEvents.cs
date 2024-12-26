using Characters;

namespace System
{
    public static class GlobalEvents
    {
        public static Action<Character> GetCharacterSelected;
        public static Action<Character> GetCharacterFightState;
        public static Action<RoundManager> GetRoundState;
    }
}