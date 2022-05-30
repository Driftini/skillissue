using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class SlashParticle : Particle
    {
        public SlashParticle(Point position, bool left, bool flipY = false, bool big = false)
        {
            FacingLeft = left;
            FlipY = flipY;

            zIndex = eZINDEX.PARTICLE;

            if (big)
            {
                position.X -= 8;
                position.Y -= 4;
                RenderSize = new Size(32, 24);
                Damage = 40;
            }
            else
            {
                RenderSize = new Size(16, 16);
                Damage = 20;
            }

            Position = position;

            var rect = new Rectangle(Point.Empty, RenderSize);

            FrameData[] Frames_Spawn =
            {
                new FrameData(2, rect, Properties.Resources.SLASH0),
                new FrameData(1, rect, Properties.Resources.SLASH1),
                new FrameData(1, rect, Properties.Resources.SLASH1),
                new FrameData(3, rect, Properties.Resources.SLASH2),
                new FrameData(3, rect, Properties.Resources.SLASH3),
                new FrameData(3, rect, Properties.Resources.SLASH4),
                new FrameData(1, rect, Properties.Resources.SLASH4)
            };

            States.Add(
                new ActorState("Spawn", Frames_Spawn)
                );
        }

        public override void Update()
        {
            if (FramePointer >= 6)
                RemoveSelf();
        }
    }
}
