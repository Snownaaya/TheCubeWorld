using UnityEngine;

namespace Assets.Scripts.UI.MainMenu
{
    public class AchievementButton : WindowView
    {
        [SerializeField] private RectTransform _rectAchievement;

        protected override void Close() =>
            _rectAchievement.gameObject.SetActive(false);

        protected override void Open() =>
            _rectAchievement.gameObject.SetActive(true);
    }
}