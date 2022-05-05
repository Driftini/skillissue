using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class Player : LiveEntity
    {
        public Player(Point _position)
        {
            Position = _position;

            Sprite = Properties.Resources.player;
            Size = new Size(Sprite.Width, Sprite.Height);
            Speed = 1.4f;
            FrictionX = 1.3f;
            Gravity = true;
            IsSolid = true;
            zIndex = eZINDEX.PLAYER;
    }

        public override void Update()
        {
            MovementUpdate();
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
