using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SkillIssue
{
    class Game
    {
        public Game(Form _form, Size _resolution) {
            GameForm = _form;
            Resolution = _resolution;

            // Adjust window size to the game resolution
            GameForm.ClientSize = Resolution;
        }

        public Form GameForm { get; set; }

        public Size Resolution { get; set; }

        public int FPS { get; set; }
        public int FPSstep { get; set; }

        public List<Actor> ActorList = new List<Actor>();

        #region Input

        enum eKEYS
        {

        }

        public sbyte Input = 0;

        #endregion

        #region Gameloop

        public void Update()
        {

        }

        public void Render(Graphics _gfx)
        {
            #region Graphic buffer configuration
            _gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            _gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            _gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            _gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            _gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            #endregion

            Color BGColor = new Color();
            BGColor = Color.DarkOliveGreen;

            Color FontColor = new Color();
            FontColor = Color.LightGray;

            _gfx.FillRectangle(new SolidBrush(BGColor), new Rectangle(0, 0, Resolution.Width, Resolution.Height));

            foreach (Actor _actor in ActorList)
            {
                _actor.Draw(_gfx);
                
                /*_gfx.DrawRectangle(
                    new Pen(FontColor),
                    new Rectangle(_actor.Position.X, _actor.Position.Y, _actor.Size.Width, _actor.Size.Height)
                );*/
            }

            _gfx.DrawString("Skill Issue prealpha", new Font("Verdana", 8, FontStyle.Bold), new SolidBrush(FontColor), new PointF(8, 8));
            _gfx.DrawString($"FPS: {FPS}", new Font("Verdana", 7), new SolidBrush(FontColor), new PointF(8, 22));

            FPSstep++;
        }

        #endregion
    }
}
