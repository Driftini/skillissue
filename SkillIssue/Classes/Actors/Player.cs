using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class Player : LiveEntity
    {
        public Player(Point position)
        {
            Position = position;

            RenderSize = new Size(16, 16);
            zIndex = eZINDEX.PLAYER;
            Speed = 1.000001f;
            FrictionX = 1.2f;
            Gravity = true;
            IsSolid = true;
            
            Health = 100;
            DashCooldown = 0;

            #region States

            Rectangle hbox = new Rectangle(new Point(4, 3), new Size(6, 14));

            FrameData[] Frames_Spawn =
            {
                new FrameData(1, hbox, Properties.Resources.PLAYER_IDLE0)
            };

            FrameData[] Frames_Inch =
            {
                new FrameData(1, hbox, Properties.Resources.PLAYER_INCH0)
            };

            FrameData[] Frames_Run =
            {
                new FrameData(3, hbox, Properties.Resources.PLAYER_RUN0),
                new FrameData(3, hbox, Properties.Resources.PLAYER_RUN1),
                new FrameData(3, hbox, Properties.Resources.PLAYER_RUN2),
                new FrameData(3, hbox, Properties.Resources.PLAYER_RUN3),
                new FrameData(3, hbox, Properties.Resources.PLAYER_RUN4),
                new FrameData(3, hbox, Properties.Resources.PLAYER_RUN5)
            };

            FrameData[] Frames_Jump =
            {
                new FrameData(3, hbox, Properties.Resources.PLAYER_JMP0),
                new FrameData(10, hbox, Properties.Resources.PLAYER_JMP1)
            };

            FrameData[] Frames_Fall =
            {
                new FrameData(1, hbox, Properties.Resources.PLAYER_FALL0)
            };

            FrameData[] Frames_Pain =
            {
                new FrameData(3, hbox, Properties.Resources.PLAYER_DMG0),
                new FrameData(17, hbox, Properties.Resources.PLAYER_FALL0)
            };

            FrameData[] Frames_Dash =
            {
                new FrameData(10, hbox, Properties.Resources.PLAYER_DASH0)
            };

            FrameData[] Frames_Attack1 =
            {
                new FrameData(3, hbox, Properties.Resources.PLAYER_ATK1_0),
                new FrameData(2, hbox, Properties.Resources.PLAYER_ATK1_1),
                new FrameData(1, hbox, Properties.Resources.PLAYER_ATK1_2),
                new FrameData(1, hbox, Properties.Resources.PLAYER_ATK1_2),
                new FrameData(1, hbox, Properties.Resources.PLAYER_ATK1_3),
                new FrameData(1, hbox, Properties.Resources.PLAYER_ATK1_4),
                new FrameData(2, hbox, Properties.Resources.PLAYER_ATK1_5),
                new FrameData(3, hbox, Properties.Resources.PLAYER_ATK1_6),
                new FrameData(3, hbox, Properties.Resources.PLAYER_ATK1_7),
                new FrameData(5, hbox, Properties.Resources.PLAYER_ATK1_8),
                new FrameData(1, hbox, Properties.Resources.PLAYER_ATK1_8),
            };

            FrameData[] Frames_Attack2 =
            {
                new FrameData(3, hbox, Properties.Resources.PLAYER_ATK2_0),
                new FrameData(2, hbox, Properties.Resources.PLAYER_ATK2_1),
                new FrameData(1, hbox, Properties.Resources.PLAYER_ATK2_2),
                new FrameData(1, hbox, Properties.Resources.PLAYER_ATK2_2),
                new FrameData(1, hbox, Properties.Resources.PLAYER_ATK2_3),
                new FrameData(1, hbox, Properties.Resources.PLAYER_ATK2_4),
                new FrameData(3, hbox, Properties.Resources.PLAYER_ATK2_5),
                new FrameData(6, hbox, Properties.Resources.PLAYER_ATK2_6),
                new FrameData(1, hbox, Properties.Resources.PLAYER_ATK2_6)
            };

            FrameData[] Frames_Attack3 =
            {
                new FrameData(3, hbox, Properties.Resources.PLAYER_ATK3_0),
                new FrameData(3, hbox, Properties.Resources.PLAYER_ATK3_1),
                new FrameData(5, hbox, Properties.Resources.PLAYER_ATK3_2),
                new FrameData(1, hbox, Properties.Resources.PLAYER_ATK3_3),
                new FrameData(2, hbox, Properties.Resources.PLAYER_ATK3_4),
                new FrameData(3, hbox, Properties.Resources.PLAYER_ATK3_5),
                new FrameData(3, hbox, Properties.Resources.PLAYER_ATK3_6),
                new FrameData(4, hbox, Properties.Resources.PLAYER_ATK3_7),
                new FrameData(7, hbox, Properties.Resources.PLAYER_ATK3_8),
                new FrameData(3, hbox, Properties.Resources.PLAYER_ATK3_9),
                new FrameData(1, hbox, Properties.Resources.PLAYER_ATK3_9)
            };

            States.Add(
                new ActorState("Spawn", Frames_Spawn)
            );

            States.Add(
                new ActorState("Inch", Frames_Inch, "Spawn")
            );

            States.Add(
                new ActorState("Run", Frames_Run)
            );

            States.Add(
                new ActorState("Jump", Frames_Jump, "Fall")
            );

            States.Add(
                new ActorState("Fall", Frames_Fall)
            );

            States.Add(
                new ActorState("Pain", Frames_Pain, "Spawn")
            );

            States.Add(
                new ActorState("Dash", Frames_Dash, "Fall")
            );

            States.Add(
                new ActorState("Attack1", Frames_Attack1, "Spawn")
            );

            States.Add(
                new ActorState("Attack2", Frames_Attack2, "Spawn")
            );

            States.Add(
                new ActorState("Attack3", Frames_Attack3, "Spawn")
            );

            #endregion
        }

        private bool JumpAlreadyPressed = false;
        private bool AttackAlreadyPressed = false;

        private int InvulnTime = 0;
        public int DashCooldown { get; set; }
        private Vector2 DashVel = new Vector2();

        public int Score { get; set; }
        public float Multiplier = 1.0f;

        private void SpawnSlash(bool flipY_ = false, bool big_ = false)
        {
            if (FacingLeft)
                CurrentRequests.Add(
                    new Request(Request.eREQUESTTYPE.SPAWN, new SlashParticle(
                        position: new Point(Position.X - 9, Position.Y),
                        left: FacingLeft,
                        flipY: flipY_,
                        big: big_
                )));
            else
                CurrentRequests.Add(
                    new Request(Request.eREQUESTTYPE.SPAWN, new SlashParticle(
                        position: new Point(Position.X + 9, Position.Y),
                        left: FacingLeft,
                        flipY: flipY_,
                        big: big_
                )));
        }

        public override void Update()
        {
            Gravity = true;

            // Check for dead or hit enemies
            
            foreach (Actor a in AllGameActors)
            {
                if (a is BladeGuy)
                {
                    var bg = (BladeGuy)a;

                    if (a.GetState() == "Pain" && bg.FrameProgress == 0)
                        Multiplier += .1f;

                    if (a.GetState() == "Death" && bg.FrameProgress == 1)
                    {
                        DashCooldown += 30;
                        AwardScore(50 + (bg.Level * 5));
                    }
                }
            }

            // Dash cooldown

            if (DashCooldown < 100)
                DashCooldown += 1;
            else
                DashCooldown = 100;

            // Invulnerable time

            if (DashCooldown > 0)
                InvulnTime -= 1;
            else
                DashCooldown = 0;

            // Speed caps

            if (GetState() != "Dash" && GetState() != "Pain" && Acceleration.X > 1.5f)
                Acceleration = new Vector2(1.5f, Acceleration.Y);

            if (GetState() != "Dash" && GetState() != "Pain" && Acceleration.X < -1.5f)
                Acceleration = new Vector2(-1.5f, Acceleration.Y);

            switch (GetState())
            {
                case "Attack1":
                    if (FramePointer == 2) SpawnSlash();
                    break;
                case "Attack2":
                    if (FramePointer == 2) SpawnSlash(true);
                    break;
                case "Attack3":
                    if (FramePointer == 3) SpawnSlash(true, true);
                    break;
                case "Dash":
                    Gravity = false;
                    DashCooldown = 0;
                    Acceleration = Vector2.Zero;

                    Velocity.X = DashVel.X;
                    Velocity.Y = DashVel.Y;

                    var rnd = new Random();
                    bool flipPuffX = false;
                    bool flipPuffY = false;
                    bool bigPuff = false;

                    if (rnd.Next(0, 1) == 1)
                        flipPuffX = true;

                    if (rnd.Next(0, 1) == 1)
                        flipPuffY = true;

                    if (FrameProgress == 0)
                        bigPuff = true;

                    CurrentRequests.Add(new Request(Request.eREQUESTTYPE.SPAWN, new DashPuff(
                        position: new Point(Position.X + 4, Position.Y + 6),
                        left: flipPuffX,
                        flipY: flipPuffY,
                        big: bigPuff
                        )));
                    break;
                case "Pain":
                    Multiplier = 1;
                    break;
            }

            // Damage check

            if (GetState() != "Pain" && GetState() != "Death" && GetState() != "Dash" && InvulnTime <= 0)
            {
                foreach (Actor a in CurrentCollisions)
                    if (a is BladeGuy && a.GetState() == "Attack" && a.FramePointer >= 2 && a.FramePointer <= 9)
                    {
                        var bg = (BladeGuy)a;

                        Health -= 15;
                        for (int i = 1; i <= bg.Level; i++)
                            Health -= 5;

                        SetState("Pain");

                        InvulnTime = 21;
                        Velocity.Y = -5;

                        if (FacingLeft)
                            Velocity.X += 7;
                        else
                            Velocity.X -= 5;
                    }
            }

            UpdateMovement();
        }

        private void AwardScore(int amount)
        {
            var temp = Math.Floor(amount * Multiplier);

            Score += (int)temp;
        }

        public void InputUpdate(InputManager _input)
        {
            bool running = false;

            #region Input

            if (GetState() != "Attack1" && GetState() != "Attack2" && GetState() != "Attack3" && GetState() != "Pain" && GetState() != "Death")
            {
                if (_input.InputCheck((byte)InputManager.eKEYS.LEFT))
                {
                    Velocity.X -= Speed;
                    FacingLeft = true;
                    running = true;
                }

                if (_input.InputCheck((byte)InputManager.eKEYS.RIGHT))
                {
                    Velocity.X += Speed;
                    FacingLeft = false;
                    running = true;
                }

                if (_input.InputCheck((byte)InputManager.eKEYS.LEFT) && _input.InputCheck((byte)InputManager.eKEYS.RIGHT))
                    running = true;

                if (_input.InputCheck((byte)InputManager.eKEYS.UP))
                {
                    if (IsGrounded && !JumpAlreadyPressed)
                    {
                        Velocity.Y -= 11f;
                        SetState("Jump");
                    }
                    JumpAlreadyPressed = true;
                }
                else
                    JumpAlreadyPressed = false;
            }

            if (GetState() != "Pain" && GetState() != "Death")
            {
                if (_input.InputCheck((byte)InputManager.eKEYS.ATTACK))
                {
                    if (!AttackAlreadyPressed)
                    {

                        switch (GetState())
                        {
                            default:
                                SetState("Attack1");
                                if (!IsGrounded)
                                    Acceleration.Y = -2;
                                break;
                            case "Attack1":
                                if (FramePointer >= 6)
                                    SetState("Attack2");
                                break;
                            case "Attack2":
                                if (FramePointer >= 6)
                                {
                                    if (FacingLeft)
                                        Velocity.X -= 2;
                                    else
                                        Velocity.X += 2;
                                    SetState("Attack3");
                                }
                                break;
                            case "Attack3":
                                break;
                        }
                    }
                    AttackAlreadyPressed = true;
                }
                else
                    AttackAlreadyPressed = false;
            }

            if (GetState() != "Death" && _input.InputCheck((byte)InputManager.eKEYS.DASH))
            {
                if (DashCooldown >= 100)
                {
                    DashVel = Vector2.Zero;

                    if (_input.InputCheck((byte)InputManager.eKEYS.LEFT))
                        DashVel.X = -5;

                    if (_input.InputCheck((byte)InputManager.eKEYS.RIGHT))
                        DashVel.X = 5;

                    if (_input.InputCheck((byte)InputManager.eKEYS.UP))
                        DashVel.Y = -5;

                    if (_input.InputCheck((byte)InputManager.eKEYS.DOWN))
                        DashVel.Y = 5;

                    Vector2.Normalize(DashVel);
                    SetState("Dash");
                }
            }

            #endregion

            if (GetState() != "Attack1" && GetState() != "Attack2" && GetState() != "Attack3" && GetState() != "Pain" && GetState() != "Death" && GetState() != "Dash" && GetState() != "Jump")
            {
                if (running)
                {
                    if (GetState() == "Spawn")
                        SetState("Inch");

                    if (GetState() == "Inch")
                        SetState("Run");
                }
                else if (GetState() == "Inch" || GetState() == "Run")
                    SetState("Spawn");

                if (GetState() == "Fall" || GetState() == "Jump" && IsGrounded)
                    SetState("Spawn");
                else if (!IsGrounded)
                    SetState("Fall");
            }
        }
    }
}
