using Assets.Scripts.UI.AchievementView;
using System.Collections.Generic; 
using System.Linq;
using UnityEngine;
using System;

namespace Assets.Scripts.Datas
{
    [CreateAssetMenu(fileName = "AchieveText", menuName = "AchieveText/ScriptableObject")]
    public class AhieveTextConfig : ScriptableObject
    {
        [SerializeField] private List<AchievementInfoView> _achievementInfoView;

        public IEnumerable<AchievementInfoView> AchievementInfoViews => _achievementInfoView;

        private void OnValidate()
        {
            var achieveView = _achievementInfoView.GroupBy(text => text.AchievementConfig.AchievementNames)
                .Where(array => array.Count() > 1);

            if(achieveView.Count() > 0)
                throw new InvalidOperationException(nameof(_achievementInfoView));
        }
    }
}