using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Enemies.Obstacle
{
    public class Patroller : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private List<Transform> _patrolPoints;

        private WaypointPatroller _wayPoint;

        private void Awake()
        {
            _wayPoint = new WaypointPatroller(transform, _speed, _patrolPoints.Select(point => point.position));
            _wayPoint.StartMove();
        }

        private void Update() =>
            _wayPoint?.Update();
    }
}
