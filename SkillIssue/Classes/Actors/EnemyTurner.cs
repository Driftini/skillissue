using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class EnemyTurner : Actor
    {
        public EnemyTurner(Point position)
        {
            Position = position;

            RenderSize = new Size(2, 16);
            zIndex = eZINDEX.SOLID;

            #region States

            FrameData[] Frames_Spawn =
            {
                new FrameData(1, new Rectangle(Point.Empty, RenderSize), Properties.Resources.TRANSPARENT)
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
