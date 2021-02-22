using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace RemoveVillian
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=.;Database=MinionsDb;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            int villianIdToRemove = int.Parse(Console.ReadLine());

            string result = RemoveVillianById(sqlConnection, villianIdToRemove);

            Console.WriteLine(result);
        }

        private static string RemoveVillianById(SqlConnection sqlConnection, int villianIdToRemove)
        {
            StringBuilder sb = new StringBuilder();

            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            string getVillianNameQueryText = @"SELECT [Name] FROM Villains
                                                    Where Id = @villianId";

            using SqlCommand getVillianNameCmd = new SqlCommand
                (getVillianNameQueryText, sqlConnection);
            getVillianNameCmd.Parameters.AddWithValue("@villianId", villianIdToRemove);
            getVillianNameCmd.Transaction = sqlTransaction;

            string villianName = getVillianNameCmd.ExecuteScalar()?.ToString();

            if(villianName == null)
            {
                sb.AppendLine("No such villain was found.");
            }
            else
            {
                try
                {
                    string realiseMinionsQueryText = @"DELETE FROM MinionsVillains 
                                                       WHERE VillainId = @villianId";

                    using SqlCommand realiseMinionsCmd = new SqlCommand
                        (realiseMinionsQueryText, sqlConnection);
                    realiseMinionsCmd.Parameters.AddWithValue("@villianId", villianIdToRemove);
                    realiseMinionsCmd.Transaction = sqlTransaction;

                  int realisedMinionsCount = realiseMinionsCmd.ExecuteNonQuery();

                    string deleteVillianQueryText = @"DELETE FROM Villains
                                            WHERE Id = @villianId";
                    using SqlCommand deleteVillianCmd = new SqlCommand
                        (deleteVillianQueryText, sqlConnection);
                    deleteVillianCmd.Parameters.AddWithValue("@villianId", villianIdToRemove);
                    deleteVillianCmd.Transaction = sqlTransaction;

                    deleteVillianCmd.ExecuteNonQuery();

                    sqlTransaction.Commit();

                    sb.AppendLine($"{villianName} was deleted.");
                    sb.AppendLine($"{realisedMinionsCount} minions were realised.");

                }
                catch (Exception ex)
                {

                    sb.AppendLine(ex.Message);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception rollbackExeption)
                    {

                        sb.AppendLine(rollbackExeption.Message);
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
