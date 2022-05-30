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
                new GlowingBackground()
                );

            _SkillIssue.Actors.Add(
                new Player(
                    position: new Point(250, 70)
                    )
                );

            _SkillIssue.Actors.Add(
                new TutorialSplash()
                );

            _SkillIssue.Actors.Add(
                new HUD()
                );

            // platforms

            _SkillIssue.Actors.Add(
                new Collider(
                    position: new Point(100, 90),
                    size: new Size(128, 16),
                    sprite: Properties.Resources.PLATFORM
                    )
                );

            _SkillIssue.Actors.Add(
                new Collider(
                    position: new Point(200, 130),
                    size: new Size(128, 16),
                    sprite: Properties.Resources.PLATFORM
                    )
                );

            _SkillIssue.Actors.Add(
                new Collider(
                    position: new Point(0, 50),
                    size: new Size(128, 16),
                    sprite: Properties.Resources.PLATFORM
                    )
                );

            // borders

            _SkillIssue.Actors.Add(
                new Collider(
                    position: new Point(0, -16),
                    size: new Size(320, 16),
                    sprite: Properties.Resources.PLATFORM
                    )
                );

            _SkillIssue.Actors.Add(
                new Collider(
                    position: new Point(0, 0),
                    size: new Size(16, 180),
                    sprite: Properties.Resources.WALL
                    )
                );

            _SkillIssue.Actors.Add(
                new Collider(
                    position: new Point(304, 0),
                    size: new Size(16, 180),
                    sprite: Properties.Resources.WALL,
                    flip: true
                    )
                );

            _SkillIssue.Actors.Add(
                new Collider(
                    position: new Point(0, 164),
                    size: new Size(320, 32),
                    sprite: Properties.Resources.FLOOR
                    )
                );

            // turners

            _SkillIssue.Actors.Add(
                new EnemyTurner(
                    position: new Point(17, 146)
                    )
                );

            _SkillIssue.Actors.Add(
                new EnemyTurner(
                    position: new Point(302, 146)
                    )
                );

            _SkillIssue.Actors.Add(
                new EnemyTurner(
                    position: new Point(99, 74)
                    )
                );

            _SkillIssue.Actors.Add(
                new EnemyTurner(
                    position: new Point(227, 74)
                    )
                );

            _SkillIssue.Actors.Add(
                new EnemyTurner(
                    position: new Point(199, 114)
                    )
                );

            _SkillIssue.Actors.Add(
                new EnemyTurner(
                    position: new Point(300, 114)
                    )
                );

            _SkillIssue.Actors.Add(
                new EnemyTurner(
                    position: new Point(17, 34)
                    )
                );

            _SkillIssue.Actors.Add(
                new EnemyTurner(
                    position: new Point(125, 34)
                    )
                );

            // enemy spawners

            var rnd = new Random();
            var spawnMin = 9;
            var spawnMax = 15;

            _SkillIssue.Actors.Add(
                new EnemySpawner(
                    position: new Point(20, 32),
                    tillnext: rnd.Next(spawnMin, spawnMax)
                    )
                );

            _SkillIssue.Actors.Add(
                new EnemySpawner(
                    position: new Point(278, 102),
                    tillnext: rnd.Next(spawnMin, spawnMax)
                    )
                );

            _SkillIssue.Actors.Add(
                new EnemySpawner(
                    position: new Point(152, 62),
                    tillnext: rnd.Next(spawnMin, spawnMax)
                    )
                );

            _SkillIssue.Actors.Add(
                new EnemySpawner(
                    position: new Point(264, 145),
                    tillnext: rnd.Next(spawnMin, spawnMax)
                    )
                );

            _SkillIssue.Actors.Add(
                new EnemySpawner(
                    position: new Point(48, 145),
                    tillnext: rnd.Next(spawnMin, spawnMax)
                    )
                );
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
            Cursor.Hide();
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
            if (e.Button == MouseButtons.Left) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.ATTACK, false); }
            if (e.Button == MouseButtons.Right) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.DASH, false); }
        }
    }
}
