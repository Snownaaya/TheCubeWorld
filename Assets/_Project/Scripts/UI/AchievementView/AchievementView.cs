namespace Assets.Scripts.UI.AchievementView
{
    using Assets.Scripts.Datas;
    using Assets.Scripts.Interfaces;
    using UnityEngine;
    using UnityEngine.UI;

    public class AchievementView : MonoBehaviour, ILockable
    {
        [SerializeField] private AchievementConfig _achieveNames;
        [SerializeField] private Image _lockImage;

        public AchievementConfig AchievementConfig => _achieveNames;

        public bool IsLock { get; private set; }

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
    }
}