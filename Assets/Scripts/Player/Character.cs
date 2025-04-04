using UnityEngine;
using Assets.Scripts.Interfaces;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody))]
public class Character : MonoBehaviour, IMoveble
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private Movement _movement;

    private PlayerInput _playerInput;
    private Transform _transform;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = new PlayerInput();
        _movement = new Movement(this, _floatingJoystick);
    }

    public float Speed => _speed;
    public Transform Transform => _transform;
    public Rigidbody Player => _rigidbody;

    private void FixedUpdate()
    {
        _movement.MovementUpdate();
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += _movement.OnFingerDown;
        ETouch.Touch.onFingerUp += _movement.OnFingerUp;
        ETouch.Touch.onFingerMove += _movement.OnFingerMove;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= _movement.OnFingerDown;
        ETouch.Touch.onFingerUp -= _movement.OnFingerUp;
        ETouch.Touch.onFingerMove -= _movement.OnFingerMove;
        EnhancedTouchSupport.Disable();
    }
}