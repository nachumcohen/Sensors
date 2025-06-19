using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TheInvestingationGame
{
    public enum Status
    {
        Win,
        Loss
    }
    internal class PlayerData
    {
        public int Id { get; set; }
        public string UserName {  get; set; }
        public int LevelAgent { get; set; }
        public int MountTurns { get; set; }
        public int NumMistake { get; set; }
        public float Score { get; set; }

        public Status Status { get; set ; }

        public PlayerData()
        {
           
        }

        public float GetScore()
        {
            float score = (float)(5 - NumMistake * 0.5);
            return score;
        }

        public override string ToString()
        {
            return $"UserName: {UserName}, LevelAgent: {LevelAgent} , MountTurns: {MountTurns}, " +
                $"NumMistake: {NumMistake}, Score: {Score}";
        }  
       


    }
}
