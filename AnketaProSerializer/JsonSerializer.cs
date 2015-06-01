using Newtonsoft.Json;

namespace AnketaProSerializer
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize<T>(T output)
        {
            return JsonConvert.SerializeObject(output);
        }

        public T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}