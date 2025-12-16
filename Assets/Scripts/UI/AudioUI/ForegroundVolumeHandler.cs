using Assets.Scripts.Service.Audio;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.UI.AudioUI
{
    public class ForegroundVolumeHandler : VolumeSliderView
    {
        [SerializeField] private AudioTypes[] _audioTypes;

        private ForegroundAudioService _audioService;

        [Inject]
        private void Construct(ForegroundAudioService audioService) =>
            _audioService = audioService;

        protected override void OnVolumeChanged(float value)
        {
            foreach (AudioTypes audioType in _audioTypes)
                _audioService.ForegroundSetVolume(value, audioType);
        }
    }
}
