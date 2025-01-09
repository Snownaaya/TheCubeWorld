using UnityEngine.InputSystem;
using UnityEngine;

public class Movement
{
    private Vector3 _moveDirection;
    private Transform _transform;

    private float _speed;

    public Movement(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
        _moveDirection = Vector3.zero;
    }

    public void OnJoystickMove(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _moveDirection = Vector3.zero;
            return;
        }

        if (context.performed)
        {
            _moveDirection = context.action.ReadValue<Vector2>();
            Move();
        }
    }

    private void Move()
    {
        float scaleDirection = _speed * Time.deltaTime;
        Vector3 offset = new Vector3(_moveDirection.x, 0, _moveDirection.y) * scaleDirection;
        _transform.Translate(offset);
    }
}