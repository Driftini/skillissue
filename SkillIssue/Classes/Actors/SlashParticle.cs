using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class SlashParticle : Projectile
    {
        public SlashParticle(Point position, bool left, bool flipY = false)
        {
            Position = position;
            FacingLeft = left;
            FlipY = flipY;

            RenderSize = new Size(16, 16);
            zIndex = eZINDEX.PARTICLE;
            Damage = 20;

            var rect = new Rectangle(Point.Empty, RenderSize);

            FrameData[] Frames_Spawn =
            {
                new FrameData(2, rect, Properties.Resources.SLASH0),
                new FrameData(2, rect, Properties.Resources.SLASH1),
                new FrameData(3, rect, Properties.Resources.SLASH2),
                new FrameData(3, rect, Properties.Resources.SLASH3),
                new FrameData(3, rect, Properties.Resources.SLASH4),
                new FrameData(1, rect, Properties.Resources.SLASH4)
            };

            States.Add(
                new ActorState("Spawn", Frames_Spawn)
                );
        }

        private Bitmap drawnSprite;

        public override void Update()
        {
            drawnSprite = new Bitmap(CurrentSprite);

            if (FramePointer >= 5)
                RemoveSelf();
        }
    }
}
