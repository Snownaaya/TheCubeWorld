using System;
using UnityEngine;
using Assets.Scripts.Interfaces;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

[Serializable]
public class Movement
{
    [SerializeField] private Vector2 _joystickSize = new Vector2(100, 100);

    private Vector2 _moveDirection;
    private Finger _movementFinger;
    private FloatingJoystick _floatingJoystick;
    private IMoveble _moveble;
    private float _speedRate = 1f;
    private float _joystickSizeDivider = 2f;
    private bool _isMoving;

    public Movement(IMoveble moveble, FloatingJoystick floating)
    {
        _moveble = moveble;
        _moveDirection = Vector2.zero;
        _floatingJoystick = floating;
        _isMoving = false;
    }

    public void MovementUpdate()
    {
        Vector3 scaleMovement = new Vector3(-_moveDirection.y, 0f, _moveDirection.x);
        _moveble.Rigidbody.velocity = -scaleMovement * _speedRate * _moveble.Speed;

        if (_moveDirection != Vector2.zero)
        {
            float rotation = Mathf.Atan2(_moveDirection.x, _moveDirection.y) * Mathf.Rad2Deg - 180;
            _moveble.Rigidbody.rotation = Quaternion.Euler(0f, rotation, 0f);
        }

        if (_moveble.CharacterView != null)
            _moveble.CharacterView.UpdateAnimation(_isMoving);
    }

    public void OnFingerDown(Finger touchFingerScreen)
    {
        if (_movementFinger == null)
        {
            _movementFinger = touchFingerScreen;
            _moveDirection = Vector2.zero;
        }
    }

    public void OnFingerMove(Finger move)
    {
        if (move == _movementFinger)
        {
            Vector2 positionKnob;
            float maxMovement = _joystickSize.x / _joystickSizeDivider;
            ETouch.Touch currentTouch = move.currentTouch;

            if (Vector2.Distance(currentTouch.screenPosition, _floatingJoystick.RectTransform.anchoredPosition) > maxMovement)
                positionKnob = (currentTouch.screenPosition - _floatingJoystick.RectTransform.anchoredPosition).normalized * maxMovement;
            else
                positionKnob = currentTouch.screenPosition - _floatingJoystick.RectTransform.anchoredPosition;

            _floatingJoystick.Knob.anchoredPosition = positionKnob;
            _moveDirection = positionKnob / maxMovement;
            _isMoving = true;
        }
    }

    public void OnFingerUp(Finger finger)
    {
        _movementFinger = null;
        _floatingJoystick.Knob.anchoredPosition = Vector2.zero;
        _moveDirection = Vector2.zero;
        _isMoving = false;
    }
}