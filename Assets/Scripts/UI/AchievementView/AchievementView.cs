using Assets.Scripts.Achievements;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System;
using Assets.Scripts.Datas;

namespace Assets.Scripts.UI.AchievementView
{
    public class AchievementView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _lockImage;
        [SerializeField] private AchievementConfig _achieveNames;

        public AchievementConfig AchievementConfig => _achieveNames;
        public bool IsLock { get; private set; }

        public event Action Clicked;

        public void Lock()
        {
            IsLock = true;
            _lockImage.gameObject.SetActive(IsLock);
        }

        public void Unlock()
        {
            IsLock = false;
            _lockImage.gameObject.SetActive(IsLock);
        }

        public void OnPointerClick(PointerEventData eventData) =>
            Clicked?.Invoke();
    }
}