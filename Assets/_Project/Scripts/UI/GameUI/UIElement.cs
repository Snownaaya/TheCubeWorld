using Assets.Scripts.Service.Audio;
using DG.Tweening;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.UI.GameUI
{
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