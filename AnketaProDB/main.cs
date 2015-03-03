namespace AnketaProDB
{
    public static class Test
    {
        public static void Main()
        {
            var createDb = @"
                CREATE DATABASE AnketaProDb
                WITH OWNER = postgres
                ENCODING = 'UTF8'
                CONNECTION LIMIT = -1;";
            var createTable = "CREATE TABLE Anketa(ID CHAR(256) CONSTRAINT id PRIMARY KEY)";
            while (true)
            {
                using (var client = new ApDatabaseClient())
                {
                    client.ConnectToData("Server=localhost;Port=5432;User Id=postgres;Password=prsnbrk93");
                    client.SendQuery(createDb);
                }
            }
        }
    }
}