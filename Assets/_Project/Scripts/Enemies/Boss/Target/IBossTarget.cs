namespace Assets.Scripts.Enemies.Boss.Target
{
    using UnityEngine;

    public interface IBossTarget
    {
        Vector3 GetTarget();

        bool IsValidTarget();
    }
}