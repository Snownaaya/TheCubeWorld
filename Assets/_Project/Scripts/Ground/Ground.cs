namespace Assets.Scripts.Ground
{
    using System.Collections.Generic;
    using UnityEngine;

    public class Ground : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints;

        private Queue<Transform> _availablePoints = new ();

        public int AvailableCount => _availablePoints.Count;

        public int TotalCount => _spawnPoints?.Count ?? 0;

        private void Awake() =>
            ResetPoints();

#if UNITY_EDITOR
        [ContextMenu("Refresh Spawn Points")]
        private void RefreshSpawnPoints()
        {
            _spawnPoints = new List<Transform>();

            for (int i = 0; i < transform.childCount; i++)
            {
                _spawnPoints.Add(transform.GetChild(i));
            }

            ResetPoints();
        }
#endif

        public void ResetPoints()
        {
            _availablePoints.Clear();

            foreach (Transform point in _spawnPoints)
                _availablePoints.Enqueue(point);
        }

        public Transform GetPoint()
        {
            if (_availablePoints.Count == 0)
                return null;

            return _availablePoints.Dequeue();
        }

        public void ReturnPoint(Transform point)
        {
            if (point == null)
                return;

            if (_availablePoints.Contains(point))
                return;

            _availablePoints.Enqueue(point);
        }
    }
}