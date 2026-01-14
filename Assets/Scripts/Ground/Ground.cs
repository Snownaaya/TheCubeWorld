using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Ground
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints;

        private List<Transform> _availablePoints = new(); 

        public int AvailableCount => _availablePoints.Count;
        public int TotalCount => _spawnPoints?.Count ?? 0;

        private void Awake()
        {
            ResetPoints();
        }

#if UNITY_EDITOR
        [ContextMenu("Refresh Spawn Points")]
        private void RefreshSpawnPoints()
        {
            _spawnPoints = new List<Transform>();

            for (int i = 0; i < transform.childCount; i++)
            {
                _spawnPoints.Add(transform.GetChild(i));
            }
        }
#endif

        public void ResetPoints()
        {
            _availablePoints.Clear();
            if (_spawnPoints != null)
                _availablePoints.AddRange(_spawnPoints);
        }

        public Transform GetRandomPoint()
        {
            if (_availablePoints.Count == 0)
                return null;

            int randomIndex = Random.Range(0, _availablePoints.Count);
            Transform point = _availablePoints[randomIndex];
            _availablePoints.RemoveAt(randomIndex);
            return point;
        }

        public void ReturnPoint(Transform point)
        {
            if (point == null)
                return;

            if (_availablePoints.Contains(point) == false)
                _availablePoints.Add(point);
        }
    }
}