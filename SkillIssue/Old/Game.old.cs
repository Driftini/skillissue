using System;
using System.Drawing;

namespace SkillIssue
{
    class Game
    {
        private GameActor _PlayerActor;

        private GameActor _ColliderActor;

        public Size Resolution { get; set; }

        public int FPS { get; set; }

        public int FPSstep { get; set; }

        public string GameTime { get; set; } // this is only here for debugging, should get removed

        public void Load()
        {
            // Initialize player class and set its position & sprite
            _PlayerActor = new Player(
                new Point(300, 160),
                Properties.Resources.player
            );

            // Initialize collider
            _ColliderActor = new DebugCollider(
                new Point(450, 160)
            );
        }

        public void Unload()
        {
            // TODO: Unload game resources
        }

        public void Update(TimeSpan _gameTime)
        {
            // Gametime elapsed
            double _gameTimeElapsed = _gameTime.TotalMilliseconds / 1000;

            _PlayerActor.Update();
            _PlayerActor.MovementUpdate(_gameTimeElapsed);

            _ColliderActor.CollisionUpdate(_PlayerActor);
            _ColliderActor.Update();
            _ColliderActor.MovementUpdate(_gameTimeElapsed);
        }

        public double bgAnimProgress = 100;

        public bool bgDecrease { get; set; }

        public double bgXGridPos = 0; // Transparency demonstration purposes

        public void Draw(Graphics _gfx)
        {
            #region Graphic buffer configuration
            _gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            _gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            _gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            _gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            _gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            #endregion

            #region Animated color background
            // Decide whether to increase or decrease the background brightness
            if (bgAnimProgress > 140) bgDecrease = true;
            else if (bgAnimProgress < 70) bgDecrease = false;

            if (bgDecrease) bgAnimProgress -= .2;
            else bgAnimProgress += .2;

            Color BGColor = Color.FromArgb((byte)20, (byte)(bgAnimProgress / 2), (byte)(bgAnimProgress));

            // Draw Background Color
            _gfx.FillRectangle(new SolidBrush(BGColor), new Rectangle(0, 0, Resolution.Width, Resolution.Height));
            #endregion

            #region Transparency demonstration background
            //// Draw Background pic
            //gfx.DrawImage(Properties.Resources._20_iceberg, new Rectangle(0, 0, 640, 360));

            //// Draw transparency demo grid
            //if (bgXGridPos < -15) bgXGridPos = 0;
            //bgXGridPos -= .4;

            //gfx.DrawImage(Properties.Resources.grid, new Rectangle((int)bgXGridPos, 0, 655, 360));
            #endregion
            _ColliderActor.Draw(_gfx);
            // Draw Player Sprite
            _PlayerActor.Draw(_gfx);


            //Debug info
            _gfx.DrawString("Debug Info", new Font("Verdana", 8, FontStyle.Bold), new SolidBrush(Color.Red), new PointF(8, 8));
            _gfx.DrawString($"Resolution: {Resolution.Width}x{Resolution.Height}\nFPS: {FPS}\nGameTime: {GameTime}\n" +
                $"\n=== Player Data ===\n\n" +
                $"Position: {_PlayerActor.Position}\nVelocity: {_PlayerActor.Velocity}\nAcceleration: {_PlayerActor.Acceleration}", new Font("Verdana", 7), new SolidBrush(Color.Red), new PointF(8, 22));
        }
    }
}
