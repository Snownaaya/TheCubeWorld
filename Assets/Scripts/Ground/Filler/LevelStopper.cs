using UnityEngine;

namespace Assets.Scripts.Ground.Filler
{
    [RequireComponent(typeof(LevelFiller))]
    public class LevelStopper : MonoBehaviour
    {
        private LevelFiller _levelFiller;

        private void Awake() =>
            _levelFiller = GetComponent<LevelFiller>();

        public void LevelStopped() =>
            _levelFiller.StopScaling();
    }
}