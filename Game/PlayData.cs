using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestingationGame.DAL;

namespace TheInvestingationGame.Game
{
    internal static class PlayData
    {
        public static PlayerData NewUser()
        {
            PlayerData playerData;
            string UserName;
            string Password;

            while (true)
            {
                Console.WriteLine("Enter UserName or exit");
                UserName = Console.ReadLine();

                if (UserName.ToLower() == "exit")
                {
                    break;
                }

                if (UserName.Length < 2)
                {
                    Console.WriteLine("Must at least 2 chars");
                    continue;
                }
                if (DalPlayer.IsPlayer(UserName))
                {
                    Console.WriteLine("UserName is exists");
                    continue;
                }
                break;

            }
            while (UserName != "exit")
            {

                Console.WriteLine("Enter password or exit");
                Password = Console.ReadLine();

                if (Password.ToLower() == "exit")
                {
                    break;
                }

                if (Password.Length < 4)
                {
                    Console.WriteLine("Must at least 4 chars");
                    continue;
                }


                Player player = new Player(UserName, Password);
                DalPlayer.AddPlayer(player);

                playerData = new PlayerData();
                playerData.Id = DalPlayer.ReturnIdByUserName(UserName);
                return playerData;
                
            }


            return null;
        }

        public static PlayerData ExistingUser() 
        {

            PlayerData playerData;
            string UserName;
            string Password;



            while (true)
            {
                Console.WriteLine("Enter UserName or exit");
                UserName = Console.ReadLine();

                if (UserName.ToLower() == "exit")
                {
                    break;
                }

                if (UserName.Length < 2)
                {
                    Console.WriteLine("Must at least 2 chars");
                    continue;
                }
                if (!DalPlayer.IsPlayer(UserName))
                {
                    Console.WriteLine("UserName is'nt exists");
                    continue;
                }
                break;

            }
            while (UserName != "exit")
            {

                Console.WriteLine("Enter password or exit");
                Password = Console.ReadLine();

                if (Password.ToLower() == "exit")
                {
                    break;
                }

                if (Password.Length < 4)
                {
                    Console.WriteLine("Must at least 4 chars");
                    continue;
                }

                if (!DalPlayer.IsPasswordProper(UserName , Password))
                {
                    Console.WriteLine("Password is'nt proper");
                    continue;
                }


                playerData = new PlayerData();

                int Id = DalPlayer.ReturnIdByUserName(UserName);

                playerData = new PlayerData();
                playerData.Id = Id;
                playerData.LevelAgent = DalPlayerData.GetTopLevelAgent(Id);
                return playerData;

            }

            return null;
        }

    }
}
