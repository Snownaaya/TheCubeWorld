namespace Assets.Scripts.UI.HealthCharacters.Characters
{
    using System;

    public class BossHealth : Health
    {
        public event Action Died;

        protected override void NotifyDeath() =>
            Died?.Invoke();
    }
}