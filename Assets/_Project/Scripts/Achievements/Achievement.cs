namespace Assets.Scripts.Achievements
{
    using Assets.Project.Scripts.Other;
    using Assets.Scripts.Datas;
    using UnityEngine;

    public class Achievement : MonoBehaviour
    {
        [SerializeField] private AchievementConfig _achievementConfig;
        [SerializeField] private RectTransform _achievementTransform;
        [SerializeField] private CanvasGroup _achievementCanvasGroup;

        public void Show()
        {
            if (_achievementCanvasGroup == null || this == null)
                return;

            _achievementTransform.gameObject.SetActive(true);
            TweenHelper.ScaleUI(_achievementTransform);
        }

        public void Hide()
        {
            if (_achievementCanvasGroup == null || this == null)
                return;

            _achievementTransform.gameObject.SetActive(true);
            TweenHelper.HideUI(_achievementTransform);
        }
    }
}