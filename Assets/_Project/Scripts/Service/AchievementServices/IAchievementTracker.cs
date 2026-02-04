namespace Assets.Scripts.Service.AchievementServices
{
    public interface IAchievementTracker<in T> where T : class
    {
        void Register(T @object);
        void Unregister(T @object);
    }
}