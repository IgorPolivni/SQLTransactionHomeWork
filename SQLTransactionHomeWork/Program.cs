using System;
using System.Data.SqlClient;

namespace SQLTransactionHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=DESKTOP-619RM10;Database=ConectionLesson;Trusted_Connection=True;";
            connection.Open();

            string sqlScript = "CREATE TABLE MyGroup (id int, Name nvarchar );";
            using (var transaction = connection.BeginTransaction())
            using (SqlCommand command = new SqlCommand(sqlScript, connection))
            {
                try
                {
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException exception)
                {
                    Console.WriteLine(exception.Message);
                    transaction.Rollback();
                }
            }


        }
    }
}
