namespace Assets.Scripts.Input
{
    public interface IJoystickInput
    {
        Joystick Joystick { get; }

        public void SetInteractable(bool interactable);

        public void Hide();
    }
} 