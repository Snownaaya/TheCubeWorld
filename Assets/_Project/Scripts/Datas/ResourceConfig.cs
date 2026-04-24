namespace Assets.Scripts.Datas
{
    using Assets.Scripts.Items;
    using UnityEngine;

    [CreateAssetMenu(fileName = "ResourceConfig", menuName = "Resource/ResourceConfig")]
    public class ResourceConfig : ScriptableObject
    {
        [SerializeField] private ResourceTypes _type;
        [SerializeField] private Material _material;
        [SerializeField] private string _textResource;

        public ResourceTypes ResourceType => _type;

        public Material Material => _material;

        public string TextResource => _textResource;
    }
}