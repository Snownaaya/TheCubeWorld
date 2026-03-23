namespace Assets.Project.Scripts.UI.GameUI
{
    using UnityEngine;

    public class HudLayer : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        public void Hide() =>
            _rectTransform.gameObject.SetActive(false);

        public void Show() =>
            _rectTransform.gameObject.SetActive(true);
    }
}