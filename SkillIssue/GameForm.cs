using System;
using System.Drawing;
using System.Windows.Forms;

namespace SkillIssue
{
    #region Pre-rewrite
    //public partial class GameForm : Form
    //{
    //    Timer renderTimer;
    //    GameLoop gameLoop;

    //    public GameForm()
    //    {
    //        InitializeComponent();
    //        // Set the render event
    //        Paint += GameForm_Paint;
    //        // Initialize renderTimer
    //        renderTimer = new Timer();
    //        renderTimer.Interval = 1000 / 120;
    //        renderTimer.Tick += GraphicsTimer_Tick;
    //    }

    //    private void GameForm_Load(object sender, EventArgs e)
    //    {
    //        // Optimization
    //        SetStyle(ControlStyles.UserPaint, true);
    //        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    //        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

    //        Size _GameRes = new Size(640, 360);

    //        // Set form size according to GameRes
    //        ClientSize = _GameRes;

    //        // Initialize Game
    //        Game SkilIssue = new Game();
    //        SkilIssue.Resolution = _GameRes;

    //        // Initialize and start the gameloop
    //        gameLoop = new GameLoop();
    //        gameLoop.Load(SkilIssue);
    //        gameLoop.Start();

    //        // Start the rendering timer
    //        renderTimer.Start();
    //    }

    //    private void GameForm_Paint(object sender, PaintEventArgs e)
    //    {
    //        // Render the graphic buffer on the form
    //        gameLoop.Draw(e.Graphics);
    //    }

    //    private void GraphicsTimer_Tick(object sender, EventArgs e)
    //    {
    //        // Refresh GameForm graphics
    //        Invalidate();
    //    }
    //}
    #endregion

    public partial class GameForm : Form
    {
        Game _SkillIssue;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e) {
            // Prepare some optimization flags
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Initialize the game
            _SkillIssue = new Game(
                _resolution: new Size(640, 480)
            );

            // Adjust window size to the game resolution
            ClientSize = _SkillIssue.Resolution;
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { _SkillIssue.Input |= (1 << 0); }
            if (e.KeyCode == Keys.D) { _SkillIssue.Input |= (1 << 1); }
            if (e.KeyCode == Keys.W) { _SkillIssue.Input |= (1 << 2); }
            if (e.KeyCode == Keys.S) { _SkillIssue.Input |= (1 << 3); }
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { _SkillIssue.Input &= ~(1 << 0); }
            if (e.KeyCode == Keys.D) { _SkillIssue.Input &= ~(1 << 1); }
            if (e.KeyCode == Keys.W) { _SkillIssue.Input &= ~(1 << 2); }
            if (e.KeyCode == Keys.S) { _SkillIssue.Input &= ~(1 << 3); }
        }

        private void GameForm_Paint(object sender, PaintEventArgs e) {
            
        }
    }
}
