using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SkillIssue
{
    class Game
    {
        public Game(Form _form, Size _resolution, int _scale) {
            GameForm = _form;
            Resolution = _resolution;
            Scale = _scale;

            // Adjust window size and position to the game resolution
            Size _oldSize = GameForm.ClientSize;
            GameForm.ClientSize = new Size(
                Resolution.Width * Scale - 1,
                Resolution.Height * Scale - 1
            );

            GameForm.Location = new Point(
                (GameForm.Location.X - (int)(_oldSize.Width * Scale * 1.3)),
                (GameForm.Location.Y - _oldSize.Height * Scale)
            );
        }

        public Form GameForm { get; set; }

        public Size Resolution { get; set; }

        private int Scale { get; set; }

        public int FPS { get; set; }
        public int FPSstep { get; set; }

        public InputManager Input = new InputManager();

        public List<Actor> ActorList = new List<Actor>();

        #region Gameloop

        public void Update()
        {
            ActorList = ActorList.OrderBy(_actor => _actor.zIndex).ToList();

            foreach (Actor _actor in ActorList)
            {
                if (_actor is Player)
                {
                    var _player = (Player)_actor;
                    _player.InputUpdate(Input);
                }

                _actor.CurrentCollisions.Clear();

                foreach (Actor _collider in ActorList)
                {
                    _actor.CollisionUpdate(_collider);
                }

                _actor.Update();
            }
        }

        public void Render(Graphics _gfx)
        {
            Bitmap GBuffer = new Bitmap(Resolution.Width, Resolution.Height);
            Graphics GBufferGFX = Graphics.FromImage(GBuffer);

            #region Graphics configuration
            GBufferGFX.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            GBufferGFX.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            GBufferGFX.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            GBufferGFX.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            GBufferGFX.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;

            _gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            _gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            _gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            _gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            #endregion

            Color BGColor = Color.DarkOliveGreen;
            Color FontColor = Color.LightGray;

            GBufferGFX.FillRectangle(new SolidBrush(BGColor), new Rectangle(0, 0, Resolution.Width, Resolution.Height));

            foreach (Actor _actor in ActorList)
            {
                _actor.Draw(GBufferGFX);
                GBufferGFX.DrawString($"Colliding with {_actor.CurrentCollisions.Count} actors", new Font("Verdana", 6.4f), new SolidBrush(FontColor), new Point(_actor.Position.X, _actor.Position.Y));

                GBufferGFX.DrawRectangle(
                    new Pen(FontColor),
                    new Rectangle(_actor.Position, _actor.Size)
                );
            }

            var rect1 = new Rectangle(ActorList[0].Position, ActorList[0].Size);
            var rect2 = new Rectangle(ActorList[1].Position, ActorList[1].Size);
            rect1.Intersect(rect2);

            GBufferGFX.FillRectangle(new SolidBrush(Color.Red), rect1);

            GBufferGFX.DrawString("Skill Issue prealpha\n" +
                $"FPS: {FPS}", new Font("Verdana", 6.4f), new SolidBrush(FontColor), new Point(5, 8));

            //GraphicBuffer.DrawString("F1 Main debug panel | F2 Actor overlays | F9 Spawn actor", new Font("Tahoma", 7, FontStyle.Bold), new SolidBrush(FontColor), new Point(3, Resolution.Height - 16));

            _gfx.DrawImage(GBuffer, new Rectangle(0, 0, Resolution.Width * Scale, Resolution.Height * Scale));

            GBuffer.Dispose();
            GBufferGFX.Dispose();

            FPSstep++;
        }

        #endregion
    }
}
