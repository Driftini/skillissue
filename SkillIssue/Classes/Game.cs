using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SkillIssue
{
    class Game
    {
        public Game(Form form, Size resolution, int scale) {
            GameForm = form;
            Resolution = resolution;
            RenderScale = scale;

            // Adjust window size and position to the game resolution
            Size _oldSize = GameForm.ClientSize;
            GameForm.ClientSize = new Size(
                Resolution.Width * RenderScale - 1,
                Resolution.Height * RenderScale - 1
            );
        }

        public Form GameForm { get; set; }

        public Size Resolution { get; set; }

        private int RenderScale { get; set; }

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
                var actorForm = new frmActorDebug();
                
                void ActorDebugger_UnsetBool(object sender, FormClosingEventArgs e) {
                    Debug_ActorForm = false;
                }
                actorForm.FormClosing += ActorDebugger_UnsetBool;

                void ActorDebugger_Spawn(object sender, EventArgs e)
                {
                    var _actorType = actorForm.ReturnActorType();

                    for (int i = 0; i < actorForm.ReturnSpawnCount(); i++)
                    {
                        switch (_actorType)
                        {
                            case "AnimationTester":
                                Actors.Add(new AnimationTester(
                                    position: actorForm.ReturnActorPosition(),
                                    size: actorForm.ReturnActorSize()
                                    ));
                                break;
                            case "Player":
                                Actors.Add(new Player(
                                    position: actorForm.ReturnActorPosition()
                                ));
                                break;
                            case "Collider":
                                Actors.Add(new Collider(
                                    position: actorForm.ReturnActorPosition(),
                                    size: actorForm.ReturnActorSize()
                                ));
                                break;
                            case "BladeGuy":
                                Actors.Add(new BladeGuy(
                                    position: actorForm.ReturnActorPosition(),
                                    lvl: actorForm.ReturnActorLevel()
                                ));
                                break;
                            case "ZIndexTester":
                                Actors.Add(new ZIndexTester(
                                    position: actorForm.ReturnActorPosition(),
                                    size: actorForm.ReturnActorSize(),
                                    zindex: actorForm.ReturnActorZIndex(),
                                    speed: actorForm.ReturnActorSpeed(),
                                    target: actorForm.ReturnZITesterMoveTarget()
                                ));
                                break;
                        }
                    }
                }
                actorForm.ReturnSpawnButton().Click += ActorDebugger_Spawn;

                void ActorDebugger_Remove(object sender, EventArgs e)
                {
                    Actors.Remove(actorForm.ReturnRemoveID());
                }
                actorForm.ReturnRemoveButton().Click += ActorDebugger_Remove;

                actorForm.Show();
            }
        }

        #endregion

        #region Gameloop

        public void Update()
        {
            #region Debug key checks

            if (Input.InputCheck((byte)InputManager.eKEYS.DGENERAL))
                Debug_General = !Debug_General;
            if (Input.InputCheck((byte)InputManager.eKEYS.DOVERLAYS))
                Debug_Overlays = !Debug_Overlays;
            if (Input.InputCheck((byte)InputManager.eKEYS.DACTORS))
                Debug_ToggleActorForm();

            #endregion

            Actors.ActorList = Actors.ActorList.OrderBy(_actor => _actor.zIndex).ToList();

            List<Request> _clonedRequests = new List<Request>();

            foreach (Actor _actor in Actors.ActorList)
            {
                // Expose entire actor list
                _actor.AllGameActors = Actors.ActorList;

                // Input
                if (_actor is Player)
                {
                    var _player = (Player)_actor;
                    _player.InputUpdate(Input);
                }

                // Requests
                foreach (Request _request in _actor.CurrentRequests)
                    _clonedRequests.Add(_request); // Copy all requests locally,
                                                   // the actor list cannot be edited mid-loop
                _actor.CurrentRequests.Clear();

                // Animations
                _actor.UpdateAnimations();

                // Collisions
                _actor.CurrentCollisions.Clear();
                _actor.IsGrounded = false;

                foreach (Actor _intersecting in Actors.ActorList)
                    _actor.UpdateCollisions(_intersecting);

                _actor.Update();
            }

            foreach (Request r in _clonedRequests)
            {
                switch (r.Type)
                {
                    case Request.eREQUESTTYPE.SPAWN:
                        Actors.Add(r.Spawn);
                        break;
                    case Request.eREQUESTTYPE.REMOVE:
                        Actors.Remove(r.Remove);
                        break;
                }
            }
        }

        public void Render(Graphics GFX)
        {
            Bitmap gBuffer = new Bitmap(Resolution.Width, Resolution.Height);
            Graphics gBufferGFX = Graphics.FromImage(gBuffer);

            #region Graphics configuration
            gBufferGFX.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            gBufferGFX.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            gBufferGFX.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            gBufferGFX.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            gBufferGFX.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;

            GFX.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            GFX.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            GFX.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            GFX.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            #endregion

            Color _bgColor = Color.DarkOliveGreen;
            Color _fontColor = Color.LightGray;

            gBufferGFX.FillRectangle(new SolidBrush(_bgColor), new Rectangle(0, 0, Resolution.Width, Resolution.Height));

            foreach (Actor _actor in Actors.ActorList)
            {
                _actor.Draw(gBufferGFX);

                #region Actor overlays

                if (Debug_Overlays)
                {
                    gBufferGFX.DrawString($"ID {_actor.ID} / {_actor.CurrentCollisions.Count} collisions\n" +
                        $"{_actor.Position} {_actor.Acceleration}", new Font("Verdana", 6.4f), new SolidBrush(_fontColor), new PointF(_actor.Position.X, _actor.Position.Y));

                    gBufferGFX.DrawRectangle(new Pen(Color.Blue), _actor.Position.X, _actor.Position.Y, _actor.RenderSize.Width, _actor.RenderSize.Height);
                    gBufferGFX.DrawRectangle(new Pen(Color.Red), _actor.CurrentHitbox);
                }

                #endregion
            }

            if (Debug_General)
            {
                    gBufferGFX.DrawString("Skill Issue alpha\n" +
                    $"FPS: {FPS}\n" +
                    $"Actors loaded: {Actors.ActorList.Count}", new Font("Verdana", 6.4f), new SolidBrush(_fontColor), new Point(5, 38));

                    gBufferGFX.DrawString("F1 Main debug panel | F2 Actor overlays | F3 Actor de/spawner", new Font("Tahoma", 7, FontStyle.Bold), new SolidBrush(_fontColor), new Point(3, Resolution.Height - 16));
            }

            GFX.DrawImage(gBuffer, new Rectangle(0, 0, Resolution.Width * RenderScale, Resolution.Height * RenderScale));

            gBuffer.Dispose();
            gBufferGFX.Dispose();

            FPSstep++;
        }

        #endregion
    }
}
