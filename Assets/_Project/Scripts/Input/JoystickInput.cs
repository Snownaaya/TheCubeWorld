using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Input
{
    public class JoystickInput : MonoBehaviour, IJoystickInput
    {
        [SerializeField] private Joystick _joystick;

        private Image _backgroundImage;

        private void Awake() =>
            _backgroundImage = _joystick.GetComponent<Image>();

        public Joystick Joystick => _joystick;

        public void SetInteractable(bool interactable) =>
             _backgroundImage.raycastTarget = interactable;
    }
}