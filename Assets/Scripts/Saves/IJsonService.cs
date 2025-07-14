namespace Assets.Scripts.Json
{
    public interface IJsonService
    {
        T Deserialize<T>(string json);
        string Serialize<T>(T t);
    }
}