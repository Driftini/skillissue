using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class DashPuff : Particle
    {
        public DashPuff(Point position, bool left, bool flipY = false, bool big = false)
        {
            FacingLeft = left;
            FlipY = flipY;

            zIndex = eZINDEX.PARTICLE;

            if (big)
            {
                position.X -= 4;
                position.Y -= 4;
                RenderSize = new Size(12, 12);
            }
            else
                RenderSize = new Size(8, 8);

            Position = position;

            var rect = new Rectangle(Point.Empty, RenderSize);

            FrameData[] Frames_Spawn =
            {
                new FrameData(3, rect, Properties.Resources.DASHPUFF0),
                new FrameData(2, rect, Properties.Resources.DASHPUFF1),
                new FrameData(1, rect, Properties.Resources.DASHPUFF1),
                new FrameData(1, rect, Properties.Resources.DASHPUFF2),
                new FrameData(2, rect, Properties.Resources.DASHPUFF3),
                new FrameData(2, rect, Properties.Resources.DASHPUFF4),
                new FrameData(2, rect, Properties.Resources.DASHPUFF5),
                new FrameData(3, rect, Properties.Resources.DASHPUFF6),
                new FrameData(4, rect, Properties.Resources.DASHPUFF7),
                new FrameData(4, rect, Properties.Resources.DASHPUFF8),
                new FrameData(1, rect, Properties.Resources.DASHPUFF8)
            };

            States.Add(
                new ActorState("Spawn", Frames_Spawn)
                );
        }

        public override void Update()
        {
            if (FramePointer >= 9)
                RemoveSelf();
        }
    }
}
