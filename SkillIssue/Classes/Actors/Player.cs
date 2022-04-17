using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class Player : Actor
    {
        public Player(Point _position, Bitmap _sprite)
        {
            Sprite = _sprite;
            Position = _position;

            Size = new Size(128, 128);
            Speed = 2;
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
                Velocity.Y -= Speed;
            }

            if (_input.InputCheck((byte)InputManager.eKEYS.DOWN))
            {
                Velocity.Y += Speed;
            }

            #endregion
        }
    }
}
