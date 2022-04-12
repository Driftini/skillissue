using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class Player : Actor
    {
        public Player(Point _position, Bitmap _sprite)
        {
            Sprite = _sprite;
            Position = _position;

            Size = new Size(128, 128);
        }
    }
}
