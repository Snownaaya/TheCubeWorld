using UnityEngine;

namespace Assets.Scripts.Enemies.Boss
{
    public interface IBossTarget
    {
        Transform GetTargetTransform();
        bool IsValidTarget();
    }
}