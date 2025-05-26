namespace Assets.Scripts.Interfaces
{
    public interface IHealth
    {
        public void TakeDamage(float damage);
        public bool CheckHealth(float heal = 0);
    }
}
