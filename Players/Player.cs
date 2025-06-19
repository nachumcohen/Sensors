using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestingationGame
{
    internal class Player
    {
        public int ID {  get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public Player(string userName , string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
