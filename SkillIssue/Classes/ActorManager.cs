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
            return ActorList.Find(_actor => _actor.ID == _id);
        }

        public void Add(Actor _actor)
        {
            var idAttempt = 1;

            while (UsedIDs.Contains(idAttempt))
                idAttempt++;

            _actor.ID = idAttempt;
            UsedIDs.Add(idAttempt);
            ActorList.Add(_actor);
        }

        public void Remove(int _id)
        {
            var toRemove = FindID(_id);

            if (!(toRemove is null))
            {
                ActorList.Remove(toRemove);
                UsedIDs.Remove(_id);
            }
        }
    }
}
