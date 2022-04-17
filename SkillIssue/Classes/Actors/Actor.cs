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
        public float Speed { get; set; }

        public Vector2 Velocity;
        public Vector2 Acceleration;

        public Bitmap Sprite;

        public enum eZINDEX
        {
            BACKGROUND = 0,
            
            ENTITY = 1, // Living, non-playable actors
            PLAYER = 2,
            PARTICLE = 3,

            SOLID = 4, // Floors, walls...
            HUD = 10
        }

        public eZINDEX zIndex;

        public void MovementUpdate()
        {
            Vector2.Normalize(Velocity); // This prevents the player from moving faster diagonally

            #region Friction
            if (Math.Abs(Acceleration.X) > 1) Acceleration.X /= 1.3f;
            else Acceleration.X = 0;

            if (Math.Abs(Acceleration.Y) > 1) Acceleration.Y /= 1.3f;
            else Acceleration.Y = 0;
            #endregion

            Acceleration.X += Velocity.X * Speed;
            Acceleration.Y += Velocity.Y * Speed;

            Velocity.X = 0;
            Velocity.Y = 0;

            // Apply the new position
            Position = new Point(
                Position.X + (int)Acceleration.X,
                Position.Y + (int)Acceleration.Y
            );
        }

        public abstract void Update();

        public void Draw(Graphics _gfx)
        {
            _gfx.DrawImage(Sprite, new Rectangle(Position.X, Position.Y, Size.Width, Size.Height));
        }
    }
}
