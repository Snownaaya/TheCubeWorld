namespace Assets.Scripts.Enemies.Boss
{
    public interface IBossTargetService
    {
        IBossTarget GetCurrentBoss();
        void SetTarget(IBossTarget target);
        void ClearCurrentBoss();
    }
}