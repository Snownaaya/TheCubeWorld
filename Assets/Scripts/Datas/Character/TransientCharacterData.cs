using Assets.Scripts.Enemies.Obstacles;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Datas.Character
{
    public class TransientCharacterData : ITransientCharacterData
    {
        private ObstacleTypes _obstacleTypes;

        private List<ObstacleTypes> _openAbilities;

        public TransientCharacterData() =>
            _openAbilities = new List<ObstacleTypes>();

        public IEnumerable<ObstacleTypes> OpenAbilities => _openAbilities;

        public ObstacleTypes SelectedAbility
        {
            get => _obstacleTypes;
            set
            {
                if (_openAbilities.Contains(value) == false)
                    throw new ArgumentException(nameof(value));

                _obstacleTypes = value;
            }
        }

        public void OpenAbility(ObstacleTypes obstacleTypes)
        {
            if (_openAbilities.Contains(obstacleTypes))
                return;

            _openAbilities.Add(obstacleTypes);
        }
    }
}