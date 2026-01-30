using Assets.Scripts.Datas.Character;
using Assets.Scripts.Input;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Assets.Scripts.Player.Move
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour, IMoveble
    {
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private Transform _characterModel;
        [SerializeField] private CharacterView _currentCharacterView;

        private bool _isMoving;

        private Rigidbody _rigidbody;
        private PlayerInput _playerInput;
        private IInput _input;
        private Vector3 _currentDirection;

        public Transform CharacterModel => _characterModel;

        public event Action PositionChanged;

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

        private void FixedUpdate()
        {
            if (_isMoving)
                _rigidbody.velocity = _currentDirection * _characterConfig.Speed * _characterConfig.SpeedRate;
        }

        public void OnDestroy()
        {
            _playerInput.Disable();
            _input.Moved -= OnMove;
            _input.Dispose();
            _input.Stopped -= StopMove;
        }

        public void OnMove(Vector3 direction)
        {
            _currentDirection = direction;
            _isMoving = true;
            _characterModel.LookAt(_characterModel.position + direction);
            PositionChanged?.Invoke();

            _currentCharacterView.StartWalk();
            _currentCharacterView.StopIdle();
        }

        public void StopMove()
        {
            if (_rigidbody != null)
                _rigidbody.velocity = Vector3.zero;

            _isMoving = false;
            _currentCharacterView.StartIdle();
            _currentCharacterView.StopWalk();
        }
    }
}