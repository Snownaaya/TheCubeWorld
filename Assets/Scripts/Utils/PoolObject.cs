using UnityEngine;
using System.Collections.Generic;

public class PoolObject<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private Queue<T> _queue = new Queue<T>();

    public void Push(T @object)
    {
        @object.gameObject.SetActive(false);
        _queue.Enqueue(@object);
    }

    public T Pull(T @object)
    {
        if (_queue.Count > 0)
        {
            @object = _queue.Dequeue();
            @object.gameObject.SetActive(true);
            return @object;
        }

        return Instantiate(@object, _container);
    }

    public int GetActiveCount() =>
        _queue.Count;

    public void ClearPool()
    {
        if (GetActiveCount() < 0)
            _queue.Clear();
    }
}