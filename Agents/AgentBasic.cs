using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestingationGame.Agents
{
    internal class AgentBasic : Agent
    {
        public AgentBasic() : base() { }

        public override int GetSensorCount()
        {
            return 2;
        }
        public override int GetLevelAgent()
        {
            return 1;
        }
    }
}
