namespace Assets.Scripts.Interfaces
{
    public interface ILockable
    {
        public bool IsLock { get; }
        public void Lock();
        public void Unlock();
    }
}
