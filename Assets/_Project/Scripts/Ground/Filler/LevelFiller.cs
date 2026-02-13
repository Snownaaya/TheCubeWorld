using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Assets.Project.Scripts.Ground.Filler;

namespace Assets.Scripts.Ground.Filler
{
    public class LevelFiller : MonoBehaviour, ILevelHazard
    {
        [SerializeField] private float _delay;
        [SerializeField] private Transform _transform;

        private Vector3 _scaleUp = Vector3.up;
        private CancellationTokenSource _cancellationTokenSource;

        private void Awake()
        {
            _transform.position = transform.position;
        }

        public void ResetFiller() =>
            _transform.position = new Vector3(0, -11, 0);

        public void Stop()
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
                ResetFiller();
            }
        }

        public void StartScale()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            ScaleY(_cancellationTokenSource.Token).Forget();
        }

        private async UniTask ScaleY(CancellationToken cancellationToken)
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: cancellationToken);
                _transform.position += _scaleUp;
            }
        }
    }
}