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
            RemoveSelf();
        }

        public override void Update()
        {

        }
    }
}
