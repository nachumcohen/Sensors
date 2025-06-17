using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TheInvestingationGame.Agents;

namespace TheInvestingationGame
{
    internal static class Menu
    {
        public static void menu()
        {

            while (true)
            {
                    Console.WriteLine(@"Choos:
                1.Play Agent Basic
                2. Play Squad Leader
                3. Play Senior Commander
                4. Play Organization Leader
                exit. go out");

                string ChoosUser = Console.ReadLine();

                ChoosUser.ToLower();
                switch (ChoosUser)
                {
                    case "1":
                        Play.StartAgentBasic(); 
                        continue;
                    case "2":
                        Play.StartAgentSquadLeader();
                        continue;

                    case "3":
                        Play.StartAgentSeniorCommander();
                        continue;
                    case "4":
                        Play.StartAgentOrganizationLeader();
                        continue;

                    case "exit":
                        break;

                    default:
                        Console.WriteLine("enter num proper or exit");
                        continue;

                }
                break;
            }
            
            Console.WriteLine("Bye");
        }
    }
}
