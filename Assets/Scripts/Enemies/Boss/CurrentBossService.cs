namespace Assets.Scripts.Enemies.Boss
{
    public class CurrentBossService : IBossTargetService
    {
        private IBossTarget _currentBoss;

        public void SetTarget(IBossTarget target) =>
            _currentBoss = target;

        public void ClearCurrentBoss() => 
            _currentBoss = null;

        public IBossTarget GetCurrentBoss() =>
            _currentBoss?.IsValidTarget() == true ? _currentBoss : null;
    }
}