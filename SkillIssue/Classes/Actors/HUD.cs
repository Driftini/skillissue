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
            RenderSize = new Size(113, 31);
            zIndex = eZINDEX.HUD;

            FrameData[] Frames_Update =
            {
                new FrameData(1, Rectangle.Empty, Properties.Resources.ANIMTEST_A1)
            };

            States.Add(
                new ActorState("Update", Frames_Update)
                );
        }

        private int PlayerHealthInterpolated = 0;

        private int PrevPlayerHealth = 0;

        private int PrevPlayerHealthInterpolated = 0;

        private int PlayerDashCooldownInterpolated = 0;

        private bool HealthDanger = false;
        
        private int HealthDangerFlash = 0;

        private Bitmap HUDgBuffer { get; set; }
        private Graphics HUDgBufferGFX { get; set; }

        private void InterpolateInt(ref int toInterpolate, int minValue, int speed)
        {
            toInterpolate -= speed;

            if (toInterpolate < minValue)
                toInterpolate = minValue;
        }

        private void CreateGraphics(Player player)
        {
            if (HUDgBuffer != null && HUDgBufferGFX != null)
            {
                HUDgBuffer.Dispose();
                HUDgBufferGFX.Dispose();
            }

            HUDgBuffer = new Bitmap(RenderSize.Width, RenderSize.Height);

            HUDgBufferGFX = Graphics.FromImage(HUDgBuffer);
            HUDgBufferGFX.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

            HUDgBufferGFX.DrawImage(Properties.Resources.HUD_BASE, new Rectangle(Point.Empty, RenderSize));

            HUDgBufferGFX.DrawImageUnscaledAndClipped(Properties.Resources.HUD_HEALTH_RED, new Rectangle(new Point(11, 1), new Size((2 * PrevPlayerHealthInterpolated + 2) / 2, 6)));
            HUDgBufferGFX.DrawImageUnscaledAndClipped(Properties.Resources.HUD_HEALTH_GREEN, new Rectangle(new Point(11,1), new Size((2 * PlayerHealthInterpolated + 2) / 2, 6)));
            
            if (HealthDanger && HealthDangerFlash > 10)
                HUDgBufferGFX.DrawImageUnscaled(Properties.Resources.HUD_HEALTH_DANGER, 0, 0);

            HUDgBufferGFX.DrawImageUnscaledAndClipped(Properties.Resources.HUD_DASH_FULL, new Rectangle(new Point(1, 7), new Size(PlayerDashCooldownInterpolated + 1, 6)));
            
            if (player.DashCooldown >= 100)
                HUDgBufferGFX.DrawImageUnscaled(Properties.Resources.HUD_DASH_READY, 105, 6);

            HUDgBufferGFX.DrawString($"{player.Score}", new Font("Verdana", 6.4f), new SolidBrush(Color.Black), new Point(1, 14));
            HUDgBufferGFX.DrawString($"{player.Score}", new Font("Verdana", 6.4f), new SolidBrush(Color.White), new Point(1, 13));

            HUDgBufferGFX.DrawString($"x{player.Multiplier}", new Font("Verdana", 7f, FontStyle.Bold), new SolidBrush(Color.Black), new Point(1, 21));
            HUDgBufferGFX.DrawString($"x{player.Multiplier}", new Font("Verdana", 7f, FontStyle.Bold), new SolidBrush(Color.White), new Point(1, 20));

            CurrentSprite = HUDgBuffer;
        }

        public override void Update()
        {
            Player player = new Player(Point.Empty);

            foreach (Actor a in AllGameActors)
                if (a is Player)
                    player = (Player)a;

            if (player.Health <= 25)
                HealthDanger = true;

            if (HealthDanger)
            {
                HealthDangerFlash++;
                if (HealthDangerFlash > 20)
                    HealthDangerFlash = 0;
            }

            InterpolateInt(ref PlayerHealthInterpolated, player.Health, 3);
            InterpolateInt(ref PrevPlayerHealthInterpolated, PrevPlayerHealth, 1);
            InterpolateInt(ref PlayerDashCooldownInterpolated, player.DashCooldown, 9);

            CreateGraphics(player);

            PrevPlayerHealth = player.Health;
        }
    }
}
