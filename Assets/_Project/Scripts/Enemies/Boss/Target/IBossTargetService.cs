namespace Assets.Scripts.Enemies.Boss.Target
{
    public interface IBossTargetService
    {
        IBossTarget GetCurrentBoss();
        void SetCurrentTarget(IBossTarget target);
        void ClearCurrentBoss();
    }
}