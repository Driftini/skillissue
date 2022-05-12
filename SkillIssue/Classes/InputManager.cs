namespace SkillIssue
{
    class InputManager
    {
        public enum eKEYS
        {
            LEFT = 0,
            RIGHT = 1,
            UP = 2,
            DOWN = 3,

            JUMP = 4,
            ATTACK = 5,
            DASH = 6,

            DGENERAL = 11,
            DOVERLAYS = 12,
            DACTORS = 13
        }

        private short Input = 0;

        public void InputSet(byte key, bool pressed)
        {
            if (pressed)
                Input |= (short)(1 << key);
            else
                Input &= (short)~(1 << key);
        }

        public bool InputCheck(byte key)
        {
            if ((Input & (1 << key)) > 0)
                return true;
            else
                return false;
        }
    }
}
