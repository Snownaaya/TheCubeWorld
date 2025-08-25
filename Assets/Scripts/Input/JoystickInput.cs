using UnityEngine;

namespace Assets.Scripts.Input
{
    public class JoystickInput : MonoBehaviour, IJoystickInput
    {
        [SerializeField] private Joystick _joystick;

        public Joystick Joystick => _joystick;
    }
}
