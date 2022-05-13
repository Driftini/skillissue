using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class NullActor : Actor
    {
        public NullActor()
        {
            Position = Point.Empty;
            RenderSize = Size.Empty;

            FrameData[] Frames_Spawn =
            {
                new FrameData(1, new Rectangle(Point.Empty, RenderSize), Properties.Resources.colliderOn)
            };

            States.Add(
                new ActorState("Spawn", Frames_Spawn)
                );
        }

        public override void Update()
        {
            RemoveSelf();
        }
    }
}
