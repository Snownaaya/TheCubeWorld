namespace Assets.Project.Scripts.Mediators.LevelCompletedMediator
{
    public interface IWinLevelWindowMediator
    {
        public void ProcessDefaultCoimResult();

        public void ProcessRewardWheelResult();

        public void Show();
    }
}