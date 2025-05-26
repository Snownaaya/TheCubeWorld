namespace Assets.Scripts.LevelLoader.Loader
{
    internal class LevelLoadingData
    {
        public LevelLoadingData(int level)
        {
            Level = level;
        }

        public int Level { get; private set; }
    }
}
