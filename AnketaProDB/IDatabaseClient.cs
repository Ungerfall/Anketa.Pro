namespace AnketaProDB
{
    public interface IDatabaseClient
    {
        void ConnectToData(string connectionString);
        void SendQuery(string query);
    }
}