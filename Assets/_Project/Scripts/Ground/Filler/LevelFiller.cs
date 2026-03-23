namespace Assets.Scripts.Ground.Filler
{
    using System.Threading;
    using Assets.Project.Scripts.Ground.Filler;
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public class LevelFiller : MonoBehaviour, ILevelHazard
    {
        [SerializeField] private float _delay;
        [SerializeField] private Vector3 _scaleY;

        private Transform _transform;
        private Vector3 _startScale;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private void Start()
        {
            _transform = transform;
            _startScale = transform.localScale;
        }

        private void OnDestroy()
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource = null;
            }
        }

        public void ResetFiller() =>
            transform.localScale = _startScale;

        public void Stop()
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource = null;
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
                await UniTask.Yield();

                if (_transform == null)
                    return;

                _startScale = _transform.localScale;
                _startScale.y += Time.deltaTime * _scaleY.y;
                _transform.localScale = _startScale;
            }
        }
    }
}