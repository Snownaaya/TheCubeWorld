namespace Assets.Scripts.Service.Saves
{
    public interface ISaveService
    {
        void Save(string dataKey, string data);
        string Load(string dataKey);
    }
}
