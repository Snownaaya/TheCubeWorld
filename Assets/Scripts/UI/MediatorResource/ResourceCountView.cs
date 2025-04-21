using Assets.Scripts.Datas;
using Assets.Scripts.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

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