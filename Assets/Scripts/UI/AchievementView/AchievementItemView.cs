using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.AchievementView
{
    public class AchievementItemView : MonoBehaviour
    {
        [SerializeField] private Image _lockImage;

        public bool IsLock {  get; private set; }

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
