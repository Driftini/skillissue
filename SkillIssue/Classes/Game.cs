﻿using System;
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

        public InputManager Input = new InputManager();
        public ActorManager Actors = new ActorManager();

        #region Debugging

        public int FPS { get; set; }
        public int FPSstep { get; set; }

        private bool Debug_General = true;
        private bool Debug_Overlays = false;
        private bool Debug_ActorForm = false;

        private void Debug_ToggleActorForm()
        {
            Input.InputSet((byte)InputManager.eKEYS.DACTORS, false);

            if (!Debug_ActorForm) 
            {
                Debug_ActorForm = true;
                var _form = new frmActorDebug();
                
                void ActorDebugger_UnsetBool(object sender, FormClosingEventArgs e) {
                    Debug_ActorForm = false;
                }
                _form.FormClosing += ActorDebugger_UnsetBool;

                void ActorDebugger_Spawn(object sender, EventArgs e)
                {
                    var _actorType = _form.ReturnActorType();

                    for (int i = 0; i < _form.ReturnSpawnCount(); i++)
                    {
                        switch (_actorType)
                        {
                            case "Player":
                                Actors.Add(new Player(
                                    _position: _form.ReturnActorPosition()
                                ));
                                break;
                            case "Collider":
                                Actors.Add(new Collider(
                                    _position: _form.ReturnActorPosition(),
                                    _size: _form.ReturnActorSize()
                                ));
                                break;
                            case "ZIndexTester":
                                Actors.Add(new ZIndexTester(
                                    _position: _form.ReturnActorPosition(),
                                    _size: _form.ReturnActorSize(),
                                    _sprite: Properties.Resources.colliderOn,
                                    _zindex: _form.ReturnActorZIndex(),
                                    _speed: _form.ReturnActorSpeed(),
                                    _target: _form.ReturnZITesterMoveTarget()
                                ));
                                break;
                        }
                    }
                }
                _form.ReturnSpawnButton().Click += ActorDebugger_Spawn;

                void ActorDebugger_Remove(object sender, EventArgs e)
                {
                    Actors.Remove(_form.ReturnRemoveID());
                }
                _form.ReturnRemoveButton().Click += ActorDebugger_Remove;

                _form.Show();
            }
        }

        #endregion

        #region Gameloop

        public void Update()
        {
            if (Input.InputCheck((byte)InputManager.eKEYS.DGENERAL))
                Debug_General = !Debug_General;
            if (Input.InputCheck((byte)InputManager.eKEYS.DOVERLAYS))
                Debug_Overlays = !Debug_Overlays;
            if (Input.InputCheck((byte)InputManager.eKEYS.DACTORS))
                Debug_ToggleActorForm();

            Actors.ActorList = Actors.ActorList.OrderBy(_actor => _actor.zIndex).ToList();

            foreach (Actor _actor in Actors.ActorList)
            {

                if (_actor is Player)
                {
                    var _player = (Player)_actor;
                    _player.InputUpdate(Input);
                }

                _actor.CurrentCollisions.Clear();
                _actor.IsGrounded = false;

                foreach (Actor _intersecting in Actors.ActorList)
                {
                    _actor.CollisionUpdate(_intersecting);
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

            foreach (Actor _actor in Actors.ActorList)
            {
                _actor.Draw(GBufferGFX);
                
                if (Debug_Overlays)
                {
                    GBufferGFX.DrawString($"ID {_actor.ID} / {_actor.CurrentCollisions.Count} collisions\n" +
                        $"{_actor.Position} {_actor.Acceleration}", new Font("Verdana", 6.4f), new SolidBrush(FontColor), new Point(_actor.Position.X, _actor.Position.Y));

                    GBufferGFX.DrawRectangle(new Pen(Color.Red), _actor.ActualHitbox);
                    //GBufferGFX.DrawRectangle(new Pen(FontColor), new Rectangle(_actor.Position, _actor.RenderSize));
                }
            }

            if (Debug_General)
            {
                GBufferGFX.DrawString("Skill Issue prealpha\n" +
                $"FPS: {FPS}\n" +
                $"Actors loaded: {Actors.ActorList.Count}", new Font("Verdana", 6.4f), new SolidBrush(FontColor), new Point(5, 8));

                GBufferGFX.DrawString("F1 Main debug panel | F2 Actor overlays | F3 Actor de/spawner", new Font("Tahoma", 7, FontStyle.Bold), new SolidBrush(FontColor), new Point(3, Resolution.Height - 16));
            }

            _gfx.DrawImage(GBuffer, new Rectangle(0, 0, Resolution.Width * Scale, Resolution.Height * Scale));

            GBuffer.Dispose();
            GBufferGFX.Dispose();

            FPSstep++;
        }

        #endregion
    }
}
