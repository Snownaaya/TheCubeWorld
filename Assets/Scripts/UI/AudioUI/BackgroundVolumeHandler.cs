using Assets.Scripts.Service.Audio;
using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.AudioUI
{
    public class BackgroundVolumeHandler : VolumeSliderView
    {
        private BackgroundAudioService _audioService;

        [Inject]
        private void Construct(BackgroundAudioService audioService) =>
            _audioService = audioService;

        protected override void OnVolumeChanged(float value) =>
            _audioService.BackgroundSetVolume(value).Forget();
    }
}