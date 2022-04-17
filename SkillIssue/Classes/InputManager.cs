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

            DMAIN = 11,
            DOVERLAYS = 12,
            DSPAWN = 19
        }

        private byte Input = 0;

        public void InputSet(byte _key, bool _pressed)
        {
            if (_pressed)
                Input |= (byte)(1 << _key);
            else
                Input &= (byte)~(1 << _key);
        }

        public bool InputCheck(byte _key)
        {
            if ((Input & (1 << _key)) > 0)
                return true;
            else
                return false;
        }
    }
}
