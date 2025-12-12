using Assets.Scripts.UI.GameUI;
using UnityEngine;

namespace Assets.Scripts.UI.MainMenu
{
    public class AchievementButton : WindowView
    {
        [SerializeField] private RectTransform _rectAchievement;
        [SerializeField] private BackgroundPanel _backgroundPanel;

        protected override void Close()
        {
            base.Close();

            _rectAchievement.gameObject.SetActive(false);
            _backgroundPanel.Hide();
        }

        protected override void Open()
        {
            base.Open();

            _rectAchievement.gameObject.SetActive(true);
            _backgroundPanel.Show();
        }
    }
}