using UnityEngine;

namespace Assets.Scripts.Enemies.Boss
{
    public interface IBossTarget
    {
        Transform GetTargetTransform();
        Vector3 GetTargetPosition();
        bool IsValidTarget();
    }
}