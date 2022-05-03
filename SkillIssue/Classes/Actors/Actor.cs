using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    abstract partial class Actor
    {
        public Point Position { get; set; }
        public Size Size { get; set; }
        public float Speed { get; set; }
        public float FrictionX = 1;
        public float FrictionY = 1;
        public bool Gravity { get; set; }
        public bool IsSolid { get; set; }
        public bool IsGrounded { get; set; }

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

        public List<Actor> CurrentCollisions = new List<Actor>();
        //public List

        public void CollisionUpdate(Actor _collider)
        {
            if (this == _collider) return; // Do not check for collisions if
                                           // the actor currently being tested for collision
                                           // is the same one calling the method

            var rectThis = new Rectangle(Position, Size);
            var rectCollider = new Rectangle(_collider.Position, _collider.Size);

            if (rectThis.IntersectsWith(rectCollider))
            {
                CurrentCollisions.Add(_collider);

                #region Solid collision response

                if (_collider is Collider && IsSolid)
                {
                    int newPosX = Position.X;
                    int newPosY = Position.Y;

                    rectThis.Intersect(rectCollider);

                    if (rectThis.Right < rectCollider.Left + 10)
                    {
                        newPosX -= rectThis.Size.Width;
                        Acceleration.X = 0;
                    }

                    if (rectThis.Left > rectCollider.Right - 10)
                    {
                        newPosX += rectThis.Size.Width;
                        Acceleration.X = 0;
                    }

                    if (rectThis.Bottom < rectCollider.Top + 30)
                    {
                        newPosY -= rectThis.Size.Height + 0;
                        Acceleration.Y = 0;
                        IsGrounded = true;
                    }

                    if (rectThis.Top > rectCollider.Bottom - 30)
                    {
                        newPosY += rectThis.Size.Height;
                        Acceleration.Y = 0;
                    }

                    Position = new Point(newPosX, newPosY);
                }

                #endregion
            }
        }

        public void MovementUpdate()
        {
            Vector2.Normalize(Velocity); // This prevents the player from moving faster diagonally

            #region Friction
            if (Math.Abs(Acceleration.X) > 1) Acceleration.X /= FrictionX;
            else Acceleration.X = 0;

            if (Math.Abs(Acceleration.Y) > 1) Acceleration.Y /= FrictionY;
            else Acceleration.Y = 0;
            #endregion

            #region Gravity

            if (Gravity) Acceleration.Y += 1.2f;

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
