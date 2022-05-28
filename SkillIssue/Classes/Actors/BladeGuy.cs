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

            Health = 50;

            for (int i = 1; i <= lvl; i++)
                Health += 15;

            RenderSize = new Size(16, 16);
            zIndex = eZINDEX.ENTITY;
            Gravity = true;
            IsSolid = true;
            Speed = 1.5f;
            FrictionX = 1.2f;

            #region States

            Rectangle hbox = new Rectangle(new Point(4, 3), new Size(6, 14));

            FrameData[] Frames_Spawn =
            {
                new FrameData(1, hbox, Properties.Resources.colliderOn)
            };

            FrameData[] Frames_Pain =
            {
                new FrameData(10, hbox, Properties.Resources.colliderOff)
            };

            FrameData[] Frames_Death =
            {
                new FrameData(20, hbox, Properties.Resources.ANIMTEST_COLL),
                new FrameData(1, hbox, Properties.Resources.ANIMTEST_COLL)
            };

            States.Add(
                new ActorState("Spawn", Frames_Spawn)
            );

            States.Add(
                new ActorState("Pain", Frames_Pain, "Spawn")
            );

            States.Add(
                new ActorState("Death", Frames_Death)
            );

            #endregion
        }

        private int Level = 0;

        private void TryNextPos()
        {
            
        }

        public override void Update()
        {
            switch (GetState())
            {
                case "Spawn":
                    foreach (Actor a in CurrentCollisions)
                        if (a is SlashParticle && a.FramePointer == 1)
                        {
                            var sp = (SlashParticle)a;
                            Health -= sp.Damage;
                            SetState("Pain");
                        }

                        Player player = new Player(Point.Empty);

                        foreach (Actor a in AllGameActors)
                            if (a is Player)
                                player = (Player)a;

                    if (Health <= 0)
                        SetState("Death");
                    break;
                case "Pain":
                    break;
                case "Death":
                    if (FramePointer >= 1)
                        RemoveSelf();
                    break;
            }

            UpdateMovement();
        }
    }
}
