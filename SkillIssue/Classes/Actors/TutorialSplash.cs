using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class TutorialSplash : Actor
    {
        public TutorialSplash()
        {
            Position = Point.Empty;
            RenderSize = new Size(320, 180);
            zIndex = eZINDEX.HUD;

            FrameData[] Frames_Update =
            {
                new FrameData(280, Rectangle.Empty, Properties.Resources.TRANSPARENT),
                new FrameData(1, Rectangle.Empty, Properties.Resources.TRANSPARENT)
            };

            States.Add(
                new ActorState("Update", Frames_Update)
                );
        }

        private Bitmap TutorialSplashgBuffer { get; set; }
        private Graphics TutorialSplashgBufferGFX { get; set; }

        private void CreateGraphics()
        {
            if (TutorialSplashgBuffer != null && TutorialSplashgBufferGFX != null)
            {
                TutorialSplashgBuffer.Dispose();
                TutorialSplashgBufferGFX.Dispose();
            }

            TutorialSplashgBuffer = new Bitmap(RenderSize.Width, RenderSize.Height);

            TutorialSplashgBufferGFX = Graphics.FromImage(TutorialSplashgBuffer);
            TutorialSplashgBufferGFX.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

            TutorialSplashgBufferGFX.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.Black)), new Rectangle(Position, RenderSize));

            TutorialSplashgBufferGFX.DrawString("< Salute\n" +
                "< Scatto 8-direzionale", new Font("Verdana", 6.4f), new SolidBrush(Color.White), new Point(122, 4));

            TutorialSplashgBufferGFX.DrawString("< Punteggio\n" +
                "< Moltiplicatore punteggio", new Font("Verdana", 6.4f), new SolidBrush(Color.White), new Point(22, 21));
            
            TutorialSplashgBufferGFX.DrawString("Click sinistro         per attaccare\n" +
                "Click destro            ed 1-2 direzioni per scattare", new Font("Verdana", 6.4f), new SolidBrush(Color.White), new Point(8, 48));

            TutorialSplashgBufferGFX.DrawImageUnscaled(Properties.Resources.TUTORIAL_MLEFT, new Point(77, 50));
            TutorialSplashgBufferGFX.DrawImageUnscaled(Properties.Resources.TUTORIAL_MRIGHT, new Point(74, 60));


            TutorialSplashgBufferGFX.DrawString("Il moltiplicatore incrementa ad ogni colpo inflitto,\n" +
                "ma si resetta non appena viene ricevuto danno.\n\n" +
                "Lo scatto si ripristina nel tempo, ma le uccisioni\n" +
                "possono accelerare il processo e ripristinare leggermente\n" +
                "anche la salute.", new Font("Verdana", 6.4f), new SolidBrush(Color.White), new Point(8, 74));

            TutorialSplashgBufferGFX.DrawString("Skill Issue RC1", new Font("Verdana", 6.4f), new SolidBrush(Color.Gray), new Point(230, 163));

            CurrentSprite = TutorialSplashgBuffer;
        }

        public override void Update()
        {
            if (FramePointer == 1)
                RemoveSelf();

            CreateGraphics();
        }
    }
}
