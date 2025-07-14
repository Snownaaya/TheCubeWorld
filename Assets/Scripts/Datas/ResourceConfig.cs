using Assets.Scripts.Items;
using UnityEngine;

namespace Assets.Scripts.Datas
{
    [CreateAssetMenu(fileName = "ResourceConfig", menuName = "Resource/ResourceConfig")]
    public class ResourceConfig : ScriptableObject
    {
        [SerializeField] private ResourceTypes _type;
        [SerializeField] private Material _material;
        [SerializeField] private float _speed;

        public ResourceTypes ResourceType => _type;
        public Material Material => _material;
        public float Speed => _speed;
    }
}
