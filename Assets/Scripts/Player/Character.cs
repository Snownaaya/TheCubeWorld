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
    [SerializeField] private CharacterView _characterView;

    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _characterView.Initialize();
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = new PlayerInput();
        _movement = new Movement(this, _floatingJoystick);
    }

    public float Speed => _speed;
    public Rigidbody Rigidbody => _rigidbody;
    public CharacterView CharacterView => _characterView;

    private void FixedUpdate() =>
        _movement.MovementUpdate();

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