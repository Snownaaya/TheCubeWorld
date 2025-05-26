using UnityEngine;
using Assets.Scripts.Interfaces;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using Reflex.Attributes;
using Assets.Scripts.Other;
using System;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody), typeof(CharacterView))]
[RequireComponent(typeof(CollisionHandler))]
public class Character : MonoBehaviour, IMoveble
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private Movement _movement;

    private CharacterView _characterView;
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    private CollisionHandler _collisionHandler;

    private IInventory _playerInventory;
    private ILoss _loss;

    private bool _isAlive;

    [Inject]
    private void Construct(IInventory inventory)
    {
        _playerInventory = inventory;
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _movement = new Movement(this, _floatingJoystick);
        _rigidbody = GetComponent<Rigidbody>();
        _characterView = GetComponent<CharacterView>();
        _collisionHandler = GetComponent<CollisionHandler>();
        _characterView.Initialize();
    }

    public Rigidbody Rigidbody => _rigidbody;
    public CharacterView CharacterView => _characterView;
    public IInventory PlayerInventory => _playerInventory;
    public float Speed => _speed;

    public event Action GameOver;

    private void FixedUpdate()
    {
        _isAlive = true;
        _movement.MovementUpdate();
    }

    private void OnEnable()
    {
        _collisionHandler.Died += ProccesCollision;
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += _movement.OnFingerDown;
        ETouch.Touch.onFingerUp += _movement.OnFingerUp;
        ETouch.Touch.onFingerMove += _movement.OnFingerMove;

    }

    private void OnDisable()
    {
        _collisionHandler.Died -= ProccesCollision;
        ETouch.Touch.onFingerDown -= _movement.OnFingerDown;
        ETouch.Touch.onFingerUp -= _movement.OnFingerUp;
        ETouch.Touch.onFingerMove -= _movement.OnFingerMove;
        EnhancedTouchSupport.Disable();

    }

    private void ProccesCollision(ILoss loss)
    {
        if (loss is LossCollision && _isAlive)
        {
            _isAlive = false;
            GameOver?.Invoke();
        }
    }
}