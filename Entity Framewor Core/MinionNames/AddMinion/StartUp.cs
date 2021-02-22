using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace AddMinion
{
    class StartUp
    {
        private const string ConnectionString = @"Server=.;Database=MinionsDb;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string[] minnionsInput = Console.ReadLine().Split(": ",
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] minnionsInfo = minnionsInput[1].Split(' ',
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] villainsinput = Console.ReadLine().Split(": ", StringSplitOptions
                .RemoveEmptyEntries)
                .ToArray();
            string[] villianInfo = villainsinput[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string result = AddMinionToDatabase(sqlConnection, minnionsInfo, villianInfo);
            Console.WriteLine(result);
        }

        private static string AddMinionToDatabase(SqlConnection sqlConnection, string[] minnionsInfo, string[] villianInfo)
        {
            StringBuilder output = new StringBuilder();

            string minionName = minnionsInfo[0];
            string minionsAge = minnionsInfo[1];
            string minionTown = minnionsInfo[2];
            string townCountry = minnionsInfo[3];

            string villianName = villianInfo[0];

            string townId = EnsureTownExist(sqlConnection, minionTown, output);
            string villianId = EnsureVillianExists(sqlConnection, villianName, output);
            string insertMinionQueryText = @"INSERT INTO Minions([Name], Age, TownId)
                                                Values(@minionName, @minionAge, @townid)";
            using SqlCommand isertMinionCmd = new SqlCommand
                (insertMinionQueryText, sqlConnection);
            isertMinionCmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@minionName", minionName),
                new SqlParameter("@minionAge", minionsAge),
                new SqlParameter("@townid", townId)
            });

            isertMinionCmd.ExecuteNonQuery();

            string getMinionIdQueryText = @"SELECT Id FROM Minions WHERE [Name] = @minionName";

            using SqlCommand getMinionIdCmd = new SqlCommand
                (getMinionIdQueryText, sqlConnection);
            getMinionIdCmd.Parameters.
                AddWithValue("@minionName", minionName);

            string minionId = getMinionIdCmd.ExecuteScalar().ToString();

            string insertIntoMppaingQueryText = @"INSERT INTO MinionsVillains(MinionId, VillainId)
                                                            VALUES (@minionId, @vilianId)";

            using SqlCommand insertIntoMappingCmd = new SqlCommand
                (insertIntoMppaingQueryText, sqlConnection);
            insertIntoMappingCmd.Parameters.AddRange(new[] 
            {
                new SqlParameter("@minionId", minionId),
                 new SqlParameter("@vilianId", villianId)
            });

            insertIntoMappingCmd.ExecuteNonQuery();

            output.AppendLine($"Successfully added {minionName} to be minion of {villianName}");

            return output.ToString().TrimEnd();
        }

        private static string EnsureVillianExists(SqlConnection sqlConnection, string villianName, StringBuilder output)
        {
            string GetVillianQueryText = @"SELECT Id FROM Villains
                                            WHERE [Name] = @name";
            using SqlCommand getVillianIdCmd = new SqlCommand
                (GetVillianQueryText, sqlConnection);
            getVillianIdCmd.Parameters.AddWithValue("@name", villianName);

            string villianId = getVillianIdCmd.ExecuteScalar()?
                .ToString();

            if(villianId == null)
            {
                string getFactorIdQueryText = @"SELECT Id FROM EvilnessFactor
                                                WHERE [Name] = 'Evil'";
                using SqlCommand getDactorIdCmd = new SqlCommand
                    (getFactorIdQueryText, sqlConnection);

                string factorId = getDactorIdCmd.ExecuteScalar()?
                    .ToString();

                string insertVillianQueryText = @"INSERT INTO Villains([Name], EvilnessFactorId)
                                                    VALUES(@villianNmae, @factorId)";
                using SqlCommand insertVillianCmd = new SqlCommand
                    (insertVillianQueryText, sqlConnection);
                insertVillianCmd.Parameters.AddWithValue("@villianNmae", villianName);
                insertVillianCmd.Parameters.AddWithValue("@factorId", factorId);

                insertVillianCmd.ExecuteNonQuery();

                villianId = getVillianIdCmd.ExecuteScalar().ToString();

                output.AppendLine($"Villain {villianName} was added to the database.");
            }

            return villianId;
        }

        private static string EnsureTownExist(SqlConnection sqlConnection, string minionTown,StringBuilder output)
        {
            string getTownIdQueryText = @"SELECT Id FROM Towns
                                        WHERE Name = @townName";
            using SqlCommand getTotwnIdCmd = new SqlCommand
                (getTownIdQueryText, sqlConnection);
            getTotwnIdCmd.Parameters.AddWithValue("@townName", minionTown);

            //May be missing
            string townId = getTotwnIdCmd.ExecuteScalar()?.ToString();

            if(townId == null)
            {
                string insertTownQueryText = @"Insert INTO Towns([Name], CountryCode)
                                                VALUES (@townName, 1)";
                using SqlCommand insertTownCmd = new SqlCommand
                    (insertTownQueryText, sqlConnection);
                insertTownCmd.Parameters.AddWithValue("@townName", minionTown);

                insertTownCmd.ExecuteNonQuery();

                townId = getTotwnIdCmd.ExecuteScalar().ToString();

                output.AppendLine($"Town {minionTown} was added to the database.");
            }
            return townId;
            
        }
    }
}
