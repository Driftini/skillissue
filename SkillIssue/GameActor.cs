using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Input;

namespace SkillIssue
{
    #region Not implemented
    class Hitbox
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
    }
    class FrameData // Sprite to use, duration of the frame, hitbox size...
    {
        public short Duration { get; set; }
        public Bitmap Sprite { get; set; }
        public Hitbox Hitbox { get; set; }
        public Hitbox Hurtbox { get; set; }
    }
    class State
    {

    }
    #endregion

    /// <summary>
    /// Basic non-static game object.
    /// </summary>
    abstract class GameActor
    {
        #region Not implemented
        public int FramePointer { get; set; }
        public string StatePointer { get; set; }
        public enum ZIndex { Front, Middle, Back } // Where to draw the actor on the Z axis (will involve array sorting)

        // insert states
        #endregion

        public Point Position { get; set; }

        public Size Size { get; set; }

        /// <summary>
        /// The actor's base speed. Used for movement-related math.
        /// </summary>
        public float BaseSpeed { get; set; }

        /// <summary>
        /// The actor's current velocity. Essentially, the direction it's moving towards.
        /// </summary>
        public Vector2 Velocity;

        /// <summary>
        /// The actor's current acceleration.
        /// </summary>
        public Vector2 Acceleration;

        public bool Colliding { get; set; }

        /// <summary>
        /// Called every gameloop update, contains the actor's behavior.
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Called every gameloop update, contains movement-related math.
        /// </summary>
        /// <param name="_gameTimeElapsed">Time spent since last update, used to make up for lag etc.</param>
        public void MovementUpdate(double _gameTimeElapsed)
        {
            Vector2 MoveDistance; // Adjust actual move distance to make up for lag, etc.

            Vector2.Normalize(Velocity); // This prevents the player from moving faster diagonally

            #region Friction
            if (Math.Abs(Acceleration.X) > 1) Acceleration.X /= 1.23f;
            else Acceleration.X = 0;

            if (Math.Abs(Acceleration.Y) > 1) Acceleration.Y /= 1.23f;
            else Acceleration.Y = 0;
            #endregion

            Acceleration.X += Velocity.X * BaseSpeed;
            Acceleration.Y += Velocity.Y * BaseSpeed;

            // Calculate actor movement based on acceleration and GameTimeElapsed
            MoveDistance.X = (float)(Acceleration.X * _gameTimeElapsed);
            MoveDistance.Y = (float)(Acceleration.Y * _gameTimeElapsed);

            // Finally apply movement
            Position = new Point(
                Position.X + (int)MoveDistance.X,
                Position.Y + (int)MoveDistance.Y
            );
        }

        public void CollisionUpdate(GameActor _actor)
        {
            if (Position.X < _actor.Position.X + _actor.Size.Width &&
                Position.X + Size.Width > _actor.Position.X &&
                Position.Y < _actor.Position.Y + _actor.Size.Height &&
                Position.Y + Size.Height > _actor.Position.Y)
                Colliding = true;
            else Colliding = false;
        }

        /// <summary>
        /// Draw the actor's sprite to the graphic buffer.
        /// </summary>
        /// <param name="_gfx">Graphic buffer to draw on.</param>
        public void Draw(Graphics _gfx)
        {
            _gfx.DrawImage(Sprite, new Rectangle(Position.X, Position.Y, Size.Width, Size.Height));
            _gfx.DrawRectangle(new Pen(Color.Green), new Rectangle(Position.X, Position.Y, Size.Width, Size.Height));
        }

        // To be deprecated
        public Bitmap Sprite { get; set; }
    }

    class Player : GameActor
    {
        public Player(Point _position, Bitmap _sprite)
        {
            Sprite = _sprite;
            Position = _position;

            Size = new Size(Sprite.Width, Sprite.Height);
            BaseSpeed = 12;
        }

        public override void Update()
        {
            Velocity.X = 0;
            Velocity.Y = 0;

            #region Input    
            // Set the player's velocity depending on the user input
            if ((Keyboard.GetKeyStates(Key.Right) & KeyStates.Down) > 0)
            {
                Velocity.X += BaseSpeed;
            }
            if ((Keyboard.GetKeyStates(Key.Left) & KeyStates.Down) > 0)
            {
                Velocity.X -= BaseSpeed;
            }
            if ((Keyboard.GetKeyStates(Key.Up) & KeyStates.Down) > 0)
            {
                Velocity.Y -= BaseSpeed;
            }
            if ((Keyboard.GetKeyStates(Key.Down) & KeyStates.Down) > 0)
            {
                Velocity.Y += BaseSpeed;
            }
            #endregion
        }
    }

    class DebugCollider : GameActor
    {
        public DebugCollider(Point _position)
        {
            Position = _position;

            Sprite = Properties.Resources.colliderOff;
            Size = new Size(32, 32);
            BaseSpeed = 1.1f;
        }

        private int MovementCounter = 0;

        public override void Update()
        {
            //if (MovementCounter > 32) MovementCounter = 0;
            //if (MovementCounter >= 16) Velocity.Y += BaseSpeed;
            //else if (MovementCounter >= 0) Velocity.Y -= BaseSpeed;

            //MovementCounter++;

            if (Colliding) Sprite = Properties.Resources.colliderOn;
            else Sprite = Properties.Resources.colliderOff;
        }
    }
}
