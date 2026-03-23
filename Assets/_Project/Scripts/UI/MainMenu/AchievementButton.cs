namespace Assets.Scripts.UI.MainMenu
{
    using Assets.Scripts.UI.GameUI;
    using UnityEngine;

    public class AchievementButton : WindowView
    {
        [SerializeField] private RectTransform _rectAchievement;
        [SerializeField] private BackgroundPanel _backgroundPanel;
        [SerializeField] private RectTransform _achieveInfo;

        protected override void Close()
        {
            base.Close();

            _achieveInfo.gameObject.SetActive(false);
            _rectAchievement.gameObject.SetActive(false);
            _backgroundPanel.Hide();
        }

        protected override void Open()
        {
            base.Open();

            _achieveInfo.gameObject.SetActive(true);
            _rectAchievement.gameObject.SetActive(true);
            _backgroundPanel.Show();
        }
    }
}