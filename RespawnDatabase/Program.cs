namespace RespawnDatabase
{
    using Respawn;
    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            ResetDatabase().Wait();
        }

        static async Task ResetDatabase()
        {
            Checkpoint checkpoint = new Checkpoint
            {
                TablesToIgnore = new[]
                {
                    "Courses"
                },
                DbAdapter = DbAdapter.SqlServer
            };

            string connectionString = @"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                await checkpoint.Reset(connection);
            }
        }
    }
}
