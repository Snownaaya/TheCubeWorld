using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.AchievementView
{
    public class AchievementInfoView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TextMeshProUGUI _achieveText;

        public void OnPointerEnter(PointerEventData eventData) =>
            _achieveText.gameObject.SetActive(true);

        public void OnPointerExit(PointerEventData eventData) =>
            _achieveText.gameObject.SetActive(false);
    }
}