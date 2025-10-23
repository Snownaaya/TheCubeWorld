using Assets.Scripts.Service.AchievementServices;
using Assets.Scripts.Player.Attack;
using Assets.Scripts.Player.Move;
using Assets.Scripts.Particles;
using Assets.Scripts.Input;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Player.Core
{
    public class CharacterFactory : MonoBehaviour
    {
        [SerializeField] private Character _characterPrefab;

        private PlayerInput _playerInput;
        private IInput _input;
        private IParticleSpawner _particleSpawner;
        private DeathTrackerService _deathTrackerService;

        [Inject]
        public void Construct(IInput input,
            IParticleSpawner particleSpawner,
            PlayerInput playerInput,
            DeathTrackerService deathTrackerService)
        {
            _input = input;
            _particleSpawner = particleSpawner;
            _playerInput = playerInput;
            _deathTrackerService = deathTrackerService;
        }

        public CharacterHolder CreateCharacter()
        {
            Character character = Instantiate(_characterPrefab);
            Movement movement = character.GetComponent<Movement>();
            CharacterAttacker attacker = character.GetComponent<CharacterAttacker>();

            movement.Construct(_input, _playerInput);
            character.Construct(_particleSpawner, _deathTrackerService);

            CharacterHolder holder = new CharacterHolder();
            holder.Initialize(character, movement, attacker);

            DontDestroyOnLoad(character);
            return holder;
        }
    }
}