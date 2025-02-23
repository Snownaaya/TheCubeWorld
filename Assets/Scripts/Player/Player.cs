using UnityEngine;
using Assets.Scripts.Interfaces;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(PlayerInput), typeof(ResourceCollected), typeof(Rigidbody))]
public class Player : MonoBehaviour, IMoveble
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private Movement _movement;

    private PlayerInput _playerInput;
    private Transform _transform;

    public Transform Transform => _transform;

    public float Speed => _speed;

    private void Awake()
    {
        _transform = transform;
        _playerInput = new PlayerInput();
        _movement = new Movement(this, _floatingJoystick);
    }

    private void Update()
    {
        _movement.MovementUpdate();
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += _movement.OnGingerDown;
        ETouch.Touch.onFingerUp += _movement.OnFingerUp;
        ETouch.Touch.onFingerMove += _movement.OnFingerMove;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= _movement.OnGingerDown;
        ETouch.Touch.onFingerUp -= _movement.OnFingerUp;
        ETouch.Touch.onFingerMove -= _movement.OnFingerMove;
        EnhancedTouchSupport.Disable();
    }
}