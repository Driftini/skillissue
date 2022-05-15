using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class AnimationTester : Actor
    {
        public AnimationTester(Point position, Size size)
        {
            Position = position;
            RenderSize = size;
            zIndex = eZINDEX.ENTITY;

            var rect = new Rectangle(Point.Empty, RenderSize);

            FrameData[] Frames_A =
            {
                new FrameData(7, rect, Properties.Resources.ANIMTEST_A1),
                new FrameData(7, rect, Properties.Resources.ANIMTEST_A2),
                new FrameData(7, rect, Properties.Resources.ANIMTEST_A3),
                new FrameData(7, rect, Properties.Resources.ANIMTEST_A4),
                new FrameData(7, rect, Properties.Resources.ANIMTEST_A5)
            };

            FrameData[] Frames_B =
            {
                new FrameData(7, rect, Properties.Resources.ANIMTEST_B5),
                new FrameData(7, rect, Properties.Resources.ANIMTEST_B4),
                new FrameData(7, rect, Properties.Resources.ANIMTEST_B3),
                new FrameData(7, rect, Properties.Resources.ANIMTEST_B2),
                new FrameData(6, rect, Properties.Resources.ANIMTEST_B1),
                new FrameData(1, rect, Properties.Resources.ANIMTEST_B1)
            };

            FrameData[] Frames_Colliding =
            {
                new FrameData(20, rect, Properties.Resources.ANIMTEST_COLL),
                new FrameData(1, rect, Properties.Resources.ANIMTEST_COLL)
            };

            States.Add(
                new ActorState("A", Frames_A, "B")
                );

            States.Add(
                new ActorState("B", Frames_B, "A")
                );

            States.Add(
                new ActorState("Colliding", Frames_Colliding, "A")
                );
        }

        private int loopcount = 0;

        public override void Update()
        {
            if (GetState() == "B" && FramePointer == 5)
                loopcount++;

            foreach (Actor a in CurrentCollisions)
            {
                if (a is Player)
                    SetState("Colliding");
            }

            if (GetState() == "A" && loopcount >= 5)
                RemoveSelf();
        }
    }
}
