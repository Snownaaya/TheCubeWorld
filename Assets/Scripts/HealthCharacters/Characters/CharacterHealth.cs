using Assets.Scripts.Datas;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Loss;
using System;
using UnityEngine;

namespace Assets.Scripts.HealthCharacters.Characters
{
    public class CharacterHealth : Health
    {
        [SerializeField] private CharacterConfig _characterConfig;

        public event Action<ILoss> Died;

        public override void NotifyDeath() =>
            Died?.Invoke(new LossHealth());

        public void ResetHealth()
        {
            _characterConfig.Health = CurrentHealth.Value;
        }
    }
}
