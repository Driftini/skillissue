using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class GlowingBackground : Actor
    {
        public GlowingBackground()
        {
            Position = Point.Empty;
            RenderSize = new Size(320, 180);

            zIndex = eZINDEX.BACKGROUND;

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

        private Bitmap GlowingBGgBuffer { get; set; }
        private Graphics GlowingBGgBufferGFX { get; set; }

        private double bgAnimProgress = 110;
        private bool bgDecrease = false;

        private void CreateGraphics()
        {
            if (GlowingBGgBuffer != null && GlowingBGgBufferGFX != null)
            {
                GlowingBGgBuffer.Dispose();
                GlowingBGgBufferGFX.Dispose();
            }

            GlowingBGgBuffer = new Bitmap(RenderSize.Width, RenderSize.Height);
            GlowingBGgBufferGFX = Graphics.FromImage(GlowingBGgBuffer);

            Color BGColor = Color.FromArgb((byte)20, (byte)(bgAnimProgress / 2), (byte)(bgAnimProgress));

            GlowingBGgBufferGFX.FillRectangle(new SolidBrush(BGColor), new Rectangle(Point.Empty, RenderSize));

            CurrentSprite = GlowingBGgBuffer;
        }

        public override void Update()
        {
            if (bgAnimProgress > 140) bgDecrease = true;
            else if (bgAnimProgress < 70) bgDecrease = false;

            if (bgDecrease) bgAnimProgress -= .2;
            else bgAnimProgress += .2;

            CreateGraphics();
        }
    }
}
