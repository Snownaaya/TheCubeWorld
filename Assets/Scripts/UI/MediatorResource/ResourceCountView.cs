using Assets.Scripts.Datas;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ResourceCountView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countText;
        [SerializeField] private ResourceConfig _config;

        public ResourceConfig Config => _config;

        public void UpdateText(int count) =>
            _countText.text = $"{count} : {_config.ResourceType}";
    }
}