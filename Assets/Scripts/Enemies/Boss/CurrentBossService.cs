using Reflex.Attributes;

namespace Assets.Scripts.Enemies.Boss
{
    public class CurrentBossService : IBossTargetService
    {
        private IBossTarget _currentBoss;

        public void SetCurrentTarget(IBossTarget target) =>
            _currentBoss = target;

        public void ClearCurrentBoss() =>
            _currentBoss = null;

        public IBossTarget GetCurrentBoss() =>
                _currentBoss;
    }
}