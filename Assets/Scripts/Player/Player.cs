using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(ResourceCollected))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerInput _playerInput;
    private Movement _movement;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _movement = new Movement(transform, _speed);
    }

    private void Update()
    {
        _playerInput.Enable();
        _playerInput.Player.Move.performed += _movement.OnJoystickMove;
        _playerInput.Player.Move.canceled += _movement.OnJoystickMove;
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Player.Move.performed -= _movement.OnJoystickMove;
        _playerInput.Player.Move.canceled -= _movement.OnJoystickMove;
    }
}