using Assets.Scripts.Service.Audio;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.UI.GameUI
{
    public abstract class UIElement : MonoBehaviour
    {
        private AudioService _audioService;

        [Inject]
        private void Construct(AudioService audioService) =>
            _audioService = audioService;

        public virtual void Show() =>
            _audioService.PlaySound(AudioTypes.Buttons);

        public virtual void Hide() =>
            _audioService.PlaySound(AudioTypes.Buttons);
    }
}