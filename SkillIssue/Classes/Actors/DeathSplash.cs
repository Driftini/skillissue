using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class DeathSplash : Actor
    {
        public DeathSplash()
        {
            Position = Point.Empty;
            RenderSize = new Size(320, 180);
            zIndex = eZINDEX.HUD;

            Player = new Player(Point.Empty);

            FrameData[] Frames_Update =
            {
                new FrameData(1, Rectangle.Empty, Properties.Resources.TRANSPARENT)
            };

            States.Add(
                new ActorState("Update", Frames_Update)
                );
        }

        private Bitmap DeathSplashgBuffer { get; set; }
        private Graphics DeathSplashgBufferGFX { get; set; }

        private Player Player { get; set; }

        private void CreateGraphics()
        {
            if (DeathSplashgBuffer != null && DeathSplashgBufferGFX != null)
            {
                DeathSplashgBuffer.Dispose();
                DeathSplashgBufferGFX.Dispose();
            }

            DeathSplashgBuffer = new Bitmap(RenderSize.Width, RenderSize.Height);

            DeathSplashgBufferGFX = Graphics.FromImage(DeathSplashgBuffer);
            DeathSplashgBufferGFX.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

            DeathSplashgBufferGFX.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.Black)), new Rectangle(Position, RenderSize));

            DeathSplashgBufferGFX.DrawString("Sei morto\n", new Font("Verdana", 14f, FontStyle.Bold), new SolidBrush(Color.White), new Point(100, 8));

            DeathSplashgBufferGFX.DrawString($"Tempo: {-Player.LifeSpan.Minutes}:{-Player.LifeSpan.Seconds}\n" +
                $"Punteggio: {Player.Score}\n" +
                $"Uccisioni: {Player.Kills}\n" +
                $"Moltplicatore massimo: {Math.Round(Player.MaxMultiplier, 1)}", new Font("Verdana", 6.4f), new SolidBrush(Color.White), new Point(100, 40));

            CurrentSprite = DeathSplashgBuffer;
        }

        public override void Update()
        {
            foreach (Actor a in AllGameActors)
                if (a is Player)
                    Player = (Player)a;

            CreateGraphics();
        }
    }
}
