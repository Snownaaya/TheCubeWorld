using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(PlayerInput), typeof(ResourceCollected), typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private Movement _movement;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _movement = new Movement(transform, _speed, _floatingJoystick);
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