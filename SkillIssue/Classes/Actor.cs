using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    abstract class Actor
    {
        public Point Position { get; set; }
        public Size Size { get; set; }
        public int Speed { get; set; }

        public Vector2 Velocity;
        public Vector2 Acceleration;

        public Bitmap Sprite;

        public void Draw(Graphics _gfx)
        {
            _gfx.DrawImage(Sprite, new Rectangle(Position.X, Position.Y, Size.Width, Size.Height));
        }
    }
}
