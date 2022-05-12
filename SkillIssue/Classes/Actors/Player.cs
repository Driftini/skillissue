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

            Sprite = Properties.Resources.player;
            RenderSize = new Size(Sprite.Width, Sprite.Height);
            Hitbox = new Rectangle(new Point(22, 17), new Size(19, 47));
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
