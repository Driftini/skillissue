using System;
using System.Drawing;
using System.Windows.Forms;

namespace SkillIssue
{
    public partial class Form1 : Form
    {
        Timer renderTimer;
        GameLoop gameLoop;

        public Form1()
        {
            InitializeComponent();
            // Initialize Paint Event
            Paint += Form1_Paint;
            // Initialize renderTimer
            renderTimer = new Timer();
            renderTimer.Interval = 1000 / 120;
            renderTimer.Tick += GraphicsTimer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optimization
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            Size _GameRes = new Size(640, 360);

            // Set form size according to GameRes
            ClientSize = _GameRes;

            // Initialize Game
            Game SkilIssue = new Game();
            SkilIssue.Resolution = _GameRes;

            // Initialize and start the gameloop
            gameLoop = new GameLoop();
            gameLoop.Load(SkilIssue);
            gameLoop.Start();

            // Start the rendering timer
            renderTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Render the graphic buffer on the form
            gameLoop.Draw(e.Graphics);
        }

        private void GraphicsTimer_Tick(object sender, EventArgs e)
        {
            // Refresh Form1 graphics
            Invalidate();
        }
    }
}
