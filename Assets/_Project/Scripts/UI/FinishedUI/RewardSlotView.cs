namespace Assets.Scripts.UI.FinishedUI
{
    using TMPro;
    using UnityEngine;

    public class RewardSlotView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _multiplierText;
        [SerializeField] private RectTransform _multiplierRectTransform;

        public Transform Anchor => _multiplierRectTransform;

        public void MultiplierText(float value) =>
            _multiplierText.text = $"x{value}";
    }
}