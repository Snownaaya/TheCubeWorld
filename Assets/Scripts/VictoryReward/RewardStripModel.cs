using UnityEngine;

namespace Assets.Scripts.VictoryReward
{
    public class RewardStripModel
    {
        public int BaseCoins;
        public float[] Multipliers;
        public int CurrentIndex;

        public RewardStripModel
            (int baseCoins, 
            float[] multipliers, 
            int currentIndex)
        {
            BaseCoins = baseCoins;
            Multipliers = multipliers;
            CurrentIndex = currentIndex;
        }

        public int FinalCoins =>
            Mathf.RoundToInt(BaseCoins * Multipliers[CurrentIndex]);
    }
}