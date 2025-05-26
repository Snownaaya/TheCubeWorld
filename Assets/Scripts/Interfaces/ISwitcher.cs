namespace Assets.Scripts.Interfaces
{
    public interface ISwitcher
    {
        void SwitchState<T>() where T : IStates;
    }
}