using Assets.Scripts.Input;
using Assets.Scripts.Particles;
using Assets.Scripts.Player.Attack;
using Assets.Scripts.Player.Move;
using Assets.Scripts.Service.AchievementServices;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Player.Core
{
    public class CharacterFactory : MonoBehaviour
    {
        [SerializeField] private Character _characterPrefab;

        private IInput _input;
        private IParticleSpawner _particleSpawner;
        private PlayerInput _playerInput;
        private ICharacterDeathTracker _deathTrackerService;

        [Inject]
        public void Construct(IInput input,
            IParticleSpawner particleSpawner,
            PlayerInput playerInput,
            ICharacterDeathTracker deathTrackerService)
        {
            _input = input;
            _particleSpawner = particleSpawner;
            _playerInput = playerInput;
            _deathTrackerService = deathTrackerService;
        }

        public CharacterHolder CreateCharacter()
        {
            Character character = Instantiate(_characterPrefab);

            SkinChanger skinChanger = character.GetComponent<SkinChanger>();
            Movement movement = character.GetComponent<Movement>();
            CharacterAttacker attacker = character.GetComponent<CharacterAttacker>();

            movement.Construct(_input, _playerInput);
            character.Construct(_particleSpawner, _deathTrackerService);

            CharacterHolder holder = new CharacterHolder();
            holder.Initialize(character,
                movement,
                attacker,
                skinChanger);

            DontDestroyOnLoad(character);
            return holder;
        }
    }
}