using UnityEngine;
using TMPro;
using Assets.Scripts.Datas;

namespace Assets.Scripts.UI.AchievementView
{
    public class AchievementInfoView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _achieveInfo;
        [SerializeField] private AchievementConfig _achievementsConfig;

        public AchievementConfig AchievementConfig => _achievementsConfig;

        private void OnButtonClick()
        {

        }
    }
}