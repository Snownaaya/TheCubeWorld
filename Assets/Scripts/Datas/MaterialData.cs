using UnityEngine;

[CreateAssetMenu(fileName = "Material", menuName = "ScriptableObject/Material", order = 1)]
public class MaterialData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Material _material;

    public string Name => _name;
    public Material Material => _material;
}