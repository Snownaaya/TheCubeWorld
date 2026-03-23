namespace Assets.Scripts.UI.GameUI
{
    using Assets.Scripts.Service.Audio;
    using Reflex.Attributes;
    using UnityEngine;

    public abstract class UIElement : MonoBehaviour
    {  
        private ForegroundAudioService _audioService;

        [Inject]
        private void Construct(ForegroundAudioService audioService) =>
            _audioService = audioService;

        public virtual void Show() =>
            _audioService.PlaySound(AudioTypes.Buttons);

        public virtual void Hide() =>
            _audioService.PlaySound(AudioTypes.Buttons);
    }
}