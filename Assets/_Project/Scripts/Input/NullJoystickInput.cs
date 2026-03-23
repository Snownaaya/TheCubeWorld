using UnityEngine;

namespace Assets.Scripts.Input
{
    public class NullJoystickInput : IJoystickInput
    {
        public Joystick Joystick => null;

        public void SetInteractable(bool interactable) { }

        public void Show() { }

        public void Hide() { }
    }
}