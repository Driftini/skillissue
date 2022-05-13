using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIssue
{
    class ActorManager
    {
        public List<Actor> ActorList = new List<Actor>();
        private List<int> UsedIDs = new List<int>();

        public Actor FindID(int _id)
        {
            return ActorList.Find(actor => actor.ID == _id);
        }

        public void Add(Actor actor)
        {
            var idAttempt = 1;

            while (UsedIDs.Contains(idAttempt))
                idAttempt++;

            actor.ID = idAttempt;
            UsedIDs.Add(idAttempt);
            ActorList.Add(actor);
        }

        public void Remove(int id)
        {
            var toRemove = FindID(id);

            if (!(toRemove is null))
            {
                ActorList.Remove(toRemove);
                UsedIDs.Remove(id);
            }
        }
    }
}
