using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    public class FrameData
    {
        public FrameData(int duration, Rectangle hitbox, Bitmap sprite)
        {
            Duration = duration;
            Hitbox = hitbox;
            Sprite = sprite;
        }

        public int Duration { get; set; }
        public Rectangle Hitbox { get; set; }
        public Bitmap Sprite { get; set; }
    }

    public class ActorState
    {
        public ActorState(string label, FrameData[] framesarray)
        {
            Label = label;
            Frames = framesarray;
        }

        public string Label { get; set; }
        public FrameData[] Frames { get; set; }
    }
}
