using Microsoft.Data.SqlClient;
using System;

namespace AdoNetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection
                ("Server=QVOR-PC;Database=SoftUni;Integrated Security=true"))
            {
                sqlConnection.Open();
                string command = "SELECT FIrstName, LastName, Salary FROM Employees " +
                    "WHERE FirstName LIKE 'N%'";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
          
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string firstName = reader["FirstName"] as String;
                        string lastname = reader[1] as String;
                        decimal salary = (decimal)reader["Salary"];
                        Console.WriteLine(firstName + " " + lastname + " " + salary);
                    }
                }

                SqlCommand updateSalaryCommand = new SqlCommand("UPDATE Employees SET Salary = Salary * 1.10", sqlConnection);
                int updatedRows = updateSalaryCommand.ExecuteNonQuery();
                Console.WriteLine($"Salary updated for {updatedRows } employee(s).");

                var reader2 = sqlCommand.ExecuteReader();
                using (reader2)
                {
                    while (reader2.Read())
                    {
                        string firstName = reader2["FirstName"] as String;
                        string lastname = reader2["LastName"] as String;
                        decimal salary = (decimal)reader2["Salary"];
                        Console.WriteLine(firstName + " " + lastname + " " + salary);
                    }
                }
            }
        }
    }
}
