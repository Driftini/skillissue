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

            RenderSize = new Size(64, 64);
            zIndex = eZINDEX.PLAYER;
            Speed = 1.4f;
            FrictionX = 1.3f;
            Gravity = true;
            IsSolid = true;

            #region States

            FrameData[] Frames_Spawn =
            {
                new FrameData(1, new Rectangle(new Point(22, 17), new Size(19, 47)), Properties.Resources.player)
            };

            States.Add(
                new ActorState("Spawn", Frames_Spawn)
            );

            #endregion
        }

        public override void Update()
        {
            UpdateMovement();
        }

        public void InputUpdate(InputManager _input)
        {
            #region Input

                if (_input.InputCheck((byte)InputManager.eKEYS.LEFT))
                {
                    Velocity.X -= Speed;
                }

                if (_input.InputCheck((byte)InputManager.eKEYS.RIGHT))
                {
                    Velocity.X += Speed;
                }

                if (_input.InputCheck((byte)InputManager.eKEYS.UP))
                {
                    if (IsGrounded)
                    {
                        Velocity.Y -= 7;
                    }
                }

                /*if (_input.InputCheck((byte)InputManager.eKEYS.DOWN))
                {
                    Velocity.Y += Speed;
                }*/

                #endregion
        }
    }
}
