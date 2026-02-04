using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ground.Filler
{
    public class LevelFiller : MonoBehaviour
    {
        [SerializeField] private float _delay;

        private CancellationTokenSource _cancellationTokenSource;
        private Vector3 _scaleUp = Vector3.up;

        private void OnEnable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            ScaleY(_cancellationTokenSource.Token).Forget();
        }

        private void OnDisable() =>
            StopScaling();

        public void StopScaling()
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
        }

        private async UniTask ScaleY(CancellationToken cancellationToken)
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: cancellationToken);
                transform.localScale += _scaleUp;
            }
        }
    }
}