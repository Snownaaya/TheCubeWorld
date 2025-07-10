using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Ground
{
    public class LevelFiller : MonoBehaviour
    {
        [SerializeField] private float _delay;

        private Vector3 _scaleUp = Vector3.up;

        private Coroutine _scaleCoroutine;

        private void Start() =>
            StartCoroutine(ScaleY());

        public void StopScaling()
        {
            if (_scaleCoroutine != null)
            {
                StopCoroutine(_scaleCoroutine); 
                _scaleCoroutine = null; 
            }
        }

        private IEnumerator ScaleY()
        {
            var wait = new WaitForSeconds(_delay);

            while (enabled)
            {
                yield return wait;
                transform.localScale += _scaleUp;
            }
        }
    }
}
