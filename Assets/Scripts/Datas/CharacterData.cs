using Assets.Scripts.Service.Properties;
using Assets.Scripts.Enemies.Obstacle;
using System.Collections.Generic;
using Assets.Scripts.Player.Core;
using System;

namespace Assets.Scripts.Datas
{
    public class CharacterData
    {
        private CharacterSkins _characterSkins;
        private ObstacleTypes _obstacleTypes;

        private NotLessZeroProperty<int> _money;

        private List<CharacterSkins> _openSkins;
        private List<ObstacleTypes> _openAbilities;

        public CharacterData()
        {
            _money = new NotLessZeroProperty<int>(1);

            _openSkins = new List<CharacterSkins>() { CharacterSkins.Bunny };
            _openAbilities = new List<ObstacleTypes>() { ObstacleTypes.Spikes };
        }

        public NotLessZeroProperty<int> Money => _money;

        public CharacterSkins SelectedCharacterSkin
        {
            get => _characterSkins;
            set
            {
                if (_openSkins.Contains(value) == false)
                    throw new ArgumentException(nameof(value));

                _characterSkins = value;
            }
        }

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

        public IReadOnlyList<CharacterSkins> OpenCharacterSkins => _openSkins;
        public IReadOnlyList<ObstacleTypes> OpenAbilities => _openAbilities;

        public void OpenCharacterSkin(CharacterSkins characterSkins)
        {
            if (_openSkins.Contains(characterSkins))
                throw new ArgumentException(nameof(characterSkins));

            _openSkins.Add(characterSkins);
        }

        public void OpenAbility(ObstacleTypes obstacleTypes)
        {
            if (_openAbilities.Contains(obstacleTypes))
                throw new ArgumentException(nameof(obstacleTypes));

            _openAbilities.Add(obstacleTypes);
        }
    }
}