using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TheInvestingationGame.DAL
{
    internal static class DalPlayer
    {
        private static string connStr = DbConfig.ConnectionString;
        public static bool IsPlayer(string userName)
        {
            string query = "SELECT UserName FROM Users WHERE UserName = @userName";
            try
            {

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using(MySqlCommand cmd = new MySqlCommand(query , conn))
                    {
                        cmd.Parameters.AddWithValue("@userName", userName);
                        using(MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"IsPlayer error: {ex.Message}");
            }

            return false;
        }

        public static bool IsPasswordProper(string userName, string password)
        {
            string query = $"SELECT UserName FROM Users WHERE UserName = @userName AND Password = @password ";
            try
            {

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@password", password);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"IsPasswordProper error: {ex.Message}");
            }

            return false;
        }

        public static void AddPlayer(Player player)
        {
            string query = "INSERT INTO Users (UserName , Password) VALUES (@UserName , @Password)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query , conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@UserName", player.UserName);
                        cmd.Parameters.AddWithValue("@Password", player.Password);
                        cmd.ExecuteNonQuery();

                        Console.WriteLine("add Player successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddPlayer error: {ex.Message}");
            }
        }

        public static int ReturnIdByUserName(string userName)
        {
            int Id;
            string query = "SELECT ID FROM Users WHERE UserName = @userName";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ReturnIdByUserName error: {ex.Message}");
            }
            return 0;
        }


    }
}
