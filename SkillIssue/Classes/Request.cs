using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIssue
{
    public struct Request
    {
        public Request(eREQUESTTYPE type, Actor spawn)
        {
            Type = type;
            Spawn = spawn;
            Remove = -1;
        }

        public Request(eREQUESTTYPE type, int remove)
        {
            Type = type;
            Spawn = new NullActor();
            Remove = remove;
        }

        public enum eREQUESTTYPE
        {
            SPAWN,
            REMOVE
        }

        public eREQUESTTYPE Type { get; set; }
        public Actor Spawn { get; set; }
        public int Remove { get; set; }
    }
}
