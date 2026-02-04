using System;

namespace Assets.Scripts.UI.HealthCharacters.Characters
{
    public class BossHealth : Health
    {
        public event Action Died;

        protected override void NotifyDeath() =>
            Died?.Invoke();
    }
}