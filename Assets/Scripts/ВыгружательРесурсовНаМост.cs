using UnityEngine;

public class ВыгружательРесурсовНаМост : MonoBehaviour
{
    [SerializeField] private Resource _resource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BuildingArea buildingArea)) 
            buildingArea.DeliveResource(_resource);
    }
}