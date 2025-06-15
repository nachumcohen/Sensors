using System;
using System.Collections.Generic;
using System.Linq;
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

            Console.WriteLine(@"Choos:
            1.Play Agent Basic
            exit. go out");

            while (true)
            {
                string ChoosUser = Console.ReadLine();
                ChoosUser.ToLower();
                switch (ChoosUser)
                {
                    case "1":
                        Play.StartAgentBasic(); 
                        break;

                    case "exit":
                        break;

                    default:
                        Console.WriteLine("enter num proper or exit");
                        continue;

                }
                break;
            }
            
            Console.WriteLine("👋");
        }
    }
}
