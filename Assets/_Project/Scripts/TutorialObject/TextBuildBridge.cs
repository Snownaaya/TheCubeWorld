using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.TutorialObject
{
    public class TextBuildBridge : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tutorBuildBridgeText;

        private Sequence _animation;

        public void SetText(string message)
        {
            transform.gameObject.SetActive(true);
            _tutorBuildBridgeText.text = message.ToString();
        }

        public void Show()
        {
            _animation = DOTween.Sequence();

            _animation
                .Append(_tutorBuildBridgeText.transform.DOScale(1f, 0.3f)
                .From(0)
                .SetEase(Ease.Linear))
                .SetUpdate(true)
                .Restart();
        }

        public void Hide()
        {
            if (gameObject.activeSelf == false)
                return;

            KillCurrentAnimationIfActive();

            _animation = DOTween.Sequence();

            _animation.Append(_tutorBuildBridgeText.transform.DOScale(1f, 0f)
                .From()
                .SetEase(Ease.Linear)
                .SetUpdate(true)
                .OnComplete(() =>
                {
                    gameObject.SetActive(false);
                }))
                .SetAutoKill();
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