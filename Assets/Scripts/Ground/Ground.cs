using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Platform
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;

        private List<Transform> _originalPoints;

        public List<Transform> Points => _points;

        private void Awake()
        {
            if (_points == null)
                _points = new List<Transform>();

            _originalPoints = new List<Transform>(_points);
        }

#if UNITY_EDITOR
        [ContextMenu("Refresh Child Array")]
        private void RefreshChildArray()
        {
            for (int i = 0; i < transform.childCount; i++)
                _points.Add(transform.GetChild(i));

            _originalPoints = new List<Transform>(_points);
        }
#endif

        public Transform GetRandomPoint()
        {
            if (_points.Count == 0)
                return null;

            int randomIndex = Random.Range(0, _points.Count);
            Transform point = _points[randomIndex];
            _points.RemoveAt(randomIndex);
            return point;
        }

        public void ResetPoints()
        {
            _points.Clear();
            _points.AddRange(_originalPoints);
        }

        private void Reset() =>
            RefreshChildArray();
    }
}