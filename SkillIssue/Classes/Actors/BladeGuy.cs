using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class BladeGuy : LiveEntity
    {
        public BladeGuy(Point position, int lvl)
        {
            Position = position;
            Level = lvl;

            Health = 40;

            for (int i = 1; i <= lvl; i++)
                Health += 5;

            RenderSize = new Size(16, 16);
            zIndex = eZINDEX.ENTITY;
            Gravity = true;
            IsSolid = true;
            Speed = 1.000000000000001f;
            FrictionX = 1.2f;

            #region States

            Rectangle hbox = new Rectangle(new Point(3, 3), new Size(11, 14));

            FrameData[] Frames_Spawn =
            {
                new FrameData(3, hbox, Properties.Resources.BLGUY_RUN0),
                new FrameData(3, hbox, Properties.Resources.BLGUY_RUN1),
                new FrameData(3, hbox, Properties.Resources.BLGUY_RUN2),
                new FrameData(3, hbox, Properties.Resources.BLGUY_RUN3),
                new FrameData(3, hbox, Properties.Resources.BLGUY_RUN4),
                new FrameData(3, hbox, Properties.Resources.BLGUY_RUN5)
            };

            FrameData[] Frames_Preattack =
            {
                new FrameData(1, hbox, Properties.Resources.BLGUY_ATK0)
            };

            FrameData[] Frames_Attack =
            {
                new FrameData(2, hbox, Properties.Resources.BLGUY_ATK1),
                new FrameData(2, hbox, Properties.Resources.BLGUY_ATK2),
                new FrameData(1, hbox, Properties.Resources.BLGUY_ATK3), //!
                new FrameData(2, hbox, Properties.Resources.BLGUY_ATK4),
                new FrameData(3, hbox, Properties.Resources.BLGUY_ATK5),
                new FrameData(3, hbox, Properties.Resources.BLGUY_ATK6),
                new FrameData(4, hbox, Properties.Resources.BLGUY_ATK7),
                new FrameData(7, hbox, Properties.Resources.BLGUY_ATK8),
                new FrameData(3, hbox, Properties.Resources.BLGUY_ATK9),
                new FrameData(1, hbox, Properties.Resources.BLGUY_ATK9)
            };

            FrameData[] Frames_Pain =
            {
                new FrameData(1, hbox, Properties.Resources.BLGUY_DMG0),
                new FrameData(1, hbox, Properties.Resources.BLGUY_DMG0),
                new FrameData(8, hbox, Properties.Resources.BLGUY_DMG1)
            };

            FrameData[] Frames_Death =
            {
                new FrameData(1, hbox, Properties.Resources.BLGUY_DMG0),
                new FrameData(4, hbox, Properties.Resources.BLGUY_DMG0),
                new FrameData(2, hbox, Properties.Resources.BBLOD2),
                new FrameData(2, hbox, Properties.Resources.BBLOD3),
                new FrameData(3, hbox, Properties.Resources.BBLOD4),
                new FrameData(4, hbox, Properties.Resources.BBLOD5)
            };

            States.Add(
                new ActorState("Spawn", Frames_Spawn)
            );

            States.Add(
                new ActorState("Preattack", Frames_Preattack, "Spawn")
            );

            States.Add(
                new ActorState("Attack", Frames_Attack, "Spawn")
            );

            States.Add(
                new ActorState("Pain", Frames_Pain, "Spawn")
            );

            States.Add(
                new ActorState("Death", Frames_Death)
            );

            #endregion
        }

        public int Level = 0;

        private int ReactionTimer = 0;

        public override void Update()
        {
            if (GetState() != "Death" && Health <= 0)
                SetState("Death");

            Player Player = new Player(Point.Empty);

            foreach (Actor a in AllGameActors)
                if (a is Player)
                    Player = (Player)a;

            switch (GetState())
            {
                case "Preattack":
                case "Spawn":
                    GravityForce = 1.2f;

                    if (IsGrounded)
                    {
                        var attack = false;

                        if (Player.Position.Y >= Position.Y - 10 && Player.Position.Y <= Position.Y + 10 && Player.Position.X > Position.X - 20 && Player.Position.X < Position.X + 20)
                        {
                            attack = true;
                        }

                        if (Player.Position.Y >= Position.Y - 15 && Player.Position.Y <= Position.Y + 15)
                        {
                            if (attack)
                            {
                                ReactionTimer++;
                                SetState("Preattack");
                                if (ReactionTimer >= 30)
                                {
                                    ReactionTimer = 0;
                                    SetState("Attack");
                                }
                            }
                            else if (Player.Position.X < Position.X - 15)
                            {
                                FacingLeft = true;
                                Velocity.X -= 1;
                            }
                            else if (Player.Position.X > Position.X + 15)
                            {
                                FacingLeft = false;
                                Velocity.X += 1;
                            }
                        }
                        else
                        {
                            foreach (Actor a in CurrentCollisions)
                                if (a is EnemyTurner)
                                    FacingLeft = !FacingLeft;

                            if (FacingLeft)
                                Velocity.X = -1;
                            else
                                Velocity.X = 1; 
                        }
                    }

                    foreach (Actor a in CurrentCollisions)
                        if (a is SlashParticle && a.FramePointer == 2)
                        {
                            var sp = (SlashParticle)a;
                            Health -= sp.Damage;
                            SetState("Pain");
                        }
                    break;
                case "Attack":
                    if (FramePointer == 0)
                    {
                        GravityForce = 1f;
                        Velocity.Y -= 2;

                        if (Player.Position.X < Position.X)
                        {
                            FacingLeft = true;
                            Velocity.X -= 3;
                        }
                        if (Player.Position.X > Position.X)
                        {
                            FacingLeft = false;
                            Velocity.X += 3;
                        }
                    }
                    break;
                case "Pain":
                    ReactionTimer = 0;
                    break;
                case "Death":

                    if (FramePointer == 2)
                    {
                        Gravity = false;
                        Velocity = Vector2.Zero;
                        Acceleration = Vector2.Zero;
                        Position = new Point(Position.X - 2, Position.Y - 2);
                        RenderSize = new Size(24, 24);
                    }

                    if (FramePointer >= 5)
                        RemoveSelf();
                    break;
            }

            UpdateMovement();
        }
    }
}
