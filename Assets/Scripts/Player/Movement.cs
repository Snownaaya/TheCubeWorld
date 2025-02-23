using Assets.Scripts.Interfaces;
using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

[Serializable]
public class Movement
{
    [SerializeField] private Vector2 _joystickSize = new Vector2(300, 300);
    private Vector2 _moveDirection;

    private Finger _movementFinger;
    private FloatingJoystick _floatingJoystick;
    private IMoveble _moveble;

    private float _joystickSizeDivider = 2f;

    public Movement(IMoveble moveble, FloatingJoystick floating)
    {
        _moveble = moveble;
        _moveDirection = Vector3.zero;
        _floatingJoystick = floating;
    }

    public void MovementUpdate()
    {
        Vector3 scaleMovement = _moveble.Speed * Time.deltaTime * new Vector3(_moveDirection.x,
            0, _moveDirection.y);

        _moveble.Transform.Translate(scaleMovement);
    }

    public void OnGingerDown(Finger touchFingerScreen)
    {
        if (_movementFinger == null)
        {
            _movementFinger = touchFingerScreen;
            _moveDirection = Vector2.zero;
            _floatingJoystick.gameObject.SetActive(true);
            _floatingJoystick.RectTransform.anchoredPosition = ClampStartPosition(touchFingerScreen.screenPosition);
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
        }
    }

    private Vector2 ClampStartPosition(Vector2 screenPosition)
    {
        if (screenPosition.x < _joystickSize.x / _joystickSizeDivider)
            screenPosition.x = _joystickSize.x / _joystickSizeDivider;

        if (screenPosition.y < _joystickSize.y / _joystickSizeDivider)
            screenPosition.y = _joystickSize.y / _joystickSizeDivider;

        else if (screenPosition.y > Screen.height - _joystickSize.y / _joystickSizeDivider)
            screenPosition.y = Screen.height - _joystickSize.y / _joystickSizeDivider;

        return screenPosition;
    }

    public void OnFingerUp(Finger finger)
    {
        _movementFinger = null;
        _floatingJoystick.Knob.anchoredPosition = Vector2.zero;
        _floatingJoystick.gameObject.SetActive(false);
        _moveDirection = Vector2.zero;
    }
}