using System;
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

        private bool _isMoving;
        private bool _isInputLocked;
        private Rigidbody _rigidbody;
        private PlayerInput _playerInput;
        private IInput _input;
        private Vector3 _currentDirection;
        private Vector3 _targetDirection;

        public Transform CharacterModel => _characterModel;
        public event Action PositionChanged;

        private void Awake()
        {
            _characterModel = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }

        [Inject]
        public void Construct(IInput input, PlayerInput playerInput)
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
            {
                float currentSpeed = _characterConfig.Speed;
                Vector3 targetVelocity = _targetDirection * currentSpeed;
                targetVelocity.y = _rigidbody.velocity.y;

                _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _currentDirection, _characterConfig.SpeedRate);
                PositionChanged?.Invoke();
            }
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
            if (_isInputLocked) return;
            _targetDirection = direction.normalized;
            _isMoving = true;
            if (direction != Vector3.zero)
                _characterModel.LookAt(_characterModel.position + direction);
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
