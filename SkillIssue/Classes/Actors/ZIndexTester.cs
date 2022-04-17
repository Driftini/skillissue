using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class ZIndexTester : Actor
    {
        public ZIndexTester(Point _position, Bitmap _sprite, eZINDEX _zindex, Size _size, float _speed, int _target = 25)
        {
            Sprite = _sprite;
            Position = _position;
            Size = _size;
            zIndex = _zindex;
            Speed = _speed;
            MoveTarget = _target;
        }

        private int Facing = 0; // 0 left, 1 down, 2 right, 3 up
        private int MoveCounter = 0;
        private int MoveTarget;

        public override void Update()
        {
            switch (Facing)
            {
                case 0:
                    Velocity.X -= Speed;
                    break;
                case 1:
                    Velocity.Y += Speed;
                    break;
                case 2:
                    Velocity.X += Speed;
                    break;
                case 3:
                    Velocity.Y -= Speed;
                    break;
                default:
                    Facing = 0;
                    break;
            }

            MoveCounter++;
            if (MoveCounter > MoveTarget)
            {
                MoveCounter = 0;
                Facing++;
            };

            MovementUpdate();
        }
    }
}
