using Assets.Scripts.HealthCharacters.Characters;
using UnityEngine;

namespace Assets.Scripts.Enemies.Boss.Target
{
    public interface IBossTarget
    {
        BossHealth BossHealth { get; }
        Transform GetTarget();
        bool IsValidTarget();
    }
}