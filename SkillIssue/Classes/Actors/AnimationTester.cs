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

            FrameData[] Frames_A =
            {
                new FrameData(7, Rectangle.Empty, Properties.Resources.ANIMTEST_A1),
                new FrameData(7, Rectangle.Empty, Properties.Resources.ANIMTEST_A2),
                new FrameData(7, Rectangle.Empty, Properties.Resources.ANIMTEST_A3),
                new FrameData(7, Rectangle.Empty, Properties.Resources.ANIMTEST_A4),
                new FrameData(7, Rectangle.Empty, Properties.Resources.ANIMTEST_A5),
                new FrameData(1, Rectangle.Empty, Properties.Resources.ANIMTEST_A5)
            };

            FrameData[] Frames_B =
            {
                new FrameData(7, Rectangle.Empty, Properties.Resources.ANIMTEST_B5),
                new FrameData(7, Rectangle.Empty, Properties.Resources.ANIMTEST_B4),
                new FrameData(7, Rectangle.Empty, Properties.Resources.ANIMTEST_B3),
                new FrameData(7, Rectangle.Empty, Properties.Resources.ANIMTEST_B2),
                new FrameData(7, Rectangle.Empty, Properties.Resources.ANIMTEST_B1),
                new FrameData(1, Rectangle.Empty, Properties.Resources.ANIMTEST_COLL)
            };

            States.Add(
                new ActorState("A", Frames_A)
                );

            States.Add(
                new ActorState("B", Frames_B)
                );
        }

        private int loopcount = 0;

        public override void Update()
        {
            if (StatePointer == 0 && FramePointer == 5)
                loopcount++;
            
            if (loopcount >= 1)
            {
                loopcount = 0;
                if (StatePointer == 0)
                    StatePointer = 1;
                else
                    StatePointer = 0;
            }

            if (StatePointer == 1 && FramePointer == 5)
                RemoveSelf();
        }
    }
}
