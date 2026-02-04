using Reflex.Attributes;

namespace Assets.Scripts.Enemies.Boss.Target
{
    public class CurrentBossService : IBossTargetService
    {
        private IBossTarget _currentBoss;

        [Inject]
        private void Construct(IBossTarget bossTarget) =>
            _currentBoss = bossTarget;

        public void SetCurrentTarget(IBossTarget target) =>
            _currentBoss = target;

        public void ClearCurrentBoss() =>
            _currentBoss = null;

        public IBossTarget GetCurrentBoss() =>
                _currentBoss;
    }
}