using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkillIssue
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmGame());
        }

        public static sbyte Input = 0;

        public static void InputSet(byte _key, bool _pressed)
        {
            if (_pressed)
                Input |= (sbyte)(1 << _key);
            else
                Input &= (sbyte)~(1 << _key);
        }

        public static bool InputCheck(byte _key)
        {
            if ((Input & (1 << _key)) > 0)
                return true;
            else
                return false;
        }
    }
}
