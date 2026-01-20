using Assets.Scripts.Datas.Character;
using Assets.Scripts.Input;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Player.Move
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour, IMoveble
    {
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private Transform _characterModel;
        [SerializeField] private CharacterView _currentCharacterView;

        private Rigidbody _rigidbody;
        private PlayerInput _playerInput;
        private IInput _input;

        public Transform CharacterModel => _characterModel;

        private void Awake()
        {
            _characterModel = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }

        [Inject]
        public void Construct(IInput input,
            PlayerInput playerInput)
        {
            _input = input;
            _playerInput = playerInput;

            _playerInput.Enable();
            _input.Moved += OnMove;
            _input.Stopped += StopMove;
        }

        public void OnDestroy()
        {
            _playerInput.Disable();
            _input.Moved -= OnMove;
            _input.Stopped -= StopMove;
        }

        public void OnMove(Vector3 direction)
        {
            _characterModel.LookAt(_characterModel.position + direction);
            _rigidbody.velocity = direction * _characterConfig.Speed * _characterConfig.SpeedRate;

            _currentCharacterView.StartWalk();
            _currentCharacterView.StopIdle();
        }

        public void StopMove()
        {
            if (_rigidbody != null)
                _rigidbody.velocity = Vector3.zero;

            _currentCharacterView.StartIdle();
            _currentCharacterView.StopWalk();
        }
    }
}