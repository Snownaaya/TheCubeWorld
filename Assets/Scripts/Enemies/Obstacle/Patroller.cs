using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Enemies.Obstacle
{
    public class Patroller : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private List<Transform> _patrolPoints;
        [SerializeField] private Rigidbody _rigidbody;

        private WaypointPatroller _wayPoint;
        private CancellationTokenSource _cancellationTokenSource;

        private void Awake()
        {
            _wayPoint = new WaypointPatroller(transform,
                _rigidbody,
                _speed,
                _patrolPoints.Select(point => point.position));

            _wayPoint.StartMove();
        }

        private void OnEnable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            Move(_cancellationTokenSource.Token).Forget();
        }

        private void OnDisable()
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
        }

        public void StopMove()
        {
            if (_cancellationTokenSource != null && _cancellationTokenSource.IsCancellationRequested == false)
            {
                _wayPoint.StopMove().Forget();
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
        }

        private async UniTask Move(CancellationToken cancellationToken)
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                await _wayPoint.Move(cancellationToken);
                await UniTask.Yield(cancellationToken);
            }
        }
    }
}
