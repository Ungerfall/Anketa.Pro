namespace AnketaProSerializer
{
    public interface ISerializer
    {
        string Serialize<T>(T output);
        T Deserialize<T>(string input);
    }
}