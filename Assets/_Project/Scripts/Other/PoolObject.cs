using System.Collections.Generic;
using UnityEngine;

public class PoolObject<T> : MonoBehaviour where T : MonoBehaviour
{
    private Stack<T> _pool = new Stack<T>();
    private List<T> _active = new();

    public T Pull(T prefab)
    {
        T instance;

        while (_pool.Count > 0)
        {
            instance = _pool.Pop();

            if (instance != null)
            {
                instance.gameObject.SetActive(true);
                _active.Add(instance);
                return instance;
            }
        }

        var newInstance = Instantiate(prefab);

        _active.Add(newInstance);
        return newInstance;
    }

    public void Push(T instance)
    {
        _pool.Push(instance);
        _active.Remove(instance);
        instance.gameObject.SetActive(false);
    }
}