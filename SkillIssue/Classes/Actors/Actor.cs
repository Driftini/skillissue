using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    public abstract partial class Actor
    {
        public int ID { get; set; }

        public Point Position { get; set; }
        public Size RenderSize { get; set; }
        public Rectangle Hitbox { get; set; }
        public Rectangle ActualHitbox { get; set; }
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

        public List<int> CurrentCollisions = new List<int>();

        public void CollisionUpdate(Actor _collider)
        {
            ActualHitbox = new Rectangle(
                location: new Point(
                        Hitbox.X + Position.X,
                        Hitbox.Y + Position.Y
                    ),
                size: Hitbox.Size
                );

            if (this == _collider) return; // Do not check for collisions if
                                           // the actor currently being tested for collision
                                           // is the same one calling the method

            if (ActualHitbox.IntersectsWith(_collider.ActualHitbox))
            {
                CurrentCollisions.Add(_collider.ID);

                #region Solid collision response

                if (_collider is Collider && IsSolid)
                {
                    int newPosX = Position.X;
                    int newPosY = Position.Y;

                    var intersection = ActualHitbox;
                    intersection.Intersect(_collider.ActualHitbox);


                    if (ActualHitbox.Right < intersection.Left + 10)
                    {
                        newPosX -= intersection.Width;
                        Acceleration.X = 0;
                    }

                    if (ActualHitbox.Left > intersection.Right - 10)
                    {
                        newPosX += intersection.Width;
                        Acceleration.X = 0;
                    }

                    if (ActualHitbox.Bottom < intersection.Top + 30)
                    {
                        newPosY -= intersection.Height + 0;
                        Acceleration.Y = 0;
                        IsGrounded = true;
                    }

                    if (ActualHitbox.Top > intersection.Bottom - 30)
                    {
                        newPosY += intersection.Height;
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
            _gfx.DrawImage(Sprite, new Rectangle(Position.X, Position.Y, RenderSize.Width, RenderSize.Height));
        }
    }
}
