﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace SkillIssue
{
    public partial class GameForm : Form
    {
        private Game _SkillIssue;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e) {
            // Prepare graphics optimization flags
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Cursor.Hide();

            // Initialize the game
            _SkillIssue = new Game(
                _form: this,
                _resolution: new Size(640, 360),
                _scale: 1
            );

            _SkillIssue.ActorList.Add(
                new Player(
                    _position: new Point(300, 200),
                    _sprite: Properties.Resources.player
                )
            );

            // colliders

            _SkillIssue.ActorList.Add(
                new Collider(
                    _position: new Point(0, 328),
                    _size: new Size(650, 32)
                )
            );

            _SkillIssue.ActorList.Add(
                new Collider(
                    _position: new Point(0, 0),
                    _size: new Size(32, 328)
                )
            );

            _SkillIssue.ActorList.Add(
                new Collider(
                    _position: new Point(608, 0),
                    _size: new Size(32, 328)
                )
            );

            _SkillIssue.ActorList.Add(
                new Collider(
                    _position: new Point(400, 200),
                    _size: new Size(128, 32)
                )
            );

            _SkillIssue.ActorList.Add(
                new Collider(
                    _position: new Point(200, 100),
                    _size: new Size(128, 32)
                )
            );

            // z-index testing

            //_SkillIssue.ActorList.Add(
            //    new ZIndexTester(
            //        _position: new Point(200, 0),
            //        _sprite: Properties.Resources.colliderOff,
            //        _zindex: Actor.eZINDEX.BACKGROUND,
            //        _size: new Size(400, 400),
            //        _speed: 1.00000001f,
            //        _target: 100
            //    )
            //);

            //var rnd = new Random();

            //for (int i = 0; i <= -1; i++)
            //{
            //    _SkillIssue.ActorList.Add(
            //        new ZIndexTester(
            //            _position: new Point(rnd.Next(-200, 700), rnd.Next(-100, 400)),
            //            _sprite: Properties.Resources.colliderOn,
            //            _zindex: Actor.eZINDEX.SOLID,
            //            _size: new Size(rnd.Next(20, 500), rnd.Next(20, 500)),
            //            _speed: (rnd.Next(100, 500) / 100),
            //            _target: rnd.Next(2, 100)
            //        )
            //    );
            //}
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.LEFT, true); }
            if (e.KeyCode == Keys.D) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.RIGHT, true); }
            if (e.KeyCode == Keys.W) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.UP, true); }
            if (e.KeyCode == Keys.S) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.DOWN, true); }
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.LEFT, false); }
            if (e.KeyCode == Keys.D) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.RIGHT, false); }
            if (e.KeyCode == Keys.W) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.UP, false); }
            if (e.KeyCode == Keys.S) { _SkillIssue.Input.InputSet((byte)InputManager.eKEYS.DOWN, false); }
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
    }
}
