namespace Assets.Scripts.VictoryReward
{
    public class RewardStripFactory
    {
        private const int BaseCoins = 20;

        public RewardStripModel Create()
        {
            float[] multipliers = { 2, 3, 4, 5, 4, 3, 2 };

            int initialIndex = 0;

            return new RewardStripModel(
                BaseCoins,
                multipliers,
                initialIndex
            );
        }
    }
}