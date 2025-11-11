using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System;
using System.Threading.Tasks;

namespace Assets.Scripts.Enemies.Obstacle
{
    public class WaypointPatroller
    {
        private const float MinDistanceToTarget = 0.05f;

        private Transform _transform;
        private Rigidbody _rigidbody;
        private Vector3 _currentTarget;

        private float _speed;
        private float _delay = 0.02f;
        private bool _isWalking = true;

        private Queue<Vector3> _targets;

        public WaypointPatroller(Transform transform, Rigidbody rigidbody, float speed, IEnumerable<Vector3> targets)
        {
            _transform = transform;
            _rigidbody = rigidbody;
            _speed = speed;
            _targets = new Queue<Vector3>(targets);

            _currentTarget = _targets.Peek();
            SwitchTarget();
        }

        public async UniTask StopMove()
        {
            _isWalking = false;
            _rigidbody.velocity = Vector3.zero;
            _targets.Dequeue();
            await UniTask.CompletedTask;
        }

        public UniTask Move(CancellationToken cancellationToken)
        {
            Vector3 position = new Vector3(_transform.position.x, _transform.position.y, _transform.position.z);
            Vector3 direction = _currentTarget - position;

            _rigidbody.velocity = direction.normalized * _speed;

            if (direction.magnitude <= MinDistanceToTarget)
                SwitchTarget();

            _isWalking = true;
            return UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: cancellationToken);
        }

        private void SwitchTarget()
        {
            _currentTarget = _targets.Dequeue();
            _targets.Enqueue(_currentTarget);
        }
    }
}