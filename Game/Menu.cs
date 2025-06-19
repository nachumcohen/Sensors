using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TheInvestingationGame.Agents;
using TheInvestingationGame.Game;

namespace TheInvestingationGame
{
    internal static class Menu
    {
        public static async Task menu()
        {
            PlayerData playerData = null;
            while (true)
            {
                Console.WriteLine(@"Choos:
                1. New user
                2. Existing user
                exit. exit");

                string choos = Console.ReadLine();

                choos.ToLower();
                switch (choos)
                {
                    case "1":
                        playerData = PlayData.NewUser();
                        if (playerData != null)
                        {
                            break;
                        }
                        continue;

                    case "2":
                        playerData = PlayData.ExistingUser();
                        if (playerData != null)
                        {
                            break;
                        }
                        continue;

                    case "exit":
                        return;

                }
                break;
            }

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
                        await Play.StartAgentBasic(playerData);
                        continue;
                    case "2":
                        await Play.StartAgentSquadLeader(playerData);
                        continue;

                    case "3":
                        await Play.StartAgentSeniorCommander(playerData);
                        continue;
                    case "4":
                        await Play.StartAgentOrganizationLeader(playerData);
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
