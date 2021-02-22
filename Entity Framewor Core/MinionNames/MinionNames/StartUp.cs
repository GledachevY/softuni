using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace MinionNames
{
    class StartUp
    {
        private const string ConnectionString = @"Server=.;Database=MinionsDb;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            int villianId = int.Parse(Console.ReadLine());

            string result = GetMinionsInfoAboutVillian(sqlConnection, villianId);
            Console.WriteLine(result);

        }

        private static string GetMinionsInfoAboutVillian(SqlConnection sqlConnection, int villianId)
        {

            StringBuilder sb = new StringBuilder();

            string villianName = GetVillianName(sqlConnection, villianId);

            if (villianName == null)
            {
                sb.AppendLine($"No villain with ID {villianId} exists in the database.");
            }
            else
            {
                sb.AppendLine($"Villain: {villianName}");

                string getMinionsInfoQueryText = @"SELECT m.Name, m.Age FROM Villains As v
                                                 LEFT OUTER JOIN MinionsVillains as mv
                                                 On v.Id = mv.VillainId
                                                 LEFT OUTER JOIN Minions As m 
                                                 ON mv.MinionId = m.Id
                                                 WHERE v.Name = @villianName
                                                 ORDER BY m.Name";

                SqlCommand getMinnionsInfoComand = new SqlCommand(getMinionsInfoQueryText, sqlConnection);
                getMinnionsInfoComand.Parameters.AddWithValue("@villianName", villianName);

                using SqlDataReader reader = getMinnionsInfoComand.ExecuteReader();

                if (reader.HasRows)
                {
                    int rowNum = 1;
                    while (reader.Read())
                    {
                        string minionName = reader["Name"]?.ToString();
                        string minionAge = reader["Age"]?.ToString();
                        sb.AppendLine($"{rowNum}. {minionName} {minionAge}");

                        rowNum++; 
                    }
                }
                else
                {
                    sb.AppendLine("(no minions)");
                }
               
            }
            return sb.ToString().TrimEnd();
        }
        private static string GetVillianName(SqlConnection sqlConnection, int villianId)
        {
            string getVillianNameQueryText = @"SELECT Name FROM Villains 
                                             WHERE Id = @villianId";

            using SqlCommand getVillianNameCmd = new SqlCommand
                 (getVillianNameQueryText, sqlConnection);
            getVillianNameCmd.Parameters.AddWithValue("@villianId", villianId);

            string villianName = getVillianNameCmd.ExecuteScalar()?
                                                    .ToString();

            return villianName;

        }
    }
}
