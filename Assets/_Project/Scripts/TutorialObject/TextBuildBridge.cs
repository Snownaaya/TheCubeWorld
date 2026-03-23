namespace Assets.Scripts.TutorialObject
{
    using Assets.Project.Scripts.Other;
    using DG.Tweening;
    using TMPro;
    using UnityEngine;

    public class TextBuildBridge : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tutorBuildBridgeText;
        [SerializeField] private RectTransform _rectTransform;

        public void SetText(string message)
        {
            _rectTransform.gameObject.SetActive(true);
            _tutorBuildBridgeText.text = message;
        }

        public void Show()
        {
            _rectTransform.gameObject.SetActive(true);
            TweenHelper.ScaleUI(_rectTransform);
        }

        public void Hide()
        {
            TweenHelper.HideUI(_rectTransform);

            DOTween.To(() => 0, x => { }, 1f, 0.5f)
                .OnComplete(() => _rectTransform.gameObject.SetActive(false));
        }
    }
}