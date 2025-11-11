using System.Collections.Generic;
using UnityEngine;

public class PoolObject<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private Stack<T> _pool = new Stack<T>();
    private List<T> _active = new List<T>();

    public T Pull(T prefab)
    {
        T instance;

        if (_pool.TryPop(out instance) == false)
            instance = Instantiate(prefab, _container);

        _active.Add(instance);
        instance.gameObject.SetActive(true);
        return instance;
    }

    public void Push(T instance)
    {
        instance.gameObject.SetActive(false);
        _pool.Push(instance);
        _active.Remove(instance);
    }

    public int GetActiveCount() => _active.Count;
}