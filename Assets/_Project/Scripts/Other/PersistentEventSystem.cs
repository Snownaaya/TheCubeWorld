using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Project.Scripts.Other
{
    [RequireComponent(typeof(EventSystem))]
    public class PersistentEventSystem : MonoBehaviour
    {
        private EventSystem[] _eventSystem;

        private void Awake()
        {
            _eventSystem = GetComponents<EventSystem>();

            if(_eventSystem.Length > 1)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }
    }
}