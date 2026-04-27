using System;
using Random = UnityEngine.Random;

namespace Assets.Project.Scripts.Items
{
    [Serializable]
    public struct ChanceResourceSpawn
    {
        private float[] _weights;

        public ChanceResourceSpawn(float[] weights) =>
            _weights = weights;

        public int GetResource()
        {
            float totalWeight = 0f;

            for (int i = 0; i < _weights.Length; i++)
                totalWeight += _weights[i];

            float random = Random.value * totalWeight;
            float cumulative = 0f;

            for (int i = 0; i < _weights.Length; i++)
            {
                cumulative += _weights[i];

                if (random <= cumulative)
                    return i;
            }

            return _weights.Length;
        }
    }
}