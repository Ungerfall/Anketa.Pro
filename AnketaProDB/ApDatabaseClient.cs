using System;
using Npgsql;

namespace AnketaProDB
{
    public class ApDatabaseClient : IDatabaseClient, IDisposable
    {
        private NpgsqlConnection nConnection;

        public void ConnectToData(string connectionString)
        {
            try
            {
                nConnection = new NpgsqlConnection(connectionString);
                nConnection.Open();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void SendQuery(string query)
        {
            try
            {
                var command = new NpgsqlCommand(query, nConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void Dispose()
        {
            nConnection.Close();
            nConnection.Dispose();
        }
    }
}