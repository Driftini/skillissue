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

        public float Speed { get; set; }
        public float FrictionX = 1;
        public float FrictionY = 1;
        public Vector2 Velocity;
        public Vector2 Acceleration;

        public bool Gravity { get; set; }
        public bool IsSolid { get; set; }
        public bool IsGrounded { get; set; }

        public int FrameProgress = 0;
        public int FramePointer = 0;
        public int StatePointer = 0;
        public ActorState CurrentState { get; set; }
        public FrameData CurrentFrame { get; set; }
        public List<ActorState> States = new List<ActorState>();

        public Rectangle CurrentHitbox { get; set; }
        public Bitmap CurrentSprite { get; set; }

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

        public List<Request> CurrentRequests = new List<Request>();

        public int FindStateIndex(string label)
        {
            var stateFound = States.Find(state => state.Label == label);

            if (stateFound != null)
                return States.IndexOf(stateFound);
            else
                return 0;
        }

        public void SetState(string label)
        {
            var stateIndex = FindStateIndex(label);

            if (stateIndex < 0)
                return;

            FrameProgress = 0;
            FramePointer = 0;
            StatePointer = stateIndex;
        }

        public string GetState()
        {
            return States[StatePointer].Label;
        }

        public void UpdateCollisions(Actor _collider)
        {
            if (this == _collider) return; // Do not check for collisions if
                                           // the actor currently being tested for collision
                                           // is the same one calling the method

            if (CurrentHitbox.IntersectsWith(_collider.CurrentHitbox))
            {
                CurrentCollisions.Add(_collider);

                #region Solid collision response

                if (_collider is Collider && IsSolid)
                {
                    int newPosX = Position.X;
                    int newPosY = Position.Y;

                    var intersection = CurrentHitbox;
                    intersection.Intersect(_collider.CurrentHitbox);

                    if (CurrentHitbox.Right < intersection.Left + 10)
                    {
                        newPosX -= intersection.Width;
                        Acceleration.X = 0;
                    }

                    if (CurrentHitbox.Left > intersection.Right - 10)
                    {
                        newPosX += intersection.Width;
                        Acceleration.X = 0;
                    }

                    if (CurrentHitbox.Bottom < intersection.Top + 30)
                    {
                        newPosY -= intersection.Height + 0;
                        Acceleration.Y = 0;
                        IsGrounded = true;
                    }

                    if (CurrentHitbox.Top > intersection.Bottom - 30)
                    {
                        newPosY += intersection.Height;
                        Acceleration.Y = 0;
                    }

                    Position = new Point(newPosX, newPosY);
                }

                #endregion
            }
        }

        public void UpdateMovement()
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

        public void UpdateAnimations()
        {   
            if (States.Count > 0)
            {
                CurrentState = States[StatePointer];
                CurrentFrame = CurrentState.Frames[FramePointer];

                FrameProgress++;
                if (FrameProgress >= CurrentFrame.Duration)
                {
                    FrameProgress = 0;
                    FramePointer++;
                }

                if (FramePointer >= CurrentState.Frames.Length)
                    SetState(CurrentState.NextState);

                CurrentSprite = CurrentFrame.Sprite;
                CurrentHitbox = new Rectangle(
                    location: new Point(
                            CurrentFrame.Hitbox.X + Position.X,
                            CurrentFrame.Hitbox.Y + Position.Y
                        ),
                    size: CurrentFrame.Hitbox.Size
                    );
            }
        }

        public abstract void Update();

        public void RemoveSelf() {
            CurrentRequests.Add(
                new Request(
                    type: Request.eREQUESTTYPE.REMOVE,
                    remove: ID
                    )
                );
        }

        public void Draw(Graphics _gfx)
        {
            if (CurrentSprite != null)
                _gfx.DrawImage(CurrentSprite, new Rectangle(Position.X, Position.Y, RenderSize.Width, RenderSize.Height));
        }
    }
}
