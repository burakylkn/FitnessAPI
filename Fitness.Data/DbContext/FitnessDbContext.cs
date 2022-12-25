using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Data.DBManager
{
    public class FitnessDbContext : IDisposable
    {
        public MySqlConnection Connection { get; }

        public FitnessDbContext(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}
