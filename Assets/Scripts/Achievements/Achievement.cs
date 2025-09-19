using UnityEngine;
using DG.Tweening;
using Assets.Scripts.Datas;

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
                .Append(_achievementTransform.transform.DOScale(1f, 0.5f).From(0).SetEase(Ease.Linear))
                .SetUpdate(true)
                .Restart();
        }

        public void Hide()
        {
            KillCurrentAnimationIfActive();

            _animation = DOTween.Sequence();

            _animation
                .Append(_achievementCanvasGroup.DOFade(1f, 0f).From(1f))
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