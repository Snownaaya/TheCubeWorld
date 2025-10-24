using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Assets.Scripts.Achievements;

namespace Assets.Scripts.UI.AchievementView
{
    public class AchievementInfoView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _achieveInfo;
        [SerializeField] private AchievementNames _achievementsName;

        public AchievementNames AchievementNames => _achievementsName;

        private void OnButtonClick()
        {

        }
    }
}