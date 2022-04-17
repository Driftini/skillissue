using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SkillIssue
{
    class Game
    {
        public Game(Form _form, Size _resolution) {
            GameForm = _form;
            Resolution = _resolution;

            // Adjust window size and position to the game resolution
            Size _oldSize = GameForm.ClientSize;
            GameForm.ClientSize = Resolution;

            GameForm.Location = new Point(
                (GameForm.Location.X - (int)(_oldSize.Width * 1.3)),
                (GameForm.Location.Y - _oldSize.Height)
            );
        }

        public Form GameForm { get; set; }

        public Size Resolution { get; set; }

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

                _actor.Update();
            }
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

            Color BGColor = Color.DarkOliveGreen;
            Color FontColor = Color.LightGray;

            _gfx.FillRectangle(new SolidBrush(BGColor), new Rectangle(0, 0, Resolution.Width, Resolution.Height));

            foreach (Actor _actor in ActorList)
            {
                _actor.Draw(_gfx);
                
                /*_gfx.DrawRectangle(
                    new Pen(FontColor),
                    new Rectangle(_actor.Position.X, _actor.Position.Y, _actor.Size.Width, _actor.Size.Height)
                );*/
            }

            _gfx.DrawString("Skill Issue prealpha\n" +
                $"FPS: {FPS}", new Font("Verdana", 7), new SolidBrush(FontColor), new Point(5, 8));

            //_gfx.DrawString("F1 Main debug panel | F2 Actor overlays | F9 Spawn test actors", new Font("Tahoma", 7, FontStyle.Bold), new SolidBrush(FontColor), new Point(3, Resolution.Height - 16));

            FPSstep++;
        }

        #endregion
    }
}
