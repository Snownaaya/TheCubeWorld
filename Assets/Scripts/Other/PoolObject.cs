using System.Collections.Generic;
using UnityEngine;

public class PoolObject<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private Queue<T> _queue = new Queue<T>();
    private List<T> _activeObjects = new List<T>();

    public void Push(T @object)
    {
        @object.gameObject.SetActive(false);
        _activeObjects.Remove(@object);
        _queue.Enqueue(@object);
    }

    public T Pull(T @object)
    {
        T instance;

        if (_queue.Count > 0)
        {
            instance = _queue.Dequeue();
            instance.gameObject.SetActive(true);
        }
        else
        {
            instance = Instantiate(@object, _container);
        }

        _activeObjects.Add(instance); 
        return instance;
    }

    public int GetActiveCount()
    {
        return _activeObjects.Count;
    }

    public void ClearPool()
    {
        foreach (var obj in _activeObjects)
            Destroy(obj.gameObject);

        _activeObjects.Clear();
        _queue.Clear();
    }
}