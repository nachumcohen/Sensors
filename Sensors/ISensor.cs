using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestingationGame.Agents;

namespace TheInvestingationGame
{
    internal interface ISensor
    {
        string Type { get; }
        bool Activate(Agent iranianAgent);
    }
}
