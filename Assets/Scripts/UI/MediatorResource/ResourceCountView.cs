using Assets.Scripts.Items;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ResourceCountView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countText;
        [SerializeField] private ResourceType _resourceType;

        public ResourceType ResourceType => _resourceType;

        public void UpdateText(int count) =>
            _countText.text = $"{_resourceType} : {count}";
    }
}