using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class ZIndexTester : Actor
    {
        public ZIndexTester(Point position, Bitmap sprite, eZINDEX zindex, Size size, float speed, int target = 25)
        {
            Sprite = sprite;
            Position = position;
            RenderSize = size;
            zIndex = zindex;
            Speed = speed;
            MoveTarget = target;

            FrictionX = 1.3f;
            FrictionY = 1.3f;
            IsSolid = false;
    }

        private int Facing = 0; // 0 left, 1 down, 2 right, 3 up
        private int MoveCounter = 0;
        private int MoveTarget { get; set; }

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
