using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _renderers;

    [SerializeField] private Material[] _materials;

    private void Awake()
    {
        _renderers = GetComponentsInChildren<MeshRenderer>();
    }

    //public Material[] ChangeMateials()
    //{

    //}
}