namespace Assets.Scripts.UI.MainMenu
{
    using Assets.Project.Scripts.Other;
    using Assets.Scripts.Service.Audio;
    using Reflex.Attributes;
    using UnityEngine;
    using UnityEngine.UI;

    public abstract class WindowView : MonoBehaviour
    {
        [SerializeField] protected RectTransform RectTransform;

        [field: SerializeField] protected Button ButtonOpen { get; private set; }

        [field: SerializeField] protected Button ButtonClose { get; private set; }

        private ForegroundAudioService _audioService;

        [Inject]
        private void Construct(ForegroundAudioService audioService) =>
            _audioService = audioService;

        private void OnEnable()
        {
            ButtonOpen.onClick.AddListener(Open);
            ButtonClose.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            ButtonOpen.onClick.RemoveListener(Open);
            ButtonClose.onClick.RemoveListener(Close);
        }

        protected virtual void Open()
        {
            _audioService.PlaySound(AudioTypes.Buttons);
            TweenHelper.ButtonShake(RectTransform);
        }

        protected virtual void Close() =>
            _audioService.PlaySound(AudioTypes.Buttons);
    }
}