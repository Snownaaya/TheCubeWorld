using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemies.Obstacle
{
    public class WaypointPatroller
    {
        private const float MinDistanceToTarget = 0.05f;

        private Transform _transform;
        private Queue<Vector3> _targets;

        private Vector3 _currentTarget;

        private int _speed;
        private bool _isWalking;

        public WaypointPatroller(Transform transform, int speed, IEnumerable<Vector3> targets)
        {
            _transform = transform;
            _speed = speed;
            _targets = new Queue<Vector3>(targets);

            //_currentTarget = _targets.Peek();
            SwitchTarget();
        }

        public void StartMove() =>
            _isWalking = true;

        public void StopMove() =>
            _isWalking = false;

        public void Update()
        {
            if (_isWalking == false)
                return;

            Vector3 position = new Vector3(_transform.position.x, _transform.position.y, _transform.position.z);
            Vector3 direction = _currentTarget - position;

            _transform.Translate(direction.normalized * _speed * Time.deltaTime);

            if (direction.magnitude <= MinDistanceToTarget)
                SwitchTarget();
        }

        private void SwitchTarget()
        {
            _currentTarget = _targets.Dequeue();
            _targets.Enqueue(_currentTarget);
        }
    }
}