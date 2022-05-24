using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class Player : LiveEntity
    {
        public Player(Point position)
        {
            Position = position;

            RenderSize = new Size(16, 16);
            zIndex = eZINDEX.PLAYER;
            Speed = 1.000001f;
            FrictionX = 1.2f;
            Gravity = true;
            IsSolid = true;
            
            Health = 100;
            DashCooldown = 0;

            #region States

            FrameData[] Frames_Spawn =
            {
                new FrameData(1, new Rectangle(new Point(4, 3), new Size(6, 14)), Properties.Resources.PLAYER_IDLE0)
            };

            FrameData[] Frames_Inch =
            {
                new FrameData(1, new Rectangle(new Point(4, 3), new Size(6, 14)), Properties.Resources.PLAYER_INCH0)
            };

            FrameData[] Frames_Run =
            {
                new FrameData(3, new Rectangle(new Point(4, 3), new Size(6, 14)), Properties.Resources.PLAYER_RUN0),
                new FrameData(3, new Rectangle(new Point(4, 3), new Size(6, 14)), Properties.Resources.PLAYER_RUN1),
                new FrameData(3, new Rectangle(new Point(4, 3), new Size(6, 14)), Properties.Resources.PLAYER_RUN2),
                new FrameData(3, new Rectangle(new Point(4, 3), new Size(6, 14)), Properties.Resources.PLAYER_RUN3),
                new FrameData(3, new Rectangle(new Point(4, 3), new Size(6, 14)), Properties.Resources.PLAYER_RUN4),
                new FrameData(3, new Rectangle(new Point(4, 3), new Size(6, 14)), Properties.Resources.PLAYER_RUN5)
            };

            FrameData[] Frames_Jump =
            {
                new FrameData(10, new Rectangle(new Point(4, 3), new Size(6, 14)), Properties.Resources.ANIMTEST_COLL)
            };

            //FrameData[] Frames_Dash =
            //{
            //    new FrameData()
            //};

            States.Add(
                new ActorState("Spawn", Frames_Spawn)
            );

            States.Add(
                new ActorState("Inch", Frames_Inch, "Spawn")
            );

            States.Add(
                new ActorState("Run", Frames_Run)
            );

            States.Add(
                new ActorState("Jump", Frames_Jump, "Spawn")
            );

            #endregion
        }

        private int DashCooldown { get; set; }

        public override void Update()
        {
            if (GetState() != "Dash" && Acceleration.X > 1.5f)
                Acceleration = new Vector2(1.5f, Acceleration.Y);

            if (GetState() != "Dash" && Acceleration.X < -1.5f)
                Acceleration = new Vector2(-1.5f, Acceleration.Y);

            UpdateMovement();
        }

        public void InputUpdate(InputManager _input)
        {
            bool running = false;

            #region Input

            if (_input.InputCheck((byte)InputManager.eKEYS.LEFT))
            {
                Velocity.X -= Speed;
                FacingLeft = true;
                running = true;
            }

            if (_input.InputCheck((byte)InputManager.eKEYS.RIGHT))
            {
                Velocity.X += Speed;
                FacingLeft = false;
                running = true;
            }

            if (_input.InputCheck((byte)InputManager.eKEYS.LEFT) && _input.InputCheck((byte)InputManager.eKEYS.RIGHT))
                running = true;

            if (_input.InputCheck((byte)InputManager.eKEYS.UP))
            {
                if (IsGrounded)
                {
                    Velocity.Y -= 5.3f;
                    SetState("Jump");
                }
            }

            /*if (_input.InputCheck((byte)InputManager.eKEYS.DOWN))
            {
                Velocity.Y += Speed;
            }*/

            #endregion

            if (running)
            {
                if (GetState() == "Spawn")
                    SetState("Inch");

                if (GetState() == "Inch")
                    SetState("Run");
            }
            else if (GetState() == "Inch" || GetState() == "Run")
                SetState("Spawn");
        }
    }
}
