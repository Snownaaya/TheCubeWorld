using Assets.Scripts.Interfaces;
using Assets.Scripts.Datas;
using Assets.Scripts.Loss;
using UnityEngine;
using System;

namespace Assets.Scripts.HealthCharacters.Characters
{
    public class CharacterHealth : Health
    {
        [SerializeField] private CharacterConfig _characterConfig;

        public event Action<ILoss> Died;

        public override void NotifyDeath() =>
            Died?.Invoke(new LossHealth());

        public void ResetHealth() =>
            Reset();
    }
}
