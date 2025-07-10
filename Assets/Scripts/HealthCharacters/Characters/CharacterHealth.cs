using Assets.Scripts.Interfaces;
using Assets.Scripts.Loss;
using System;

namespace Assets.Scripts.HealthCharacters.Characters
{
    public class CharacterHealth : Health
    {
        public event Action<ILoss> Died;

        public override void NotifyDeath() =>
            Died?.Invoke(new LossHealth());
    }
}
