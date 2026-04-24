namespace Assets.Scripts.Player.Move
{
    using System;
    using Assets.Scripts.Datas.Character;
    using Assets.Scripts.Input;
    using Reflex.Attributes;
    using UnityEngine;

    public class Movement : MonoBehaviour, IMoveble
    {
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private Transform _characterModel;
        [SerializeField] private CharacterView _currentCharacterView;
        [SerializeField] private Rigidbody _rigidbody;

        private bool _isMoving;
        private bool _isInputLocked;
        private PlayerInput _playerInput;
        private IInput _input;
        private Vector3 _currentDirection;
        private Vector3 _targetDirection;

        public event Action<Vector3> PositionChanged;

        public Transform CharacterModel => _characterModel;

        private void Awake() =>
            _characterModel = transform;

        [Inject]
        public void Construct(
            IInput input,
            PlayerInput playerInput)
        {
            _input = input;
            _playerInput = playerInput;

            Enable();
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

                PositionChanged?.Invoke(transform.position);
            }
        }

        public void OnDestroy()
        {
            Disable();
            _input.Moved -= OnMove;
            _input.Dispose();
            _input.Stopped -= StopMove;
        }

        public void OnMove(Vector3 direction)
        {
            if (_isInputLocked)
                return;

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

        public void Enable() =>
            _playerInput.Enable();

        public void Disable() =>
            _playerInput.Disable();
    }
}
