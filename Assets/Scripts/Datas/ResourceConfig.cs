using Assets.Scripts.Items;
using UnityEngine;

namespace Assets.Scripts.Datas
{
    [CreateAssetMenu(fileName = "ResourceConfig", menuName = "Resource/ResourceConfig")]
    public class ResourceConfig : ScriptableObject
    {
        [SerializeField] private ResourceType _type;
        [SerializeField] private Material _material;

        public ResourceType ResourceType => _type;
        public Material Material => _material;
    }
}
