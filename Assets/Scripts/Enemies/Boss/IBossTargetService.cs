namespace Assets.Scripts.Enemies.Boss
{
    public interface IBossTargetService
    {
        IBossTarget GetCurrentBoss();
        void SetCurrentTarget(IBossTarget target);
        void ClearCurrentBoss();
    }
}