using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SkillIssue
{
    class EnemySpawner : Actor
    {
        public EnemySpawner(Point position, int tillnext)
        {
            Position = position;
            UntilNextSpawn = tillnext;

            RenderSize = new Size(16, 16);
            zIndex = eZINDEX.BACKGROUND;

            #region States

            FrameData[] Frames_Spawn =
            {
                new FrameData(64, new Rectangle(Point.Empty, RenderSize), Properties.Resources.TRANSPARENT)
            };

            States.Add(
                new ActorState("Spawn", Frames_Spawn)
                );

            #endregion
        }

        private int UntilNextSpawn = 0;

        private void SpawnEnemy()
        {
            Player player = new Player(Point.Empty);

            foreach (Actor a in AllGameActors)
                if (a is Player)
                    player = (Player)a;

            int lvl_ = 1 + (player.Score / 300);

            CurrentRequests.Add(new Request(Request.eREQUESTTYPE.SPAWN, new BladeGuy(
                position: Position,
                lvl: lvl_
                )));
        }

        public override void Update()
        {
            var enemyCount = 0;

            foreach (Actor a in AllGameActors)
                if (a is BladeGuy)
                    enemyCount++;

            if (enemyCount <= 3)
            {
                Random rnd = new Random();

                if (FrameProgress == 0)
                {
                    UntilNextSpawn--;

                    if (UntilNextSpawn <= 0)
                    {
                        UntilNextSpawn = rnd.Next(5, 10);
                        SpawnEnemy();
                    }
                }
            }
        }
    }
}
