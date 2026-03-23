namespace Assets.Project.Scripts.UI.Shop.AbilitiesShop
{
    using Assets.Scripts.UI.Shop.SO;
    using TMPro;
    using UnityEngine;

    public class ShopAbilityInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textPrefab;

        public void Initialize(AbilityItem abilityItem)
        {
            if (_textPrefab == null)
                return;

            _textPrefab.text = abilityItem.AbilityInfo ?? string.Empty;
            _textPrefab.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _textPrefab.text = string.Empty;
            _textPrefab.gameObject.SetActive(false);
        }
    }
}