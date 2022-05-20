using System;
using System.Drawing;
using System.Windows.Forms;

namespace SkillIssue
{
    public partial class frmGame : Form
    {
        private Game _SkillIssue;

        public frmGame()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e) {
            // Prepare graphics optimization flags
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Initialize the game
            _SkillIssue = new Game(
                form: this,
                resolution: new Size(320, 180),
                scale: 3
            );

            _SkillIssue.Actors.Add(
                new Player(
                    position: new Point(250, 70)
                    )
                );

            _SkillIssue.Actors.Add(
                new HUD()
                );

            // colliders

            _SkillIssue.Actors.Add(
                new Collider(
                    position: new Point(0, 154),
                    size: new Size(300, 16)
                    )
                );

            _SkillIssue.Actors.Add(
                new Collider(
                    position: new Point(0, 0),
                    size: new Size(16, 180)
                    )
                );

            _SkillIssue.Actors.Add(
                new Collider(
                    position: new Point(304, 0),
                    size: new Size(16, 180)
                    )
                );

            _SkillIssue.Actors.Add(
                new Collider(
                    position: new Point(200, 120),
                    size: new Size(128, 16)
                    )
                );

            // z-index testing

            _SkillIssue.Actors.Add(
                new ZIndexTester(
                    position: new Point(200, 0),
                    zindex: Actor.eZINDEX.BACKGROUND,
                    size: new Size(400, 400),
                    speed: 1.00000001f,
                    target: 100
                    )
                );

            var rnd = new Random();

            for (int i = 0; i <= -1; i++)
            {
                _SkillIssue.Actors.Add(
                    new ZIndexTester(
                        position: new Point(rnd.Next(-200, 700), rnd.Next(-100, 400)),
                        zindex: Actor.eZINDEX.PARTICLE,
                        size: new Size(rnd.Next(20, 500), rnd.Next(20, 500)),
                        speed: (rnd.Next(100, 500) / 100),
                        target: rnd.Next(2, 50)
                        )
                    );
            }
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.LEFT, true); }
            if (e.KeyCode == Keys.D) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.RIGHT, true); }
            if (e.KeyCode == Keys.W) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.UP, true); }
            if (e.KeyCode == Keys.S) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.DOWN, true); }

            if (e.KeyCode == Keys.F1) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.DGENERAL, true); }
            if (e.KeyCode == Keys.F2) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.DOVERLAYS, true); }
            if (e.KeyCode == Keys.F3) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.DACTORS, true); }
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.LEFT, false); }
            if (e.KeyCode == Keys.D) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.RIGHT, false); }
            if (e.KeyCode == Keys.W) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.UP, false); }
            if (e.KeyCode == Keys.S) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.DOWN, false); }

            if (e.KeyCode == Keys.F1) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.DGENERAL, false); }
            if (e.KeyCode == Keys.F2) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.DOVERLAYS, false); }
            if (e.KeyCode == Keys.F3) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.DACTORS, false); }
        }

        private void GameForm_Paint(object sender, PaintEventArgs e) {
            _SkillIssue.Render(e.Graphics);
        }

        private void tmGameLoop_Tick(object sender, EventArgs e)
        {
            _SkillIssue.Update();
            Invalidate();
        }

        private void tmResetFPSstep_Tick(object sender, EventArgs e)
        {
            _SkillIssue.FPS = _SkillIssue.FPSstep;
            _SkillIssue.FPSstep = 0;
        }

        private void frmGame_MouseEnter(object sender, EventArgs e)
        {
            //Cursor.Hide();
        }

        private void frmGame_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void frmGame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.ATTACK, true); }
            if (e.Button == MouseButtons.Right) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.DASH, true); }
        }

        private void frmGame_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
