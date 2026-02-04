using Assets.Scripts.UI.HealthCharacters.Characters;
using UnityEngine;

namespace Assets.Scripts.Enemies.Boss.Target
{
    public interface IBossTarget
    {
        BossHealth BossHealth { get; }
        Vector3 GetTarget();
        bool IsValidTarget();
    }
}