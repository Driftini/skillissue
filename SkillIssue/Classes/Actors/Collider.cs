using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class Collider : Actor
    {
        public Collider(Point _position, Size _size)
        {
            Position = _position;
            Size = _size;

            Speed = 0;
            zIndex = eZINDEX.SOLID;

            Sprite = Properties.Resources.floortile;
        }

        public override void Update()
        {

        }
    }
}
