using Assets.Scripts.Datas;
using UnityEngine;
using TMPro;

namespace Assets.Scripts.Domain.MediatorResource
{
    public class ResourceCountView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countText;
        [SerializeField] private ResourceConfig _config;

        public ResourceConfig Config => _config;

        public void UpdateText(int count) =>
            _countText.text = $"{count}:{_config.ResourceType}";
    }
}