using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestingationGame.DAL
{
    internal static class DalPlayerData
    {
        private static string connStr = DbConfig.ConnectionString;

        public static void AddUserData(PlayerData playerData)
        {
            string query = @"INSERT INTO userdata (User_Id , Level_Agent , Mount_Turns , Num_Mistake , Score , Status) 
                                    VALUES (@UserId ,@Level_Agent, @Mount_Turns ,@Num_Mistake, @Score, @Status);";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query , conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@UserId" , playerData.Id);
                        cmd.Parameters.AddWithValue("@Level_Agent" , playerData.LevelAgent);
                        cmd.Parameters.AddWithValue("@Mount_Turns" , playerData.MountTurns);
                        cmd.Parameters.AddWithValue("@Num_Mistake", playerData.NumMistake);
                        cmd.Parameters.AddWithValue("@Score" , playerData.Score);
                        cmd.Parameters.AddWithValue("@Status" , playerData.Status.ToString());
                        cmd.ExecuteNonQuery();

                        Console.WriteLine("userData add successfully");

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddUserData error: {ex.Message}");
            }

        }

        public static int GetTopLevelAgent(int Id)
        {
            int LevelAgent = 0;

            string query = "SELECT MAX(Level_Agent) FROM userdata WHERE User_Id = @Id";

            try
            {
                using (MySqlConnection  conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query , conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@Id", Id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LevelAgent = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetTopLevelAgent error: {ex.Message}");
            }


            return LevelAgent;
        }

        //public PlayerData GetPlayerDaTa(int id) {return null;}
        //public int GetRank(int Id) { return 0; }
    }
}
