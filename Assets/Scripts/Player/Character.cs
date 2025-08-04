using UnityEngine;
using Reflex.Attributes;
using Assets.Scripts.Loss;
using Assets.Scripts.Particles;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.Input;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.GameStateMachine.States;
using Assets.Scripts.HealthCharacters.Characters;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(PlayerInput), typeof(Rigidbody), typeof(CollisionHandler))]
    [RequireComponent(typeof(CharacterHealth))]
    public class Character : MonoBehaviour, IMoveble
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private Transform _characterModel;
        [SerializeField] private ParticleSpawner _characterEffects;

        [SerializeField] private float _speed = 3f;

        private Rigidbody _rigidbody;
        private CollisionHandler _collisionHandler;
        private Transform _transform;
        private CharacterHealth _health;

        private IInventory _playerInventory;
        private IInput _input;
        private ISwitcher _stateSwitcher;

        private float _speedRate = 1.5f;
        private bool _isMoving;

        [Inject]
        private void Construct(ISwitcher stateSwitcher, IInventory inventory)
        {
            _playerInventory = inventory;
            _stateSwitcher = stateSwitcher;
        }

        private void Awake()
        {
            _transform = transform;
            PlayerInput = new PlayerInput();
            _input = new DesktopInput(this);
            _rigidbody = GetComponent<Rigidbody>();
            _collisionHandler = GetComponent<CollisionHandler>();
            _health = GetComponent<CharacterHealth>();
            _characterView.Initialize();
            _characterEffects.Initialize(_transform);
            DontDestroyOnLoad(gameObject);
            //_playerInventory.Initialize();
        }

        public PlayerInput PlayerInput { get; private set; }
        public Rigidbody Rigidbody => _rigidbody;
        public CharacterView CharacterView => _characterView;
        public IInventory PlayerInventory => _playerInventory;
        public float Speed => _speed;
        public Joystick Joystick => _joystick;

        private void OnEnable()
        {
            PlayerInput.Enable();
            _collisionHandler.Died += ProccesCollision;
            _health.Died += ProccesCollision;
        }

        private void OnDisable()
        {
            PlayerInput.Disable();
            _collisionHandler.Died -= ProccesCollision;
            _health.Died -= ProccesCollision;
        }

        public void Move(Vector3 direction)
        {
            _characterModel.LookAt(_characterModel.position + direction);
            _rigidbody.velocity = direction * _speed * _speedRate;

            _characterView.StartMovement();
            _characterView.StartWalk();
            _characterView.StopIdle();
            _isMoving = true;
        }

        public void StopMove()
        {
            if (_rigidbody != null)
                _rigidbody.velocity = Vector3.zero;

            _characterView.StartMovement();
            _characterView.StartIdle();
            _characterView.StopWalk();
            _isMoving = false;
        }

        private void ProccesCollision(ILoss loss)
        {
            if (loss is LossCollision || loss is LossHealth)
            {
                _characterEffects.SpawnParticle(ParticleTypes.CharacterDeath, transform);
                _characterView.StopWalk();
                _characterView.StopIdle();
                _characterView.StopAttack();
                _characterModel.gameObject.SetActive(false);
                _stateSwitcher.SwitchState<LossState>();
            }
        }
    }
}