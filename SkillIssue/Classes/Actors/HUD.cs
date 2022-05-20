using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class HUD : Actor
    {
        public HUD()
        {
            Position = new Point(8, 8);
            RenderSize = new Size(132, 26);
            zIndex = eZINDEX.HUD;

            var rect = new Rectangle(-320, -160, 960, 540);

            FrameData[] Frames_Update =
            {
                new FrameData(1, rect, Properties.Resources.ANIMTEST_A1)
            };

            States.Add(
                new ActorState("Update", Frames_Update)
                );
        }

        private Point GraphicsOffset { get; set; }

        private Bitmap HUDgBuffer { get; set; }
        private Graphics HUDgBufferGFX { get; set; }

        private void CreateGraphics(Player player)
        {
            if (HUDgBuffer != null && HUDgBufferGFX != null)
            {
                HUDgBuffer.Dispose();
                HUDgBufferGFX.Dispose();
            }

            HUDgBuffer = new Bitmap(RenderSize.Width, RenderSize.Height);

            HUDgBufferGFX = Graphics.FromImage(HUDgBuffer);

            HUDgBufferGFX.DrawImage(Properties.Resources.HUD, new Rectangle(Point.Empty, RenderSize));
            HUDgBufferGFX.DrawString($"{player.Health}", new Font("Verdana", 6.4f), new SolidBrush(Color.Red), Point.Empty);

            CurrentSprite = HUDgBuffer;
        }

        public override void Update()
        {
            Player player = new Player(Point.Empty);

            foreach (Actor a in CurrentCollisions)
                if (a is Player)
                    player = (Player)a;

            CreateGraphics(player);
        }
    }
}
