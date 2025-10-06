using Assets.Scripts.Datas;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Achievements
{
    public class Achievement : MonoBehaviour
    {
        [SerializeField] private AchievementConfig _achievementConfig;
        [SerializeField] private RectTransform _achievementTransform;
        [SerializeField] private CanvasGroup _achievementCanvasGroup;

        private Sequence _animation;

        public AchievementConfig AchievementConfig => _achievementConfig;

        public void Show()
        {
            _animation = DOTween.Sequence();

            _animation
                .Append(_achievementTransform.transform.DOScale(1f, 0.5f)
                .From(0)
                .SetEase(Ease.Linear))
                .SetUpdate(true)
                .Restart();
        }

        public void Hide()
        {
            KillCurrentAnimationIfActive();

            _animation = DOTween.Sequence();

            _animation
                .Append(/*_achievementCanvasGroup.DOFade(1f, 0f).From(1f)*/ _achievementTransform
                .DORotate(new Vector3(90, 90, 90), 2))
                .Join(_achievementTransform.DOScale(0f, 1f))
                .OnComplete(() =>
                {
                    gameObject.SetActive(false);
                })
                .SetAutoKill()
                .Restart();
        }

        private void KillCurrentAnimationIfActive()
        {
            if (InAnimation())
                _animation.Kill();
        }

        private bool InAnimation() =>
             _animation != null && _animation.active;
    }
}