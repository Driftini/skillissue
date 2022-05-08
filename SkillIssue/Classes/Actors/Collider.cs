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
            RenderSize = _size;

            Hitbox = new Rectangle(Point.Empty, RenderSize);
            zIndex = eZINDEX.SOLID;

            Sprite = Properties.Resources.floortile;
        }

        public override void Update()
        {

        }
    }
}
