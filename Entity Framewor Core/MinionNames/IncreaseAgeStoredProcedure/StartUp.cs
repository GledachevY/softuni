using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text;

namespace IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=.;Database=MinionsDb;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            int minionId = int.Parse(Console.ReadLine());

            string result = IncreaseMinionAgeById(sqlConnection, minionId);

            Console.WriteLine(result);
        }

        private static string IncreaseMinionAgeById(SqlConnection sqlConnection, int minionId)
        {
            StringBuilder sb = new StringBuilder();

            string pocName = @"usp_GetOlder";

            using SqlCommand incraseAgeCmd = new SqlCommand
                (pocName, sqlConnection);
            incraseAgeCmd.CommandType = CommandType.StoredProcedure;
            incraseAgeCmd.Parameters.AddWithValue(@"minionId", minionId);

            incraseAgeCmd.ExecuteNonQuery();

            string getMinionInfoQuerytext = @"SELECT Name, Age 
                                              FROM Minions
                                              WHERE ID = @minionId";

            using SqlCommand getMinionInfoCmd = new SqlCommand
                (getMinionInfoQuerytext, sqlConnection);
            getMinionInfoCmd.Parameters.AddWithValue("@minionId", minionId);

            using SqlDataReader reader = getMinionInfoCmd.ExecuteReader();

            reader.Read();

            string minionName = reader["Name"]?.ToString();
            string minionAge = reader["Age"]?.ToString();

            sb.AppendLine($"{minionName } - {minionAge} years old");

            return sb.ToString().TrimEnd();
        }
    }
}
