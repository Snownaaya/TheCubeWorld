using System;
using System.Diagnostics;

namespace Assets.Scripts.HealthCharacters.Characters
{
    public class BossHealth : Health
    {
        public event Action Died;

        public override void NotifyDeath() =>
            Died?.Invoke();
    }
}