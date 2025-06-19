using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestingationGame.Agents;
using TheInvestingationGame.DAL;
using TheInvestingationGame.Sensors;

namespace TheInvestingationGame
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            await Menu.menu();
        }
    }
}
