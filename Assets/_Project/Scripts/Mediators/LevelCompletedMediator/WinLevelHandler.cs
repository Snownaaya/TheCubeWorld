namespace Assets.Project.Scripts.Mediators.LevelCompletedMediator
{
    public class WinLevelHandler
    {
        private readonly IWinLevelWindowMediator _winLevelWindowMediator;

        public WinLevelHandler(IWinLevelWindowMediator winLevelWindowMediator) =>
            _winLevelWindowMediator = winLevelWindowMediator;

        public void ProcessDefaultCoimResult() =>
            _winLevelWindowMediator.ProcessDefaultCoimResult();

        public void ProcessRewardWheelResult() =>
            _winLevelWindowMediator.ProcessRewardWheelResult();

        public void Show() =>
            _winLevelWindowMediator.Show();
    }
}