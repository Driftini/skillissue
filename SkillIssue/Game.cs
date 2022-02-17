using System;
using System.Drawing;

namespace SkillIssue
{
    class Game
    {
        public Game(Size _resolution) {
            Resolution = _resolution;
        }

        public Size Resolution { get; set; }

        public sbyte Input = 0;
    }
}
