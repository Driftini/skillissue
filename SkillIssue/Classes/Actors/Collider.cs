using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class Collider : Actor
    {
        public Collider(Point position, Size size, Bitmap sprite, bool flip = false)
        {
            Position = position;
            RenderSize = size;
            FacingLeft = flip;

            zIndex = eZINDEX.SOLID;

            #region States

            FrameData[] Frames_Spawn =
            {
                new FrameData(1, new Rectangle(Point.Empty, RenderSize), sprite)
            };

            States.Add(
                new ActorState("Spawn", Frames_Spawn)
                );

            #endregion
        }

        public override void Update()
        {

        }
    }
}
